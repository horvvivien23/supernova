using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score; // A pontszám szöveg inicializálása
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public int points = 0; // A pontok száma

    // Pontszám növelése (ha van ilyen metódusod)
    public void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("Pontok: " + points);
    }

    // Pontszám visszaállítása alaphelyzetbe
    public void ResetPoints()
    {
        points = 0;
        Debug.Log("Pontszám visszaállítva: " + points);
    }

    // Metódus a legjobb pontszám frissítésére, ha az aktuális pontszám meghaladja azt
    public void HighScoreUpdate()
    {
        // Ellenõrizzük, hogy már van elmentett legjobb pontszám
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            // Ha az aktuális pontszám magasabb, mint a mentett legjobb, frissítjük
            if (score > PlayerPrefs.GetInt("SavedHighScore", score))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }
        
        // Frissítjük a végsõ pontszámot és a legjobb pontszámot a képernyõn
        finalScoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("SavedHighScore").ToString(); // A legjobb pontszám mentése 
    }
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score; // A pontszám szöveg inicializálása
    }

  public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    public int points = 0; // A pontok száma

    // Pontszám növelése (ha van ilyen metódusod)
    public void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("Pontok: " + points);
    }

    // Pontszám visszaállítása alaphelyzetbe
    public void ResetPoints()
    {
        points = 0;
        Debug.Log("Pontszám visszaállítva: " + points);
    }
    // Metódus a legjobb pontszám frissítésére, ha az aktuális pontszám meghaladja azt
    public void HighScoreUpdate()
    {
        // Ellenõrizzük, hogy már van elmentett legjobb pontszám
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            // Ha az aktuális pontszám magasabb, mint a mentett legjobb, frissítjük
            if (score > PlayerPrefs.GetInt("SavedHighScore", score))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }
        finalScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString(); // A legjobb pontszám mentése 
    }
}
*/