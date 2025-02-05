using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public TextAsset[] jsonFiles;
    private TextAsset currentJsonFile;

    //Note Variables
    private GameObject currentNote;
    private int blueNoteCount;
    private int yellowNoteCount;
    private int greenNoteCount;
    private int redNoteCount;
    private float len;

    // Game Manager
    [SerializeField] private GameObject gameManager;

    // Note Prefabs
    [SerializeField] private GameObject bluePrefab;
    [SerializeField] private GameObject yellowPrefab;
    [SerializeField] private GameObject greenPrefab;
    [SerializeField] private GameObject redPrefab;
    [SerializeField] private GameObject blueHoldPrefab;
    [SerializeField] private GameObject yellowHoldPrefab;
    [SerializeField] private GameObject greenHoldPrefab;
    [SerializeField] private GameObject redHoldPrefab;

    // Note Empty Game Objects
    [SerializeField] private GameObject blueNotes;
    [SerializeField] private GameObject yellowNotes;
    [SerializeField] private GameObject greenNotes;
    [SerializeField] private GameObject redNotes;

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
        foreach (Note note in notes.notes)
        {
            if (note.time_up == "")
            {
                if (note.key == "Left")
                {
                    blueNoteCount++;
                    currentNote = Instantiate(bluePrefab, new Vector3(float.Parse(note.time_down) + 5f, 0.8f, 3.5f), Quaternion.identity);
                    currentNote.name = $"Blue Note ({blueNoteCount})";
                    currentNote.transform.parent = blueNotes.transform;
                    currentNote.tag = "Note";
                }
                if (note.key == "Up")
                {
                    yellowNoteCount++;
                    currentNote = Instantiate(yellowPrefab, new Vector3(float.Parse(note.time_down) + 5f, 0.8f, 1.125f), Quaternion.identity);
                    currentNote.name = $"Yellow Note ({yellowNoteCount})";
                    currentNote.transform.parent = yellowNotes.transform;
                    currentNote.tag = "Note";
                }
                if (note.key == "Down")
                {
                    greenNoteCount++;
                    currentNote = Instantiate(greenPrefab, new Vector3(float.Parse(note.time_down) + 5f, 0.8f, -1.125f), Quaternion.identity);
                    currentNote.name = $"Green Note ({greenNoteCount})";
                    currentNote.transform.parent = greenNotes.transform;
                    currentNote.tag = "Note";
                }
                if (note.key == "Right")
                {
                    redNoteCount++;
                    currentNote = Instantiate(redPrefab, new Vector3(float.Parse(note.time_down) + 5f, 0.8f, -3.5f), Quaternion.identity);
                    currentNote.name = $"Red Note ({redNoteCount})";
                    currentNote.transform.parent = redNotes.transform;
                    currentNote.tag = "Note";
                }
            }
            else
            {
                if (note.key == "Left")
                {
                    blueNoteCount++;
                    Debug.Log(note.time_up);
                    len = float.Parse(note.time_up) - float.Parse(note.time_down);
                    currentNote = Instantiate(blueHoldPrefab, new Vector3(float.Parse(note.time_up) - (len / 2) + 5f, 0.8f, 3.5f), Quaternion.identity);
                    currentNote.name = $"Blue Note ({blueNoteCount})";
                    currentNote.transform.parent = blueNotes.transform;
                    currentNote.tag = "HoldNote";
                    currentNote.GetComponent<BoxCollider>().size = new Vector3(len * 2, 1, 1);
                    foreach (Transform childTransform in currentNote.transform)
                    {
                        if (childTransform.name == "Base")
                        {
                            childTransform.transform.localScale = new Vector3(len, 1, 0.2f);

                        }
                        else
                        {
                            childTransform.transform.localScale = new Vector3(len - .25f, 1, 0.2f);
                        }
                    }

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