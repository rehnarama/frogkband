using System;
using System.Collections.Generic;
using System.Linq;
using FluidMidi;
using IntervalTree;
using MidiParser;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class RythmManager : MonoBehaviour
{
    public Note NotePrefab;
    public StreamingAsset Song;
    public float NoteOffset;

    public List<Instrument> Instruments;

    private List<Note> notes = new List<Note>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var midi = new MidiFile(Song.GetFullPath());
        float bpm = 120;
        float secondsPerQuarterNote = 60 / bpm;
        float secondsPerTick = secondsPerQuarterNote / midi.TicksPerQuarterNote;

        foreach (var track in midi.Tracks)
        {
            foreach (var midiEvent in track.MidiEvents)
            {
                if (midiEvent.MidiEventType == MidiEventType.NoteOn)
                {
                    Instrument instrument = Instruments[track.Index % Instruments.Count];
                    var note = Instantiate(NotePrefab);
                    note.Time = midiEvent.Time * secondsPerTick + NoteOffset;
                    note.TargetPosition = instrument.transform.position;
                    note.GetComponent<Rigidbody>().MovePosition(instrument.transform.position - Vector3.back);
                    note.UpdateTime(0f);
                    notes.Add(note);
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        notes = notes.Where(note => !note.IsDestroyed()).ToList();

        foreach (var note in notes)
        {
            note.UpdateTime(Time.fixedTime);
        }

    }
}
