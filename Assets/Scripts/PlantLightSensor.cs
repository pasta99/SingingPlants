using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLightSensor : MonoBehaviour
{
    LightManager lightManager;
    PlantManager plantManager;
    // Start is called before the first frame update
    void Start()
    {
        lightManager = GameObject.Find("LightManager").GetComponent<LightManager>();
        plantManager = transform.GetComponent<PlantManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float light = lightManager.GetLightLevel(new Vector2(transform.position.x, transform.position.y));
        plantManager.SetLightLevel(light);
    }
}
