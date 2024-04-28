using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public GameObject Weapon_1;
    public float cycleTime = 10.0f;
    public float radius = 15.0f;
    public float SpawnHeight = 10;
    public KeyCode KeyCode = KeyCode.K;
    public int PlayerNumber;

    private float keyDownTime = 0f;
    private GameObject spawnKnife = null;
    private bool mode = false;

    void Update()
    {
        HandleKeyPress();
    }

    private void HandleKeyPress()
    {
        if (Input.GetKeyDown(KeyCode) && !mode)
        {
            keyDownTime = Time.time;
            spawnKnife = Instantiate(Weapon_1, new Vector3(radius, SpawnHeight, 0), Quaternion.identity);
            InitializeKnife();
        }

        if (Input.GetKey(KeyCode) && !mode)
        {
            UpdateKnifePos();
        }

        if (Input.GetKeyUp(KeyCode))
        {
            ToggleMode();
        }
    }

    private void InitializeKnife()
    {
        knife knifeScript = spawnKnife.GetComponent<knife>();
        if (knifeScript != null)
        {
            knifeScript.setnumber(PlayerNumber);
        }
    }

    private void ToggleMode()
    {
        if (!mode)
        {
            mode = true;
        }
        else if (spawnKnife != null)
        {
            ApplyGravity();
        }
    }

    private void ApplyGravity()
    {
        Rigidbody rb = spawnKnife.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
        }
        mode = false;
        spawnKnife = null;
    }

    private void UpdateKnifePos()
    {
        float duration = Time.time - keyDownTime;
        float angle = Mathf.PI * 2 * (duration / cycleTime);
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);
        spawnKnife.transform.position = new Vector3(x, SpawnHeight, y);
    }
}