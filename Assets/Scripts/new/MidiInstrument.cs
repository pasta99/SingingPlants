using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidiInstrument : MonoBehaviour
{
    LibPdInstance pd; 
    public int channel;
    public float maxVolume = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        pd = transform.GetComponent<LibPdInstance>();
    }

    public void NoteOn(int note, int velocity) {
        pd.SendMidiNoteOn(channel, note, velocity);
    }
    public void NoteOff(int note) {
        pd.SendMidiNoteOn(channel, note, 0);
    }

    public void SetVolume(float volume) {
        float finalVolume = Mathf.Lerp(0, maxVolume, volume);
        pd.SendFloat("volume", finalVolume);
    }

    public void SetMoistureScore(float moisture) {
        pd.SendFloat("moisture", moisture);
    }

    public void SetTemperatureScore(float temperature) {
        pd.SendFloat("temperature", temperature);
    }
}
