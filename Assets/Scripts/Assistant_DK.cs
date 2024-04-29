using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assistant_DK : MonoBehaviour
{
    public GameObject AssistantDKImage;
    public float AssistantDKDuration = 5.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ActivateImage(AssistantDKDuration));
        }
    }

    IEnumerator ActivateImage(float duration)
    {
        AssistantDKImage.SetActive(true);
        yield return new WaitForSeconds(duration);
        AssistantDKImage.SetActive(false);
    }
}
