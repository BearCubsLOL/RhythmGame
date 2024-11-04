using UnityEngine;

public class IsNoteFirst : MonoBehaviour
{
    public string[] blueNotes;
    public string[] yellowNotes;
    public string[] greenNotes;
    public string[] redNotes;
    public int neededBluePos;
    public int neededYellowPos;
    public int neededGreenPos;
    public int neededRedPos;

    [SerializeField] private GameObject note;

    void ArrayAssign()
    {
        if (transform.position.z == 3.5)
        {
            if (blueNotes.Length == 0)
            {
                blueNotes[blueNotes.Length] = note.name;
            }
            else
            {
                blueNotes[blueNotes.Length - 1] = note.name;
            }
        }
        if (transform.position.z == 1.125)
        {
            if (yellowNotes.Length == 0)
            {
                yellowNotes[yellowNotes.Length] = note.name;
            }
            else
            {
                yellowNotes[yellowNotes.Length - 1] = note.name;
            }
        }
        if (transform.position.z == -1.125)
        {
            if (greenNotes.Length == 0)
            {
                greenNotes[greenNotes.Length] = note.name;
            }
            else
            {
                greenNotes[greenNotes.Length - 1] = note.name;
            }
        }
        if (transform.position.z == -3.5)
        {
            if (redNotes.Length == 0)
            {
                redNotes[redNotes.Length] = note.name;
            }
            else
            {
                redNotes[redNotes.Length - 1] = note.name;
            }
        }
    }

    void FrontCheck()
    {
        ArrayAssign();
        if (blueNotes[neededBluePos] == note.name)
        {
            note.GetComponent<Note>().isFront = true;
        }
        if (yellowNotes[neededYellowPos] == note.name)
        {
            note.GetComponent<Note>().isFront = true;
        }
        if (greenNotes[neededGreenPos] == note.name)
        {
            note.GetComponent<Note>().isFront = true;
        }
        if (redNotes[neededRedPos] == note.name)
        {
            note.GetComponent<Note>().isFront = true;
        }
    }

    void Update()
    {
        FrontCheck();
    }
}