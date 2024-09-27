using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public TextMeshProUGUI countdownText;
    public GameObject gameManager;

    void Number(string currentNum)
    {
        countdownText.text = currentNum;
        if (currentNum == "Start!")
        {
            gameManager.GetComponent<BeatScroller>().gameActive = true;
        }
    }
}
