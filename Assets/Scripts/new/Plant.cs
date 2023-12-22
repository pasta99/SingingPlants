using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public float lightLevel = 1;
    public float moistureLevel = 0;
    private float humidityLevel = 0;
    public float temperatureLevel = 0;

    private MidiInstrument instrument; 
    // Start is called before the first frame update
    void Start()
    {
        instrument = gameObject.GetComponentInChildren<MidiInstrument>();
    }

    // Update is called once per frame
    void Update()
    {
        instrument.SetVolume(lightLevel);
        instrument.SetMoistureScore(moistureLevel);
        instrument.SetTemperatureScore(temperatureLevel);
    }

    public void NoteOn(int note, int velocity) {
        instrument.NoteOn(note, velocity);
    }
    public void NoteOff(int note) {
        instrument.NoteOff(note);
    }

    public void SetLightLevel(float lightLevel){
        this.lightLevel = lightLevel;
    }
}
