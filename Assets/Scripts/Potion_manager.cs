using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class Potion_manager : MonoBehaviour
{
    public int Score = 0;
    public int PlayerHP = 5;
    public int Level = 1;
    public Text hpText;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHPUI();
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        Score++;
        UpdateScoreUI();
        Debug.Log("Score:"+Score);
        if(Score == 5)
        {
            Level = 2;
        }
        if (Score == 15)
        {
            Level = 3;
        }
        if (Score == 35)
        {
            Level = 4;
        }
        if (Score == 65)
        {
            Level = 5;
        }

        if(Score%20 == 0 && Score != 0)
        {
            PlayerHP++;
            UpdateHPUI();
        }
    }

    public void DecreaseHP()
    {
        PlayerHP--;
        UpdateHPUI();
        Debug.Log("HP:" + PlayerHP);
        if (PlayerHP <= 0)
        {
            //Time.timeScale = 0;
            Debug.Log("がめおべら");
        }
    }
    void UpdateHPUI()
    {
        hpText.text = "HP: " + PlayerHP.ToString();  // HP の表示を更新
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + Score.ToString();  // スコアの表示を更新
    }
}
