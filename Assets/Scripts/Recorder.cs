using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private List<(float Timestamp, Action Action)> recordedActions = new List<(float, Action)>();

    private bool isRecording = false;
    private float recordStart;
    private float recordEnd;
    public bool looping;

    public void Record(Action actionToRecord)
    {
        if (isRecording)
        {
            float timestamp = Time.time - recordStart;
            recordedActions.Add((timestamp, actionToRecord));
        }
    }

    public void StartRecording()
    {
        recordedActions.Clear();
        isRecording = true;
        recordStart = Time.time;
    }

    public void StopRecording()
    {
        isRecording = false;
        recordEnd = Time.time - recordStart;
    }

    public void StartLooping() {
        looping = true;
        Replay();
    }

    public void StopLooping() {
        looping = false;
    }

    private void Replay()
    {
        if (!looping) {
            return;
        }
        foreach (var (timestamp, action) in recordedActions)
        {
            StartCoroutine(CallAction(action, timestamp));
        }
        StartCoroutine(CallAction(() => Replay(), recordEnd));
    }

    IEnumerator CallAction(Action action, float delay) {
        yield return new WaitForSeconds(delay);
        if (looping) {
            action.Invoke();
        }
    }
}
