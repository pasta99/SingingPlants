using System;
using System.Collections;
using System.Linq;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Standards;
using UnityEngine;

public class MidiReader : MonoBehaviour
{
    LibPdInstance pd;
    // Replace with the path to your MIDI file in the Assets folder
    public string midiFileName = "Plantasia.mid";
    private float tickTime;
    public float speed;

    public int tracknum;
    public int channel;

    void Start()
    {
        pd = transform.GetComponent<LibPdInstance>();

        // Load MIDI file
        MidiFile midiFile = MidiFile.Read($"Assets/{midiFileName}");

        // Display information about the MIDI file
        Debug.Log($"Format: {midiFile.OriginalFormat}");
        // Debug.Log($"Division: {midiFile.Division}");
        // int ticksPerQuarterNote = midiFile.TimeDivision.TicksPerQuarterNote();
        Debug.Log(midiFile.TimeDivision);
        var tempoMap = midiFile.GetTempoMap();
        // Some time in MIDI ticks (we assume time division of a MIDI file is "ticks per quarter note")
        long ticks = 1;

        // Convert ticks to metric time

        MetricTimeSpan metricTime = TimeConverter.ConvertTo<MetricTimeSpan>(ticks, tempoMap);
         tickTime = (float) metricTime.TotalSeconds;

        // Display information about each track
        for (int i = 0; i < midiFile.GetTrackChunks().Count(); i++)
        {
            TrackChunk trackChunk = midiFile.GetTrackChunks().ElementAt(i);
            if (i == tracknum) {
            //     foreach (var eventItem in trackChunk.Events)
            // {
            //     Debug.Log($"  {eventItem}");
            // }
                var coroute = PlayTrack(trackChunk);
                StartCoroutine(coroute);
            }
        }
    }


    IEnumerator PlayTrack(TrackChunk trackChunk) {

        foreach (var eventItem in trackChunk.Events) {
            Debug.Log(eventItem);
        }
        yield return new WaitForSeconds(1);
        // int c = 0;
        // foreach (var eventItem in trackChunk.Events)
        //     {
        //         if (eventItem is NoteOnEvent no) {
        //             Debug.Log(no.DeltaTime);
        //             break;
        //      c++;}
        //         }
        //      Debug.Log(c);
        //     foreach (var eventItem in trackChunk.Events)
        //     {
        //         // Calculate time in seconds
        //         float deltaTimeInSeconds = eventItem.DeltaTime * tickTime * speed;// * (currentTempo / 1000000.0));
        //         // Debug.Log(eventItem.DeltaTime);
        //         if (eventItem is NoteOnEvent noteOnEvent)
        //         {
        //             yield return new WaitForSeconds(deltaTimeInSeconds);
        //             byte noteNumber = noteOnEvent.NoteNumber;
        //             byte velocity = noteOnEvent.Velocity;
        //             pd.SendMidiNoteOn(channel, noteNumber, velocity);
        //             Debug.Log("Sent on");
        //         }
        //         if (eventItem is NoteOffEvent noteOffEvent) {
        //             yield return new WaitForSeconds(deltaTimeInSeconds);
        //             pd.SendMidiNoteOn(channel, noteOffEvent.NoteNumber, 0);
        //             Debug.Log("Sent off");
        //         }
        //     }
    }
}
