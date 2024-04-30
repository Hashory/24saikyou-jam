using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public float selectDuration = 1.0f;

    public GameObject Select1;
    public GameObject Select2;
    public GameObject Select3;

    public AudioClip SwitchSound;
    public AudioClip SelectSound;

    public GameObject Rule;
    public float PauseTime = 1.5f;

    // シーンの名前を格納する配列
    public string[] sceneNames = new string[3];

    private float timer = 0f;
    private int currentIndex = 0;

    private int? selectIndex = null;

    void Update()
    {
        // タイマーを更新
        timer += Time.deltaTime;

        // selectDuration 秒ごとにオブジェクトを切り替える
        if (timer >= selectDuration)
        {
            // タイマーをリセット
            timer = 0f;

            // インデックスを更新
            currentIndex = (currentIndex + 1) % 3;

            // 現在のインデックスに基づいて、次のオブジェクトをアクティブにする
            ActivateCurrentIndex();
        }

        // スペースキーが押されたら、対応するシーンをロード
        if (Input.GetKeyDown(KeyCode.Space) || InputManager.GetKeyDown(-1) || InputManager.GetKeyDown(1))
        {
            StartCoroutine(getSpace());
        }
    }

    private IEnumerator getSpace()
    {
        if (!selectIndex.HasValue)
        {
            // play Audio
            AudioManager.Instance.PlaySound(SelectSound);

            selectIndex = currentIndex;

            yield return new WaitForSeconds(PauseTime);
            Rule.SetActive(true);
        }
        else
        {
            // play Audio
            AudioManager.Instance.PlaySound(SelectSound);

            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("main");

            Debug.Log("Select: " + selectIndex.Value);
        }
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.FindWithTag("spawner").GetComponent<Spowner>();

        // データを渡す処理
        gameManager.stage = selectIndex.Value;

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

    void ActivateCurrentIndex()
    {
        // selectIndex が選択されている場合は、何もしない
        if (selectIndex.HasValue)
        {
            return;
        }

        // play Audio
        AudioManager.Instance.PlaySound(SwitchSound, 0.1f);

        // すべてのオブジェクトを一旦非アクティブにする
        Select1.SetActive(false);
        Select2.SetActive(false);
        Select3.SetActive(false);

        // 現在のインデックスに基づいて、対応するオブジェクトをアクティブにする
        switch (currentIndex)
        {
            case 0:
                Select1.SetActive(true);
                break;
            case 1:
                Select2.SetActive(true);
                break;
            case 2:
                Select3.SetActive(true);
                break;
        }
    }
}

