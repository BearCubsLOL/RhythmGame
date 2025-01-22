using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private GameObject gameManager;
    public GameObject score;
    public GameObject multiplier;
    public GameObject streak;

    void Number(string currentNum)
    {
        countdownText.text = currentNum;
        if (currentNum == "Start!")
        {
            gameManager.GetComponent<BeatScroller>().gameActive = true;
        }
    }
}