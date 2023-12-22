using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantColorManager : MonoBehaviour
{
    public float minLight = 0.3f;
    public float maxLight = 1.0f;
    PlantManager plantManager;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        plantManager = transform.GetComponent<PlantManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float lightLevel = plantManager.GetLightLevel();
        float colorIntensity = Mathf.Lerp(minLight, maxLight, lightLevel);
        Color c = colorIntensity * Color.white;
        c.a = 1.0f;
        spriteRenderer.color = c;
        
    }
}
