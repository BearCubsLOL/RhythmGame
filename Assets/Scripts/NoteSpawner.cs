using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public TextAsset jsonFile;

    void Start()
    {
        Debug.Log(jsonFile);
    }
}