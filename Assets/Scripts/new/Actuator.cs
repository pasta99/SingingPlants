using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actuator : MonoBehaviour
{
    public float minLight = 0.3f;
    public float maxLight = 1.0f;
    public Color moistureColor; 
    public Color heatColor; 

    SpriteRenderer spriteRenderer;
    private float moistureLevel; 
    private float heatLevel; 
    float currentBrightness; 
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    public void SetLightLevel(float lightLevel) {
        float colorIntensity = Mathf.Lerp(minLight, maxLight, lightLevel);
        currentBrightness = colorIntensity;
        SetColor(); 
    }
    public void SetMoistureLevel(float moistureLevel) {
        this.moistureLevel = moistureLevel;
        SetColor();
    }
    public void SetHeatLevel(float heatLevel) {
        this.heatLevel = heatLevel;
        SetColor();
    }
    private void SetColor() {
        Color hC = Color.Lerp(Color.white, heatColor, heatLevel);
        Color mC = Color.Lerp(Color.white, moistureColor, moistureLevel);

        Color currentColor = Color.Lerp(hC, mC, 0.5f);

        Color c = currentBrightness * currentColor;
        c.a = 1.0f;
        spriteRenderer.color = c;
    }
}
