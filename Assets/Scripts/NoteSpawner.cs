using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public TextAsset[] jsonFiles;
    private TextAsset currentJsonFile;

    // Note Prefabs
    [SerializeField] private GameObject bluePrefab;
    [SerializeField] private GameObject yellowPrefab;
    [SerializeField] private GameObject greenPrefab;
    [SerializeField] private GameObject redPrefab;

    [System.Serializable]
    private class NoteArray
    {
        public Note[] notes;
    }
    
    [System.Serializable]
    private class Note
    {
        public string key;
        public string time_down;
        public string time_up;

        public Note(string key, string time_down, string time_up)
        {
            this.key = key;
            this.time_down = time_down;
            this.time_up = time_up;
        }
    }

    void AssignCurrentFile()
    {
        currentJsonFile = jsonFiles[0];
    }

    void SpawnNotes()
    {
        NoteArray notes = JsonUtility.FromJson<NoteArray>(currentJsonFile.ToString());
        Debug.Log(notes.notes[1]);
        foreach (Note note in notes.notes)
        {
            if (note.time_up != null)
            {
                if (note.key == "left")
                {
                    var spawn = Instantiate(bluePrefab, new Vector3(float.Parse(note.time_down), 0.8f, 3.5f), Quaternion.identity);
                }
            }
        }
    }

    void Start()
    {
        AssignCurrentFile();
        SpawnNotes();
    }
}