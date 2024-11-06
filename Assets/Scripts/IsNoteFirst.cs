using System.Collections.Generic;
using UnityEngine;

public class IsNoteFirst : MonoBehaviour
{
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject gameManager;

    void ArrayAssign()
    {
        if (!(gameManager.GetComponent<Stats>().blueNotes.Contains(note.name) || gameManager.GetComponent<Stats>().yellowNotes.Contains(note.name) || gameManager.GetComponent<Stats>().greenNotes.Contains(note.name) || gameManager.GetComponent<Stats>().redNotes.Contains(note.name)))
        {
            if (note.transform.position.x > 6.5)
            {
                if (transform.position.z == 3.5)
                {
                    gameManager.GetComponent<Stats>().blueNotes.Add(note.name);
                }
                if (transform.position.z == 1.125)
                {
                    gameManager.GetComponent<Stats>().yellowNotes.Add(note.name);
                }
                if (transform.position.z == -1.125)
                {
                    gameManager.GetComponent<Stats>().greenNotes.Add(note.name);
                }
                if (transform.position.z == -3.5)
                {
                    gameManager.GetComponent<Stats>().redNotes.Add(note.name);
                }
            }
        }
    }

    void FrontCheck()
    {
        gameManager.GetComponent<Stats>().blueNotes.Sort();
        gameManager.GetComponent<Stats>().yellowNotes.Sort();
        gameManager.GetComponent<Stats>().greenNotes.Sort();
        gameManager.GetComponent<Stats>().redNotes.Sort();
        ArrayAssign();
        if (gameManager.GetComponent<Stats>().blueNotes.Count >= 1)
        {
            if (note.name == gameManager.GetComponent<Stats>().blueNotes[0])
            {
                note.GetComponent<Note>().isFront = true;
            }
        }
        if (gameManager.GetComponent<Stats>().yellowNotes.Count >= 1)
        {
            if (note.name == gameManager.GetComponent<Stats>().yellowNotes[0])
            {
                note.GetComponent<Note>().isFront = true;
            }
        }
        if (gameManager.GetComponent<Stats>().greenNotes.Count >= 1)
        {
            if (note.name == gameManager.GetComponent<Stats>().greenNotes[0])
            {
                note.GetComponent<Note>().isFront = true;
            }
        }
        if (gameManager.GetComponent<Stats>().redNotes.Count >= 1)
        {
            if (note.name == gameManager.GetComponent<Stats>().redNotes[0])
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