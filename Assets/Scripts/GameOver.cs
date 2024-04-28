using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("To TItle");
            // タイトルシーンに変更する
             SceneManager.LoadScene("Title"); 
        }
    }
}
