using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light directionalLight;  // Inspectorからアサイン
    public Color morningColor;
    public Color noonColor;
    public Color nightColor;

    public void UpdateLighting(int timeOfDay)
    {
        switch (timeOfDay)
        {
            case 0: // 朝
                SetLighting(morningColor, 1f);
                break;
            case 1: // 昼
                SetLighting(noonColor, 0.95f);
                break;
            case 2: // 夜
                SetLighting(nightColor, 0.75f);
                break;
        }
    }

    private void SetLighting(Color color, float intensity)
    {
        directionalLight.color = color;
        directionalLight.intensity = intensity;
    }
}