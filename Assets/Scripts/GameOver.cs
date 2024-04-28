using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MonoBehaviour
{
    public Text scoreText; 
    public int lastscore;
    public int Player1_Level,Player2_Level;
    private int bonus;
    
    private void Start()
    {
        if(Player1_Level == 4 || Player2_Level == 4)
        {
            bonus = 7777;
        }
        else if (Player1_Level == Player2_Level)
        {
            switch (Player1_Level)
            {
                case 1:
                    bonus = 60; break;

                case 2:
                    bonus = 70; break;

                case 3:
                    bonus = 85; break;

                default:
                    bonus = 0; break;
            }
        }else if (Math.Abs(Player1_Level - Player2_Level) == 1)
        {
            bonus = 40;
        }else if(Math.Abs(Player1_Level - Player2_Level) == 2)
        {
            bonus = 20;
        }
        else
        {
            bonus = 10;
        }
        Debug.Log("Score:" + lastscore);
        Debug.Log("Bonus:" + bonus);
        lastscore += bonus;

        scoreText.text = "Score:" + lastscore.ToString();

    }
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
