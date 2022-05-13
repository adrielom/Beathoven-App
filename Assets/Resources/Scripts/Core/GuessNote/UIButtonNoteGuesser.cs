namespace Beathoven.Core.GuessNote
{
    using Beathoven.Core.Notes;
    using UnityEngine;
    using TMPro;
    using System;
    using Beathoven.Utils;
    using Beathoven.Core.Note;
    using System.Collections.Generic;
    using UnityEngine.UI;
    using Beathoven.Core.Staff;

    public class UIButtonNoteGuesser : MonoBehaviour
    {
        [SerializeField]
        ChromaticNotesEnumeration note;
        string className;
        IMusicNote noteInstance;
        MusicNoteEnumerationParser parser = new MusicNoteEnumerationParser();
        Button UIButton;
        [SerializeField]
        public static Func<IMusicNote, bool> onMatchingNotes;
        public static Action onRightNoteSelected;

        void Start()
        {
            SetCorrespondingNoteInfo();
            SetUIButtonText();
            UIButton = GetComponent<Button>();
            UIButton?.onClick.AddListener(MatchNotes);
        }

        void SetCorrespondingNoteInfo()
        {
            noteInstance = parser.NoteEnumerationToMusicNote(note);
            className = parser.GetClassName(note);
        }

        void SetUIButtonText()
        {
            TMP_Text buttonOutput = GetComponentInChildren<TMP_Text>();
            if (!className.Contains("Accident"))
            {
                buttonOutput.text = noteInstance.name;
                return;
            }
            buttonOutput.text = Configs.DEFAULT_ACCIDENT == "sharp" ? ((INoteAccident)(noteInstance)).sharp : ((INoteAccident)(noteInstance)).flat;
        }

        void MatchNotes()
        {
            Debug.Log($"Fired ${noteInstance.name} note");
            if (onMatchingNotes?.Invoke(noteInstance) == true)
            {
                Debug.Log("Equal notes!");
                onRightNoteSelected?.Invoke();
            }
            else
            {
                Debug.Log("Different notes!");

            }
        }

    }

}