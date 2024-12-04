using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    public TMP_Text finalScoreText; // A végsõ pontszámot megjelenítõ szöveg
    public TMP_Text highScoreText; // A legjobb pontszámot megjelenítõ szöveg
    private PointManager pointManager; // Hivatkozás a PointManager-re

    void Start()
    {
        // Megkeresi a PointManager-t a jelenetben
        pointManager = FindObjectOfType<PointManager>();

        if (pointManager != null)
        {
            // Beállítja a végsõ pontszámot és a legjobb pontszámot a UI szövegekre
            if (finalScoreText != null)
            {
                finalScoreText.text = " " + pointManager.score;
            }

            if (highScoreText != null)
            {
                int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);
                highScoreText.text = "  " + savedHighScore;
            }
        }
        else
        {
            Debug.LogError("PointManager nem található!");
        }
    }
}
