using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float NoteSpeed = 50f;
    public GameObject Notes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Notes.transform.position -= new Vector3(NoteSpeed * Time.deltaTime, 0f, 0f);
    }
}
