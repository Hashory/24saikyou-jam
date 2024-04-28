using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System.Runtime.InteropServices.WindowsRuntime;

public class Potion_manager : MonoBehaviour
{
    public int Score = 0;
    public int[] player_score = new int [4];
    public int[] player_Lv = new int[4];
    public int PlayerMaxHP = 5;
    public int PlayerHP;
    public int Level = 1;
    public Text scoreText;
    public Image[] heartImage;
    public Sprite fullHeart; 
    public Sprite emptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = PlayerMaxHP;
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
        if(Score%20 == 0 && Score != 0 && PlayerHP < PlayerMaxHP)
        {
            PlayerHP++;
            UpdateHPUI();
        }
    }

    public void DecreaseHP()
    {
        PlayerHP--;
        Mathf.Max(PlayerHP, 0);
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
        for (int i = 0; i < heartImage.Length; i++)
        {
            if (i < PlayerHP)
                heartImage[i].sprite = fullHeart;
            else
                heartImage[i].sprite = emptyHeart;
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + Score.ToString();  // スコアの表示を更新
    }

    public void player_scoreIncrease(int pnum)
    {
        player_score[pnum]++;

        if (player_score[pnum] >= 5)
        {
            player_Lv[pnum] = 2;
        }
        else if (player_score[pnum] >= 15)
        {
            player_Lv[pnum] = 3;
        }
        else if (player_score[pnum] >= 35)
        {
            player_Lv[pnum] = 4;
        }
        else if (player_score[pnum] >= 65)
        {
            player_Lv[pnum] = 5;
        }
        else
        {
            player_Lv[pnum] = 1;
        }
        Debug.Log("Player:" + pnum + " Score:"+ player_score[pnum] +" Lv:" + player_Lv[pnum]);
    }

}
