using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private bool canBePressed = false;
    public bool isFront = false;
    [SerializeField] private GameObject trigger;
    [SerializeField] private bool wasPressed = false;
    [SerializeField] private GameObject gameManager;
    private bool alreadyRan = false;
    private float distance = 0f;
    private float centerOfBoard = 5.00f;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject top;
    [SerializeField] private GameObject song;

    private int perfectPlusScore = 1000;
    private int perfectScore = 800;
    private int greatScore = 600;
    private int goodScore = 500;

    Animator anim;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == trigger)
        {
            canBePressed = true;
        }
    }

    void GameOver()
    {
        if (note.CompareTag("Last Note"))
        {
            gameManager.GetComponent<BeatScroller>().gameOver = true;
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
                Object.Destroy(note);
                note.GetComponent<IsNoteFirst>().neededBluePos -= 1;
            }
            if (transform.position.z == 1.125)
            {
                Object.Destroy(note);
                note.GetComponent<IsNoteFirst>().neededYellowPos -= 1;
            }
            if (transform.position.z == -1.125)
            {
                Object.Destroy(note);
                note.GetComponent<IsNoteFirst>().neededGreenPos -= 1;
            }
            if (transform.position.z == -3.5)
            {
                Object.Destroy(note);
                note.GetComponent<IsNoteFirst>().neededRedPos -= 1;
            }
        }
    }

    void Pressing()
    {
        if (canBePressed)
        {
            if (Input.GetKey(KeyCode.D) && transform.position.z == 3.5 && isFront)
            {
                wasPressed = true;
                note.GetComponent<IsNoteFirst>().neededBluePos += 1;
                anim.SetTrigger("Active");
            }
            if (Input.GetKey(KeyCode.F) && transform.position.z == 1.125 && isFront)
            {
                wasPressed = true;
                note.GetComponent<IsNoteFirst>().neededYellowPos += 1;
                anim.SetTrigger("Active");
            }
            if (Input.GetKey(KeyCode.J) && transform.position.z == -1.125 && isFront)
            {
                wasPressed = true;
                note.GetComponent<IsNoteFirst>().neededGreenPos += 1;
                anim.SetTrigger("Active");
            }
            if (Input.GetKey(KeyCode.K) && transform.position.z == -3.5 && isFront)
            {
                wasPressed = true;
                note.GetComponent<IsNoteFirst>().neededRedPos += 1;
                anim.SetTrigger("Active");
            }
        } 
    }

    void ScoreSystem()
    {
        if (wasPressed && !alreadyRan)
        {
            alreadyRan = true;
            distance = centerOfBoard - transform.position.x;
            distance = Mathf.Abs(distance);


            if (distance <= 0.25)
            {
                Debug.Log("Perfect+");
                UI.GetComponent<UI>().score += perfectPlusScore * UI.GetComponent<UI>().multiplier;
                UI.GetComponent<UI>().streak += 1;
                gameManager.GetComponent<Stats>().perfectPlusHits += 1;
            }
            else if (distance > 0.25 && distance <= 0.5)
            {
                Debug.Log("Perfect");
                UI.GetComponent<UI>().score += perfectScore;
                UI.GetComponent<UI>().streak += 1;
                gameManager.GetComponent<Stats>().perfectHits += 1;
            }
            else if (distance > 0.5 && distance <= 0.75)
            {
                Debug.Log("Great");
                UI.GetComponent<UI>().score += greatScore;
                UI.GetComponent<UI>().streak += 1;
                gameManager.GetComponent<Stats>().greatHits += 1;
            }
            else if (distance > 0.75)
            {
                Debug.Log("Good");
                UI.GetComponent<UI>().score += goodScore;
                UI.GetComponent<UI>().streak += 1;
                gameManager.GetComponent<Stats>().goodHits += 1;
            }
        }
    }

    void MultiplierSystem()
    {
        if (UI.GetComponent<UI>().streak >= 3 && UI.GetComponent<UI>().streak < 6)
        {
            UI.GetComponent<UI>().multiplier = 2;
        }
        else if (UI.GetComponent<UI>().streak >= 6 && UI.GetComponent<UI>().streak < 9)
        {
            UI.GetComponent<UI>().multiplier = 4;
        }
        else if (UI.GetComponent<UI>().streak >= 9)
        {
            UI.GetComponent<UI>().multiplier = 6;
        }
        else
        {
            UI.GetComponent<UI>().multiplier = 1;
        }
    }

    void Update()
    {
        if (gameManager.GetComponent<BeatScroller>().gameActive == true)
        {
            song.SetActive(true);

            UI.SetActive(true);

            Pressing();

            ScoreSystem();

            MultiplierSystem();
        }
    }   
}