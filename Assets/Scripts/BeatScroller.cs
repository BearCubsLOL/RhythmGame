using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [SerializeField]
    private float NoteSpeed = 50f;
    [SerializeField]
    private GameObject Notes;

    public bool gameActive = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            Notes.transform.position -= new Vector3(NoteSpeed * Time.deltaTime, 0f, 0f);
        }
        else
        {

        }
    }
}
