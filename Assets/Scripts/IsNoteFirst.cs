using System.Collections.Generic;
using UnityEngine;

public class IsNoteFirst : MonoBehaviour
{
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject gameManager;

    void FrontCheck()
    {
        if (gameManager.GetComponent<Stats>().blueNotes.Count >= 1)
        {
            if (note.name == gameManager.GetComponent<Stats>().blueNotes[0] && note.CompareTag("HoldNote") || note.CompareTag("Last HoldNote"))
            {
                note.GetComponent<HoldNote>().isHoldFront = true;
            }
            if (note.name == gameManager.GetComponent<Stats>().blueNotes[0] && note.CompareTag("Note") || note.CompareTag("Last Note"))
            {
                note.GetComponent<Note>().isFront = true;
            }
        }
        if (gameManager.GetComponent<Stats>().yellowNotes.Count >= 1)
        {
            if (note.name == gameManager.GetComponent<Stats>().yellowNotes[0] && note.CompareTag("HoldNote") || note.CompareTag("Last HoldNote"))
            {
                note.GetComponent<HoldNote>().isHoldFront = true;
            }
            if (note.name == gameManager.GetComponent<Stats>().yellowNotes[0] && note.CompareTag("Note") || note.CompareTag("Last Note"))
            {
                note.GetComponent<Note>().isFront = true;
            }
        }
        if (gameManager.GetComponent<Stats>().greenNotes.Count >= 1)
        {
            if (note.name == gameManager.GetComponent<Stats>().greenNotes[0] && note.CompareTag("HoldNote") || note.CompareTag("Last HoldNote"))
            {
                note.GetComponent<HoldNote>().isHoldFront = true;
            }
            if (note.name == gameManager.GetComponent<Stats>().greenNotes[0] && note.CompareTag("Note") || note.CompareTag("Last Note"))
            {
                note.GetComponent<Note>().isFront = true;
            }
        }
        if (gameManager.GetComponent<Stats>().redNotes.Count >= 1)
        {
            if (note.name == gameManager.GetComponent<Stats>().redNotes[0] && note.CompareTag("HoldNote") || note.CompareTag("Last HoldNote"))
            {
                note.GetComponent<HoldNote>().isHoldFront = true;
            }
            if (note.name == gameManager.GetComponent<Stats>().redNotes[0] && note.CompareTag("Note") || note.CompareTag("Last Note"))
            {
                note.GetComponent<Note>().isFront = true;
            }
        }
    }

    void Update()
    {
        FrontCheck();
    }
}