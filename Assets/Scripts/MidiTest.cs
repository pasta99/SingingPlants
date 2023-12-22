using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MidiTest : MonoBehaviour
{
    LibPdInstance pd;
    System.Random random;

    Recorder recorder;
    bool recording = false;
    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        pd = transform.GetComponent<LibPdInstance>();
        recorder = transform.GetComponent<Recorder>();

        // StartCoroutine(Play());
    }

    public void StartRecording() {
        recorder.StartRecording();
        recording = true;
    }

    public void StopRecording() {
        recorder.StopRecording();
        recording = false;
    }

    public void StartLoop() {
        recorder.StartLooping();
    }

    public void StopLoop() {
        recorder.StopLooping();
    }

    public void PlayMidi(int midi) {
        pd.SendFloat("midi", midi);
        if (recording) {
            recorder.Record(()=>this.PlayMidi(midi));
        }
    }

    IEnumerator Play()
    {
        while (true)
        {
            int randomNumber = random.Next(60, 73);

            pd.SendFloat("midi", randomNumber);

            // Wait for 1 second before the next iteration
            yield return new WaitForSeconds(1f);
        }
    }

    void ManageInputs() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (recording) {
                StopRecording();
                StartLoop();
            }
            else {
                StopLoop();
                StartRecording();
            }
        }

        int midiKey = -1;
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                // Set midiKey based on the pressed number key
                midiKey = 60 + i;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            // Set midiKey based on the pressed number key
            midiKey = 69;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            // Set midiKey based on the pressed number key
            midiKey = 70;
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            // Set midiKey based on the pressed number key
            midiKey = 71;
        }
        if (midiKey != -1) {
            PlayMidi(midiKey);
        }
    }

    void Update() {
        ManageInputs();
    }

    private void OnMouseDown()
    {
        // Code to execute when the sprite is clicked
        Debug.Log("Sprite Clicked!");
    }
}
