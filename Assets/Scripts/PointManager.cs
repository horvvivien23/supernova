using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score; // Az aktuális pontszám
    public TMP_Text scoreText; // A pontszám megjelenítésére szolgáló UI szöveg
    public TMP_Text finalScoreText; // A játék végi pontszám szöveg
    public TMP_Text highScoreText; // A legjobb pontszám szöveg

    // Inicializálás
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        UpdateScoreUI();
        UpdateHighScoreUI(); // Frissítjük a HighScore szöveget is a kezdéskor
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0); // Olvasd be a mentett high score-t
        Debug.Log("Betöltött highscore: " + savedHighScore); // Debug üzenet

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + savedHighScore;
        }
    }

    // Pontszám növelése
    public void AddPoints(int amount)
    {
        score += amount;
        Debug.Log("Pontok hozzáadva: " + amount + ", Összes pont: " + score);
        UpdateScoreUI();
        //
        UpdateHighScore();
    }

    // Pontszám visszaállítása alaphelyzetbe
    public void ResetPoints()
    {
        score = 0;
        Debug.Log("Pontszám visszaállítva: " + score);
        UpdateScoreUI();
    }

    // A legjobb pontszám frissítése és megjelenítése
    public void UpdateHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);
        Debug.Log("Mentett legjobb pontszám: " + savedHighScore); // Debug üzenet

        // Ellenõrizzük, hogy a score nagyobb-e, mint a mentett highscore
        Debug.Log("Aktuális score: " + score); // Debug üzenet

        // Ha az aktuális pontszám nagyobb, mint a mentett highscore, frissítjük
        if (score > savedHighScore)
        {
            savedHighScore = score;
            PlayerPrefs.SetInt("SavedHighScore", savedHighScore); // Mentés
            PlayerPrefs.Save(); // Mentés biztosítása
            Debug.Log("Új highscore mentése: " + savedHighScore); // Debug üzenet
        }


        // UI frissítése
        if (finalScoreText != null)
        {
            finalScoreText.text = " " + score;
        }

        if (highScoreText != null)
        {
            highScoreText.text = " " + savedHighScore;
        }
    }



    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    // Pontszám UI frissítése
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // HighScore UI frissítése (induláskor)
    private void UpdateHighScoreUI()
    {
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + savedHighScore;
        }
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score; // Az aktuális pontszám
    public TMP_Text scoreText; // A pontszám megjelenítésére szolgáló UI szöveg
    public TMP_Text finalScoreText; // A játék végi pontszám szöveg
    public TMP_Text highScoreText; // A legjobb pontszám szöveg

    // Inicializálás
    void Start()
    {
        // Az aktuális pontszám megjelenítése a játék kezdetekor
        UpdateScoreUI();
    }

    // Pontszám növelése
    public void AddPoints(int amount)
    {
        score += amount;
        Debug.Log("Pontok hozzáadva: " + amount + ", Összes pont: " + score);
        UpdateScoreUI();
    }

    // Pontszám visszaállítása alaphelyzetbe
    public void ResetPoints()
    {
        score = 0;
        Debug.Log("Pontszám visszaállítva: " + score);
        UpdateScoreUI();
    }

    // A legjobb pontszám frissítése és megjelenítése
    public void UpdateHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);

        // Ha az aktuális pontszám magasabb, frissítjük a legjobb pontszámot
        if (score > savedHighScore)
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
            savedHighScore = score;
            Debug.Log("Új legjobb pontszám: " + savedHighScore);
        }

        // A játék végi pontszám és a legjobb pontszám megjelenítése
        if (finalScoreText != null)
        {
            finalScoreText.text =  score.ToString();
        }

        if (highScoreText != null)
        {
            highScoreText.text =  savedHighScore.ToString();
        }
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    // Pontszám UI frissítése
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}*/

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
        
        // Frissítjük a végsõ pontszámot és a legjobb pontszámot a képernyõn
        finalScoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("SavedHighScore").ToString(); // A legjobb pontszám mentése 
    }
}
*/


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