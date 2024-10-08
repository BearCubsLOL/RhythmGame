using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject multiplier;
    [SerializeField] private GameObject streak;

    void Number(string currentNum)
    {
        countdownText.text = currentNum;
        if (currentNum == "Start!")
        {
            gameManager.GetComponent<BeatScroller>().gameActive = true;
            score.SetActive(true);
            multiplier.SetActive(true);
            streak.SetActive(true);
        }
    }
}