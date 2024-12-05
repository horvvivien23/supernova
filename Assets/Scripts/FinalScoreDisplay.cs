using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    public TMP_Text finalScoreText; // A v�gs� pontsz�mot megjelen�t� sz�veg
    public TMP_Text highScoreText; // A legjobb pontsz�mot megjelen�t� sz�veg
    private PointManager pointManager; // Hivatkoz�s a PointManager-re

    void Start()
    {
        // Megkeresi a PointManager-t a jelenetben
        pointManager = FindObjectOfType<PointManager>();

        if (pointManager != null)
        {
            // Be�ll�tja a v�gs� pontsz�mot �s a legjobb pontsz�mot a UI sz�vegekre
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
            Debug.LogError("PointManager nem tal�lhat�!");
        }
    }
}
