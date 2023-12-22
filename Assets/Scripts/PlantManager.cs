using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantType
{
    Plant1,
    Plant2,
    Plant3
}


public class PlantManager : MonoBehaviour
{
    Instrument instrument; 
    Recorder recorder; 
    bool recording = false;

    bool selected = false; 

    float lightlevel;

    GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        instrument = transform.GetComponent<Instrument>();
        recorder = transform.GetComponent<Recorder>();

        ui = transform.Find("UI").gameObject;
    }

    public void PlayMidi(int midi) {
        if (selected) {
            instrument.PlayMidi(midi);
            if (recording) {
                recorder.Record(()=>instrument.PlayMidi(midi));
            }
        }
    }

    public void StartRecording() {
        recorder.StartRecording();
        recording = true;
    }

    public void StopRecording() {
        recorder.StopRecording();
        recording = false;
    }

    public void ToggleRecording() {
        if (recording) {
            StopRecording();
        }
        else {
            StartRecording();
        }
    }

    public void StartLoop() {
        recorder.StartLooping();
    }

    public void StopLoop() {
        recorder.StopLooping();
    }

    public void Select() {
        OpenUI();
        selected = true;
    }
    public void Unselect() {
        CloseUI();
        selected = false;
    }

    public void OpenUI() {
        ui.SetActive(true);
    }
    public void CloseUI() {
        ui.SetActive(false);
    }

    public void SetLightLevel(float lightlevel) {
        this.lightlevel = lightlevel;
        instrument.SetVolume(this.lightlevel * 0.3f);
    }

    public float GetLightLevel() {
        return this.lightlevel;
    }
}
