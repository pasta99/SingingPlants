using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    LightManager lightManager;
    HeatManager heatManager; 
    Plant plant;
    // Start is called before the first frame update
    void Start()
    {
        lightManager = GameObject.Find("Controller").GetComponent<LightManager>();
        heatManager = GameObject.Find("Controller").GetComponent<HeatManager>();
        plant = transform.GetComponent<Plant>();
    }

    // Update is called once per frame
    void Update()
    {
        float light = lightManager.GetLightLevel(new Vector2(transform.position.x, transform.position.y));
        float heat = heatManager.GetHeatLevel(new Vector2(transform.position.x, transform.position.y));
        plant.SetLightLevel(light);
        plant.SetHeatLevel(heat);
    }
}
