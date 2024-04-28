using UnityEngine;

public class SetActive_Duration : MonoBehaviour
{
    public GameObject targetObject; // 対象のGameObject
    public float activeTime = 2.0f;  // Activeにする時間（秒）
    public float inactiveTime = 1.0f; // Inactiveにする時間（秒）

    private float timer; // 時間計測用のタイマー
    private bool isActive; // 現在のActive状態を追跡

    // Start is called before the first frame update
    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            return;
        }

        // 最初にオブジェクトをアクティブに設定（必要に応じて変更可）
        SetActiveState(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // アクティブ時のタイマーチェック
        if (isActive && timer >= activeTime)
        {
            SetActiveState(false);
        }
        // 非アクティブ時のタイマーチェック
        else if (!isActive && timer >= inactiveTime)
        {
            SetActiveState(true);
        }
    }

    // オブジェクトのActive状態を設定し、タイマーをリセットする関数
    void SetActiveState(bool state)
    {
        targetObject.SetActive(state);
        isActive = state;
        timer = 0; // タイマーをリセット
    }
}
