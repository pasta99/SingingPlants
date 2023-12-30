using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actuator : MonoBehaviour
{
    public float minLight = 0.3f;
    public float maxLight = 1.0f;
    SpriteRenderer spriteRenderer;

    Color currentColor; 
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        currentColor = Color.white; 
    }

    public void SetLightLevel(float lightLevel) {
        float colorIntensity = Mathf.Lerp(minLight, maxLight, lightLevel);
        Color c = colorIntensity * currentColor;
        c.a = 1.0f;
        spriteRenderer.color = c;
    }
}
