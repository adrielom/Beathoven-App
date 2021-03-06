namespace Beathoven.Core.Notes
{
    using System;
    using System.Collections.Generic;
    using Beathoven.Core.GameType;
    using Beathoven.Core.Staff;
    using Beathoven.Core.Time;
    using UnityEngine;

    class MusicNoteFacade
    {
        const string NOTE_TIMES_fOLDER = "Images/SVGs/Notes";
        const string MATERIALS_fOLDER = "Materials";
        private readonly Transform _staffTransform;
        private readonly IStaff _staff;
        const string NOTE_PATH = "Prefabs/Note";
        private Material vectorMaterial;
        private MusicNote _note;
        public MusicNoteFacade(MusicNote note, Transform staffTransform, IStaff staff)
        {
            this._note = note;
            this._staffTransform = staffTransform;
            this._staff = staff;
            this.vectorMaterial = Resources.Load($"{MATERIALS_fOLDER}/Unlit_Vector", typeof(Material)) as Material;
        }

        public GameObject InstantiateNote(Vector3 position)
        {
            GameObject freshNote = null;
            if (_staffTransform.childCount + 1 <= _staff.gameType.notePoolCount)
            {
                freshNote = GameObject.Instantiate(Resources.Load(NOTE_PATH, typeof(GameObject))) as GameObject;
                SetNoteOverviewClass(_note, freshNote);
                SetNoteSprite(freshNote);
                SetNoteTransformPosition(position, freshNote);
                SetNoteTransformParent(freshNote);
            }
            else
            {
                freshNote = HandleObjectPooling();
                SetNoteOverviewClass(_note, freshNote);
                SetNoteTransformPosition(position, freshNote);
            }
            return freshNote;

        }

        void SetNoteOverviewClass(MusicNote note, GameObject freshNote)
        {
            NoteOverview overview = null;
            overview = freshNote.GetComponent<NoteOverview>() == null ? freshNote.AddComponent<NoteOverview>() : freshNote.GetComponent<NoteOverview>();
            overview.musicNote = note;
        }

        void SetNoteSprite(GameObject freshNote)
        {
            Sprite sprite = Resources.Load($"{NOTE_TIMES_fOLDER}/{_note.noteTime.imagePath}", typeof(Sprite)) as Sprite;
            freshNote.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            freshNote.GetComponentInChildren<SpriteRenderer>().material = vectorMaterial;
            freshNote.GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }

        private void SetNoteTransformPosition(Vector3 position, GameObject freshNote)
        {
            freshNote.transform.position = position;
        }

        void SetNoteTransformParent(GameObject freshNote)
        {
            freshNote.transform.SetParent(_staffTransform);
        }

        private GameObject HandleObjectPooling()
        {

            List<NoteOverview> notesInPool = new List<NoteOverview>(_staffTransform.GetComponentsInChildren<NoteOverview>());
            Transform randomElement = notesInPool[UnityEngine.Random.Range(0, notesInPool.Count - 1)].transform;
            return randomElement.gameObject;
        }
    }
}