using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Police : MonoBehaviour
{
    public Transform potion; // potionオブジェクトへの参照
    public static float speed = 1.0f; // 移動速度
    public int HP = 1; // HP
    private float startY; // 初期のY座標
    public Potion_manager scoreManager; // PotionManagerへの参照
    public GameObject particleEffectPrefab;

    void Start()
    {   
        // potionタグを持つオブジェクトを見つける
        if (potion == null)
        {
            potion = GameObject.FindGameObjectWithTag("potion").transform;
        }
        startY = 5.5f; // 初期のY座標を保存

        // 初期位置のY座標を固定する
        transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        transform.rotation = Quaternion.Euler(45, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

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
            knife knife = other.gameObject.GetComponent<knife>();
            
            HP -= 1;
            if (HP <= 0)
            {
                if (scoreManager != null)
                {   
                    scoreManager.IncreaseScore();  // スコアを増やす
                    scoreManager.player_scoreIncrease(knife.PlayerNumber);
                }
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("potion"))
        {
            if (scoreManager != null)
            {
                scoreManager.DecreaseHP();  // 体力を減らす
            }
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (particleEffectPrefab != null)
        {
            GameObject effect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1f); // 5秒後にパーティクルエフェクトを破棄
        }
        else
        {
            Debug.LogError("Particle effect prefab is not assigned!");
        }
    }
}

