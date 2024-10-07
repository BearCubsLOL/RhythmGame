using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField]
    private bool canBePressed = false;
    [SerializeField]
    private GameObject trigger;
    [SerializeField]
    private bool wasPressed = false;
    [SerializeField]
    private GameObject gameManager;
    private bool alreadyRan = false;
    private float distance = 0f;
    private float idkrn = 5.00f;
    [SerializeField]
    private GameObject UI;

    private int perfectPlusScore = 1000;
    private int perfectScore = 800;
    private int greatScore = 600;
    private int goodScore = 500;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == trigger)
        {
            canBePressed = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == trigger)
        {
            canBePressed = false;
        }
    }

    void Update()
    {
        if (gameManager.GetComponent<BeatScroller>().gameActive == true)
        {
            if (canBePressed)
            {
                if (Input.GetKey(KeyCode.D) && transform.position.z == 3.5)
                {
                    wasPressed = true;
                }
                if (Input.GetKey(KeyCode.F) && transform.position.z == 1.125)
                {
                    wasPressed = true;
                }
                if (Input.GetKey(KeyCode.J) && transform.position.z == -1.125)
                {
                    wasPressed = true;
                }
                if (Input.GetKey(KeyCode.K) && transform.position.z == -3.5)
                {
                    wasPressed = true;
                }
            }

            if (wasPressed && !alreadyRan)
            {
                alreadyRan = true;
                distance = idkrn - transform.position.x;
                distance = Mathf.Abs(distance);
                if (distance <= 0.25)
                {
                    Debug.Log("Perfect+");
                    UI.GetComponent<UI>().score += perfectPlusScore;
                }
                else if (distance > 0.25 && distance <= 0.5)
                {
                    Debug.Log("Perfect");
                    UI.GetComponent<UI>().score += perfectScore;
                }
                else if (distance > 0.5 && distance <= 0.75)
                {
                    Debug.Log("Great");
                    UI.GetComponent<UI>().score += greatScore;
                }
                else if (distance > 0.75)
                {
                    Debug.Log("Good");
                    UI.GetComponent<UI>().score += goodScore;
                }
            }
        }
    }

    
}