using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class police : MonoBehaviour
{
    public Transform potion;
    public float speed = 1.0f;
    private float startY; // 初期のY座標

    void Start()
    {
        startY = transform.position.y; // 初期のY座標を保存
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
}

