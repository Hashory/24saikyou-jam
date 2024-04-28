using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class police : MonoBehaviour
{
    public Transform potion; // potionオブジェクトへの参照
    public float speed = 1.0f; // 移動速度
    public int HP = 1; // HP
    private float startY; // 初期のY座標

    void Start()
    {
        if (potion == null)
        {
            potion = GameObject.FindGameObjectWithTag("potion").transform; // potionタグを使用してオブジェクトを見つける
        }
        startY = transform.position.y; // 初期のY座標を保存

        // potionオブジェクトの方向を向く
        Vector3 direction = potion.position - transform.position;
        direction.y = 0; // Y軸の変動を0にする（水平面上のみを考慮）
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = newRotation;

        // 初期位置のY座標を固定する
        transform.position = new Vector3(transform.position.x, startY, transform.position.z);
    }

    void Update()
    {
        // 敵をpotionの方向に移動させる。Y座標は変更しない。
        Vector3 moveDirection = potion.position - transform.position;
        moveDirection.y = 0; // Y軸の変動を0にする
        moveDirection.Normalize(); // ベクトルの正規化
        transform.position += moveDirection * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, startY, transform.position.z); // Y座標を固定
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"当たった: {other.gameObject.name}");
        if (other.gameObject.CompareTag("Attack"))
        {
            Debug.Log("攻撃を受けた");
            HP -= 1;
            if (HP <= 0)
            {
                Debug.Log("オブジェクトが破壊されます");
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("potion"))
        {
            Debug.Log("ポーションと衝突し、オブジェクトが破壊されます");
            Destroy(gameObject);
        }
    }
}