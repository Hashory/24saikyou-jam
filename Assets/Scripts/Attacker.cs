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

    private float keyDownTime = 0f;
    private GameObject spawnKnife = null;

    // Update is called once per frame
    void Update()
    {
        // K down
        if (Input.GetKeyDown(KeyCode.K))
        {
            keyDownTime = Time.time;
            if (spawnKnife == null)
            {
                spawnKnife = Instantiate(Knife, new Vector3(radius, SpawnHeight, 0), Quaternion.identity);
            }
        }

        // K duration
        if (Input.GetKey(KeyCode.K))
        {
            UpdateKnifePos(); // Kキーを押している間、位置を更新
        }

        // K up
        if (Input.GetKeyUp(KeyCode.K))
        {
            float duration = Time.time - keyDownTime;
            Debug.Log("K key down time: " + duration + "s");
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            float duration = Time.time - keyDownTime;
            Debug.Log("K key down time: " + duration + "s");
        }

        // push knife
        if (Input.GetKeyUp(KeyCode.D)) 
        {
            if (spawnKnife != null)  // spawnKnifeがnullでないときだけ以下の処理を実行
            {
                Debug.Log("push knife");

                var rb = spawnKnife.GetComponent<Rigidbody>();
                rb.useGravity = true;

                spawnKnife = null; // spawnKnifeをリセットする
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
