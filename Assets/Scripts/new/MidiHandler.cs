using System;
using System.Linq;
using System.Text;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Standards;
using UnityEngine;

public class MidiHandler : MonoBehaviour, IOutputDevice 
{
    public event EventHandler<MidiEventSentEventArgs> EventSent;

    public GameObject[] plants;
    private Plant[] instruments;

    public void PrepareForEventsSending()
    {
    }

    public void Start() {
        instruments = new Plant[plants.Length];
        for (int i = 0; i < plants.Length; i++) {
            instruments[i] = plants[i].GetComponent<Plant>();
        }
    }

    public void SendEvent(MidiEvent midiEvent)
    {
        if (midiEvent is NoteOnEvent noteOnEvent)
        {
            instruments[noteOnEvent.Channel].NoteOn(noteOnEvent.NoteNumber, noteOnEvent.Velocity);
        }
        if (midiEvent is NoteOffEvent noteOffEvent) 
        {
            instruments[noteOffEvent.Channel].NoteOff(noteOffEvent.NoteNumber);
        }
    }

    public void Dispose()
    {
    }
}