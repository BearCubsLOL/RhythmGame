using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField]
    private bool canBePressed = false;
    [SerializeField]
    private GameObject trigger;
    [SerializeField]
    private bool wasPressed = false;

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
    }

}