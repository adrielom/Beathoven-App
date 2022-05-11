namespace Beathoven.Core.Notes
{
    using Beathoven.Core.Staff;
    using Beathoven.Core.Time;
    using UnityEngine;
    class MusicNoteFacade
    {
        private readonly INoteTime _noteTime;
        private readonly Transform _staffTransform;
        const string NOTE_PATH = "Prefabs/Note";
        const string NOTE_TIMES_fOLDER = "Images/SVGs/Notes";
        public MusicNoteFacade(INoteTime noteTime, Transform staffTransform)
        {
            this._noteTime = noteTime;
            this._staffTransform = staffTransform;
        }

        public GameObject InstantiateNote(Vector3 position)
        {
            GameObject freshNote = GameObject.Instantiate(Resources.Load(NOTE_PATH, typeof(GameObject))) as GameObject;
            Sprite sprite = Resources.Load($"{NOTE_TIMES_fOLDER}/{_noteTime.imagePath}", typeof(Sprite)) as Sprite;
            freshNote.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            freshNote.transform.position = position;
            freshNote.transform.SetParent(_staffTransform);
            return freshNote;
        }


    }
}