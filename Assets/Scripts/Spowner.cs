using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spowner : MonoBehaviour
{
    public GameObject spawnObject; // スポーンするオブジェクト
    public float minRadius; // 最小半径
    public float maxRadius; // 最大半径
    public float minAngle; // 最小角度（度数）
    public float maxAngle; // 最大角度（度数）

    public float spawnInterval = 2.0f; // スポーン間隔（秒）

    private float timeSinceLastSpawn; // 最後のスポーンからの経過時間

    void Update()
    {
        // 経過時間を更新
        timeSinceLastSpawn += Time.deltaTime;

        // 経過時間がスポーン間隔を超えたか確認
        if (timeSinceLastSpawn >= spawnInterval)
        {
            // スポーン関数を呼び出し
            SpawnRandom();

            // 経過時間をリセット
            timeSinceLastSpawn = 0;
        }
    }


    void SpawnRandom()
    {
        float radius = Random.Range(minRadius, maxRadius); // 半径をランダムに選択
        float angle = Random.Range(minAngle, maxAngle); // 角度をランダムに選択

        // 極座標を直交座標に変換
        float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        // オブジェクトの生成
        Instantiate(spawnObject, new Vector3(x, 0, y), Quaternion.identity);
    }

}
