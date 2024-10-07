using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countdownText;
    [SerializeField]
    private GameObject gameManager;

    void Number(string currentNum)
    {
        countdownText.text = currentNum;
        if (currentNum == "Start!")
        {
            gameManager.GetComponent<BeatScroller>().gameActive = true;
        }
    }
}