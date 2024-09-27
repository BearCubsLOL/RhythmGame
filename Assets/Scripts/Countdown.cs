using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public TextMeshProUGUI CountdownText;
    public GameObject GameManager;

    void Number(string currentNum)
    {
        CountdownText.text = currentNum;
        if (currentNum == "Start!")
        {
            GameManager.GetComponent<BeatScroller>().gameActive = true;
        }
    }
}
