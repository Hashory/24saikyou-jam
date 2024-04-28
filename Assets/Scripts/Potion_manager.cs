using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System.Runtime.InteropServices.WindowsRuntime;

public class Potion_manager : MonoBehaviour
{
    public int Score = 0;
    public int[] player_score = new int [4];
    public int[] player_Lv = new int[4];
    public int PlayerMaxHP = 5;
    public int PlayerHP;
    public Text scoreText;
    public Image[] heartImage;
    public Sprite fullHeart; 
    public Sprite emptyHeart;
    public AudioClip lifelost;
    public AudioClip die;
    AudioSource AudioSource;
    public int lastresort = 3;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = PlayerMaxHP;
        AudioSource = GetComponent<AudioSource>();
        UpdateHPUI();
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(lastresort == 0)
        {
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("GameOver");
        }
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
        if (PlayerHP > 0)
        {
            // AudioSource.PlayOneShot(lifelost);
            AudioManager.Instance.PlaySound(lifelost);
        }
        Mathf.Max(PlayerHP, 0);
        UpdateHPUI();
        if (PlayerHP <= 0)
        {
            AudioSource.PlayOneShot(die);
            AudioManager.Instance.PlaySound(die);
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("GameOver");
        }
    }
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.FindWithTag("gameover").GetComponent<GameOver>();

        // データを渡す処理
        gameManager.lastscore = Score;
        gameManager.Player1_Level = player_Lv[0];
        gameManager.Player2_Level = player_Lv[1]; 

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
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
        if (player_score[pnum] >= 65)
        {
            player_Lv[pnum] = 4;
            
        }
        else if (player_score[pnum]  >= 35)
        {
            player_Lv[pnum] = 3;
        }
        else if (player_score[pnum] >= 15)
        {
            player_Lv[pnum] = 2;
        }
        else if (player_score[pnum] >= 5)
        {
            player_Lv[pnum] = 1;
        }
        else
        {
            player_Lv[pnum] = 0;

        }
        Debug.Log("Player:" + pnum + " Score:"+ player_score[pnum] +" Lv:" + player_Lv[pnum]);
    }

}
