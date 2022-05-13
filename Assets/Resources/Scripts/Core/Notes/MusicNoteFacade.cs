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
        private readonly INoteTime _noteTime;
        private readonly Transform _staffTransform;
        private readonly IGameType _gameType;
        const string NOTE_PATH = "Prefabs/Note";
        const string NOTE_TIMES_fOLDER = "Images/SVGs/Notes";
        public MusicNoteFacade(INoteTime noteTime, Transform staffTransform, IGameType gameType)
        {
            this._noteTime = noteTime;
            this._staffTransform = staffTransform;
            this._gameType = gameType;
        }

        public GameObject InstantiateNote(Vector3 position)
        {
            GameObject freshNote = null;
            if (_staffTransform.childCount + 1 >= _gameType.notePoolCount)
                freshNote = GameObject.Instantiate(Resources.Load(NOTE_PATH, typeof(GameObject))) as GameObject;
            else
                freshNote = HandleObjectPooling();
            Sprite sprite = Resources.Load($"{NOTE_TIMES_fOLDER}/{_noteTime.imagePath}", typeof(Sprite)) as Sprite;
            freshNote.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            freshNote.transform.position = position;
            freshNote.transform.SetParent(_staffTransform);
            return freshNote;
        }

        private GameObject HandleObjectPooling()
        {
            List<Transform> notesInPool = new List<Transform>(_staffTransform.GetComponentsInChildren<Transform>());
            Transform randomElement = notesInPool[UnityEngine.Random.Range(0, notesInPool.Count)];
            return randomElement.gameObject;
        }
    }
}