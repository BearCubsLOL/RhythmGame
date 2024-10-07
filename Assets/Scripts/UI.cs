using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public int score = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
