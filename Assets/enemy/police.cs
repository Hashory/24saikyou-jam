using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class police : MonoBehaviour
{
    public Transform potion;
    public float speed = 1.0f;
    public int HP = 1;
    private float startY; // 初期のY座標

    void Start()
    {
        if (potion == null)
        {
            potion = GameObject.FindGameObjectWithTag("potion").transform; // プレイヤータグを使用してプレイヤーを見つける
        }
        startY = transform.position.y; // 初期のY座標を保存
        Vector3 lookPosition = potion.position - transform.position;
        lookPosition.y = 0; // Y軸の回転を無視
        transform.rotation = Quaternion.LookRotation(lookPosition);
    }

    void Update()
    {
        Vector3 direction = potion.position - transform.position;
        direction.y = 0; // Y軸の変動を0にする
        direction.Normalize(); // ベクトルの正規化

        // 敵をプレイヤーの方向に移動させる。Y座標は変更しない。
        transform.position += direction * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, startY, transform.position.z); // Y座標を固定
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("attack")) // attackタグと衝突を検証
        {
            HP -= 1; // HPを1減らす
            if (HP <= 0) // HPが0以下で
            {
                Destroy(gameObject); // このオブジェクトを破壊する
            }
        }
    }

}

