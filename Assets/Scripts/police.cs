using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Police : MonoBehaviour
{
    public Transform potion; // potionオブジェクトへの参照
    public float speed = 1.0f; // 移動速度
    public int HP = 1; // HP
    private float startY; // 初期のY座標
    public Potion_manager scoreManager; // PotionManagerへの参照

    void Start()
    {
        // potionタグを持つオブジェクトを見つける
        if (potion == null)
        {
            potion = GameObject.FindGameObjectWithTag("potion").transform;
        }
        startY = transform.position.y; // 初期のY座標を保存

        // potionオブジェクトの方向を向く
        Vector3 direction = potion.position - transform.position;
        direction.y = 0; // Y軸の変動を0にする（水平面上のみを考慮）
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = newRotation;

        // 初期位置のY座標を固定する
        transform.position = new Vector3(transform.position.x, startY, transform.position.z);

        // potionオブジェクトからPotionManagerコンポーネントを取得
        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<Potion_manager>();
        }
    }

    void Update()
    {
        // potionの方向に移動させる
        Vector3 moveDirection = potion.position - transform.position;
        moveDirection.y = 0; // Y軸の変動を0にする
        moveDirection.Normalize(); // ベクトルの正規化
        transform.position += moveDirection * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, startY, transform.position.z); // Y座標を固定
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            Debug.Log("ダメージ");
            HP -= 1;
            if (HP <= 0)
            {
                Debug.Log("破壊");
                if (scoreManager != null)
                {
                    scoreManager.IncreaseScore();  // スコアを増やす
                }
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("potion"))
        {
            Debug.Log("到達");
            if (scoreManager != null)
            {
                scoreManager.DecreaseHP();  // 体力を減らす
            }
            Destroy(gameObject);
        }
    }
}