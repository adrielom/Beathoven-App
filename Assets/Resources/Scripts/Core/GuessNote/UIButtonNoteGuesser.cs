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
        MusicNote noteInstance;
        MusicNoteEnumerationParser parser = new MusicNoteEnumerationParser();
        Button UIButton;
        [SerializeField]
        public static Func<MusicNote, bool> onMatchingNotes;
        public static Action onRightNoteSelected;
        public static Action onWrongNoteSelected;

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
            if (onMatchingNotes?.Invoke(noteInstance) == true)
            {
                Debug.Log("Equal notes!");
                onRightNoteSelected?.Invoke();
            }
            else
            {
                Debug.Log("Different notes!");
                onWrongNoteSelected?.Invoke();
            }
        }

    }

}