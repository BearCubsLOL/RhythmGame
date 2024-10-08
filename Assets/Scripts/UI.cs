using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public int score = 0;
    public int multiplier = 0;
    public int streak = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI multiplierText;
    [SerializeField] private TextMeshProUGUI streakText;

    void Update()
    {
        scoreText.text = "Score: " + score;
        multiplierText.text = "Multiplier: " + multiplier + "x";
        streakText.text = "Streak: " + streak;
    }
}
