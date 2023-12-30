using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public float lightLevel = 1;
    public float moistureLevel = 0;
    public float temperatureLevel = 0;

    public float optimalLightLevel = 0.5f; 
    public float optimalMoistureLevel = 0.5f;
    public float optimalTemperatureLevel = 0.5f; 

    private MidiInstrument instrument; 
    private Actuator actuator; 
    // Start is called before the first frame update
    void Start()
    {
        instrument = gameObject.GetComponentInChildren<MidiInstrument>();
        actuator = gameObject.GetComponent<Actuator>();
    }

    // Update is called once per frame
    void Update()
    {
        instrument.SetVolume(GetLightScore());
        instrument.SetMoistureScore(GetMoistureScore());
        instrument.SetTemperatureScore(GetTemperatureScore());

        UseWater(0.03f * Time.deltaTime);
    }

    private float ScoreFunction(float x) {
        if (Mathf.Abs(x) > 1) {
            return 0; 
        }
        float y = 0.5f * Mathf.Cos(x * Mathf.PI) + 0.5f;
        return y;
    }

    public float GetLightScore() {
        float x = lightLevel - optimalLightLevel;
        return ScoreFunction(x); 
    }

    public float GetMoistureScore() {
        float x = moistureLevel - optimalMoistureLevel;
        return ScoreFunction(x);
    }

    public float GetTemperatureScore() {
        float x = temperatureLevel - optimalTemperatureLevel;
        return ScoreFunction(x);
    }
 
    public void NoteOn(int note, int velocity) {
        instrument.NoteOn(note, velocity);
    }
    public void NoteOff(int note) {
        instrument.NoteOff(note);
    }

    public void SetLightLevel(float lightLevel){
        this.lightLevel = lightLevel;
        actuator.SetLightLevel(lightLevel);
    }
    public void SetHeatLevel(float heatLevel){
        this.temperatureLevel = heatLevel;
        actuator.SetHeatLevel(temperatureLevel);
    }
    private void UseWater(float amount) {
        AddWater(-amount);
    }

    public void AddWater(float amount) {
        moistureLevel += amount; 
        moistureLevel = Mathf.Max(0, moistureLevel);
        actuator.SetMoistureLevel(moistureLevel);
    }
}
