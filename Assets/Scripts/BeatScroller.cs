using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [SerializeField]
    private float noteSpeed = 50f;
    [SerializeField]
    private GameObject notes;

    public bool gameActive = false;

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            notes.transform.position -= new Vector3(noteSpeed * Time.deltaTime, 0f, 0f);
        }
        else
        {

        }
    }
}
