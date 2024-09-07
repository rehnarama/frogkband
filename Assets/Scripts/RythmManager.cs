using System;
using System.Collections.Generic;
using System.Linq;
using IntervalTree;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class RythmManager : MonoBehaviour
{
    public Note NotePrefab;

    public List<Instrument> Instruments;

    private List<Note> notes = new List<Note>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            Instrument instrument = Instruments[Random.Range(0, Instruments.Count)];
            int delay = i;
            var note = Instantiate(NotePrefab);
            note.Time = delay + 10;
            note.TargetPosition = instrument.transform.position;
            note.GetComponent<Rigidbody>().MovePosition(instrument.transform.position);
            note.UpdateTime(0f);
            notes.Add(note);
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
