using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Potion_manager potionManager; // Potion_managerへの参照
    public Attacker attacker;            // Attackerスクリプトへの参照
    public Color goldColor = new Color(1, 0.843f, 0, 1); // 金色
    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        if (attacker != null && potionManager != null)
        {
            UpdateColorBasedOnLevel();
        }
        else
        {
            Debug.LogError("Required components are not assigned!");
        }
    }

    private void Update()
    {
        UpdateColorBasedOnLevel();
    }

    void UpdateColorBasedOnLevel()
    {
        int playerNumber = attacker.PlayerNumber; // AttackerからPlayerNumberを取得
        if (potionManager.player_Lv[playerNumber] == 4)
        {
            ChangeColor(goldColor);
        }
    }

    void ChangeColor(Color newColor)
    {
        if (objRenderer != null)
        {
            objRenderer.material.color = newColor; // マテリアルの色を変更
        }
        else
        {
            Debug.LogError("Renderer component not found on the object!");
        }
    }
}