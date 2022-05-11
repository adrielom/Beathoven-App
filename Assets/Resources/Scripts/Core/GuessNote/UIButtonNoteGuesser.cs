using System.Collections;
using System.Collections.Generic;
using Beathoven.Core.Notes;
using UnityEngine;
using TMPro;
using System;

public class UIButtonNoteGuesser : MonoBehaviour
{
    [SerializeField]
    ChromaticNotesEnumeration note;

    void Start()
    {
        TMP_Text buttonOutput = GetComponentInChildren<TMP_Text>();
        buttonOutput.text = Enum.GetName(typeof(NaturalNotesEnumeration), note);
    }

    void MatchingNotes()
    {

    }

}
