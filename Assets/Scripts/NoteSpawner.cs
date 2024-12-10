using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public TextAsset[] jsonFiles;
    private TextAsset currentJsonFile;

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

    void MakeObject()
    {
        AssignCurrentFile();

        NoteArray notes = JsonUtility.FromJson<NoteArray>(currentJsonFile.ToString());
        Debug.Log(JsonUtility.ToJson(notes));
    }

    void SpawnNotes()
    {

    }

    void Start()
    {
        MakeObject();
    }
}