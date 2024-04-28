using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public GameObject Knife;
    public float cycleTime = 10.0f;
    public float radius = 15.0f;
    public float SpownHeight = 10;

    private float keyDownTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            keyDownTime = Time.time;
            Debug.Log("key");
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            float duration = Time.time - keyDownTime;
            Debug.Log("K key down time: " + duration + "s");
            SpawnKnife(duration);
        }

    }

    void SpawnKnife(float duration)
    {
        float angle = 2 * Mathf.PI *  (duration / cycleTime);

        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);


        Instantiate(Knife, new Vector3(x, SpownHeight, y), Quaternion.identity);
    }
}
