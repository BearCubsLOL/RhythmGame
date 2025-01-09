using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldNote : MonoBehaviour
{
    [SerializeField] private bool canBePressed = false;
    public bool isHoldFront = false;
    [SerializeField] private GameObject trigger;
    [SerializeField] private bool wasPressed = false;
    [SerializeField] private GameObject gameManager;
    private bool alreadyRan = false;

    private float pressDistance = 0f;
    private float releaseDistance = 0f;

    private float len = 3f;

    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject holdNote;
    [SerializeField] private GameObject holdNoteTop;
    [SerializeField] private GameObject holdNoteBase;



    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void GameOver()
    {
        if (holdNote.CompareTag("Last HoldNote"))
        {
            gameManager.GetComponent<BeatScroller>().gameOver = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == trigger)
        {
            canBePressed = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == trigger)
        {
            canBePressed = false;
            if (!wasPressed)
            {
                Debug.Log("Miss");
                UI.GetComponent<UI>().streak = 0;
                UI.GetComponent<UI>().multiplier = 0;
                gameManager.GetComponent<Stats>().missedHits += 1;
                gameManager.GetComponent<Stats>().blueNotes.Remove(holdNote.name);
            }
            else
            {

            }
            GameOver();
            if (transform.position.z == 3.5)
            {
                Object.Destroy(holdNote);
            }
            if (transform.position.z == 1.125)
            {
                Object.Destroy(holdNote);
            }
            if (transform.position.z == -1.125)
            {
                Object.Destroy(holdNote);
            }
            if (transform.position.z == -3.5)
            {
                Object.Destroy(holdNote);
            }
        }
    }

    public void Pressing()
    {
        if (canBePressed)
        {
            if (Input.GetKeyDown(KeyCode.D) && transform.position.z == 3.5 && isHoldFront)
            {
                wasPressed = true;
                pressDistance = transform.position.x;
                gameManager.GetComponent<Stats>().blueNotes.Remove(holdNote.name);
                anim.SetTrigger("Holding");
            }
            if (Input.GetKeyDown(KeyCode.F) && transform.position.z == 1.125 && isHoldFront)
            {
                wasPressed = true;
                pressDistance = transform.position.x;
                gameManager.GetComponent<Stats>().yellowNotes.Remove(holdNote.name);
                anim.SetTrigger("Holding");
            }
            if (Input.GetKeyDown(KeyCode.J) && transform.position.z == -1.125 && isHoldFront)
            {
                wasPressed = true;
                pressDistance = transform.position.x;
                gameManager.GetComponent<Stats>().greenNotes.Remove(holdNote.name);
                anim.SetTrigger("Holding");
            }
            if (Input.GetKeyDown(KeyCode.K) && transform.position.z == -3.5 && isHoldFront)
            {
                wasPressed = true;
                pressDistance = transform.position.x;
                gameManager.GetComponent<Stats>().redNotes.Remove(holdNote.name);
                anim.SetTrigger("Holding");
            }
        }
        if (wasPressed)
        {
            if (transform.position.x - pressDistance >= len)
            {
                releaseDistance = transform.position.x;
            }
            if (Input.GetKeyUp(KeyCode.D) && transform.position.z == 3.5)
            {
                releaseDistance = transform.position.x;
            }
            if (Input.GetKeyUp(KeyCode.F) && transform.position.z == 1.125)
            {
                releaseDistance = transform.position.x;
            }
            if (Input.GetKeyUp(KeyCode.J) && transform.position.z == -1.125)
            {
                releaseDistance = transform.position.x;
            }
            if (Input.GetKeyUp(KeyCode.K) && transform.position.z == -3.5)
            {
                releaseDistance = transform.position.x;
            }
        }
    }

    public void ScoreSystem()
    {
        if (wasPressed && !alreadyRan)
        {
            alreadyRan = true;
            
        }
    }

    void Update()
    {
        Pressing();

        ScoreSystem();
    }
}
