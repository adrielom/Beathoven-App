namespace Beathoven.Core.Notes
{
    using Beathoven.Core.Staff;
    using Beathoven.Core.Time;
    using UnityEngine;
    class MusicNoteFacade
    {
        private INoteTime _noteTime;
        const string NOTE_PATH = "Prefabs/Note";
        const string NOTE_TIMES_fOLDER = "Images/SVGs/Notes";
        public MusicNoteFacade(INoteTime noteTime)
        {
            this._noteTime = noteTime;
        }

        public GameObject InstantiateNote(Vector3 position)
        {
            GameObject freshNote = GameObject.Instantiate(Resources.Load(NOTE_PATH, typeof(GameObject))) as GameObject;
            Sprite sprite = Resources.Load($"{NOTE_TIMES_fOLDER}/{_noteTime.imagePath}", typeof(Sprite)) as Sprite;
            freshNote.GetComponent<SpriteRenderer>().sprite = sprite;
            freshNote.transform.position = position;
            return freshNote;
        }


    }
}