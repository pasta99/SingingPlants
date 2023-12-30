using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public float lightLevel = 1;
    public float moistureLevel = 0;
    public float temperatureLevel = 0;

    public float optimalLightLevel = 0.5f; 

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
        instrument.SetVolume(lightLevel);
        instrument.SetMoistureScore(moistureLevel);
        instrument.SetTemperatureScore(temperatureLevel);

        Debug.Log($"Level {lightLevel}");
        Debug.Log(GetLightScore());
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
}
