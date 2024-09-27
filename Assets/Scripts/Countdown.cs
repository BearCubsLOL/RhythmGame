using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public TextMeshProUGUI CountdownText;

    void Number(string currentNum)
    {
        CountdownText.text = currentNum;
    }
}
