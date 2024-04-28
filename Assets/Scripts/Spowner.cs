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
    public int stage;

    public float initialspawninterval = 4.0f; // スポーン間隔（秒）
    public float currentspawninterval;
    private float timeSinceLastSpawn; // 最後のスポーンからの経過時間

    private void Start()
    {
        currentspawninterval = initialspawninterval;
        SpawnRandom();
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        AdjustSpawnInterval(stage);

        // 経過時間がスポーン間隔を超えたか確認
        if (timeSinceLastSpawn >= currentspawninterval)
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
    void AdjustSpawnInterval(int stage)
    {
        float gameTime = Time.timeSinceLevelLoad; // ゲーム開始からの経過時間
        switch(stage)
        {
            case 0:
                if (gameTime > 80.0f)
                    currentspawninterval = 3.0f;
                else if (gameTime > 40.0f)
                    currentspawninterval = 3.5f;
                else if (gameTime > 20.0f)
                    currentspawninterval = 4.0f;
                else if (gameTime > 10.0f)
                    currentspawninterval = 5.0f;
                else
                    currentspawninterval = initialspawninterval;
                break;

            case 1:
                if (gameTime > 80.0f)
                    currentspawninterval = 1.0f;
                else if (gameTime > 40.0f)
                    currentspawninterval = 2.0f;
                else if (gameTime > 20.0f)
                    currentspawninterval = 3.0f;
                else if (gameTime > 10.0f)
                    currentspawninterval = 4.0f;
                else
                    currentspawninterval = initialspawninterval;
                break;

            case 2:
                if (gameTime > 80.0f)
                    currentspawninterval = 0.25f;
                else if (gameTime > 40.0f)
                    currentspawninterval = 0.5f;
                else if (gameTime > 20.0f)
                    currentspawninterval = 1.0f;
                else if (gameTime > 10.0f)
                    currentspawninterval = 2.0f;
                else
                    currentspawninterval = initialspawninterval;
                break;

            default:
                Debug.Log("不正な参照");
                break;
        }
    }

}

