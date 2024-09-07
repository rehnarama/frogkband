using System.Collections.Generic;
using IntervalTree;
using NUnit.Framework;
using UnityEngine;

struct NoteOld
{
}

struct Song
{
    public List<IIntervalTree<ulong, NoteOld>> tracks;
}

public class RythmManager : MonoBehaviour
{
    public GameObject NotePrefab;

    private Song song;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var trackA = new IntervalTree<ulong, NoteOld>();
        var trackB = new IntervalTree<ulong, NoteOld>();
        var trackC = new IntervalTree<ulong, NoteOld>();
        var trackD = new IntervalTree<ulong, NoteOld>();
        trackA.Add(1, 2, new NoteOld());
        trackB.Add(2, 2, new NoteOld());
        trackC.Add(3, 5, new NoteOld());
        trackD.Add(4, 10, new NoteOld());

        song = new Song()
        {
            tracks = new List<IIntervalTree<ulong, NoteOld>>
            {
                trackA
            }
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
