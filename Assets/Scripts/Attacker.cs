using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public GameObject Knife;
    public float cycleTime = 10.0f;
    public float radius = 15.0f;
    public float SpawnHeight = 10;
    public KeyCode KeyCode = KeyCode.K;

    private float keyDownTime = 0f;
    private GameObject spawnKnife = null;
    private bool mode = false;

    // Update is called once per frame
    void Update()
    {
        // K down
        if (Input.GetKeyDown(KeyCode) && !mode)
        {
            keyDownTime = Time.time;
            if (spawnKnife == null)
            {
                spawnKnife = Instantiate(Knife, new Vector3(radius, SpawnHeight, 0), Quaternion.identity);
            }
        }

        // K duration
        if (Input.GetKey(KeyCode) && !mode)
        {
            UpdateKnifePos(); // Kキーを押している間、位置を更新
        }

        if (Input.GetKeyUp(KeyCode))
        {
            if (!mode)
            {
                // 最初のキーアップで回転を停止する
                mode = true;  // modeをtrueに設定して、次のKキー押下で重力を適用する準備
            }
            else if (spawnKnife != null)
            {
                // 二回目のキーアップで重力を適用
                Rigidbody rb = spawnKnife.GetComponent<Rigidbody>();
                rb.useGravity = true;
                mode = false;  // modeをリセット
                spawnKnife = null;  // spawnKnifeをリセットする
            }
        }

    }

    void UpdateKnifePos()
    {
        float duration = Time.time - keyDownTime;
        float angle = 2 * Mathf.PI * (duration / cycleTime);
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        spawnKnife.transform.position = new Vector3(x, SpawnHeight, y);
    }
}
