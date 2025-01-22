using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public int perfectPlusHits = 0;
    public int perfectHits = 0;
    public int greatHits = 0;
    public int goodHits = 0;
    public int missedHits = 0;
    [SerializeField] private TextMeshProUGUI perfectPlusHitsText;
    [SerializeField] private TextMeshProUGUI perfectHitsText;
    [SerializeField] private TextMeshProUGUI greatHitsText;
    [SerializeField] private TextMeshProUGUI goodHitsText;
    [SerializeField] private TextMeshProUGUI missedHitsText;

    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject stats;

    public List<string> blueNotes;
    public List<string> yellowNotes;
    public List<string> greenNotes;
    public List<string> redNotes;

    void Start()
    {
        stats.SetActive(false);
    }

    void StatsDisplay()
    {
        stats.SetActive(true);
    }

    void Update()
    {
        perfectPlusHitsText.text = "Perfect Plus Hits: " + perfectPlusHits;
        perfectHitsText.text = "Perfect Hits: " + perfectHits;
        greatHitsText.text = "Great Hits: " + greatHits;
        goodHitsText.text = "Good Hits: " + goodHits;
        missedHitsText.text = "Missed Hits: " + missedHits;

        if (gameManager.GetComponent<BeatScroller>().gameOver)
        {
            Invoke(nameof(StatsDisplay), 0.5f);
        }
    }
}