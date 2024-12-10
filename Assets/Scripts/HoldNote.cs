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
