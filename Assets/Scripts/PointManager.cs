using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score; // Az aktu�lis pontsz�m
    public TMP_Text scoreText; // A pontsz�m megjelen�t�s�re szolg�l� UI sz�veg
    public TMP_Text finalScoreText; // A j�t�k v�gi pontsz�m sz�veg
    public TMP_Text highScoreText; // A legjobb pontsz�m sz�veg

    // Inicializ�l�s
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        UpdateScoreUI();
        UpdateHighScoreUI(); // Friss�tj�k a HighScore sz�veget is a kezd�skor
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0); // Olvasd be a mentett high score-t
        Debug.Log("Bet�lt�tt highscore: " + savedHighScore); // Debug �zenet

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + savedHighScore;
        }
    }

    // Pontsz�m n�vel�se
    public void AddPoints(int amount)
    {
        score += amount;
        Debug.Log("Pontok hozz�adva: " + amount + ", �sszes pont: " + score);
        UpdateScoreUI();
        //
        UpdateHighScore();
    }

    // Pontsz�m vissza�ll�t�sa alaphelyzetbe
    public void ResetPoints()
    {
        score = 0;
        Debug.Log("Pontsz�m vissza�ll�tva: " + score);
        UpdateScoreUI();
    }

    // A legjobb pontsz�m friss�t�se �s megjelen�t�se
    public void UpdateHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);
        Debug.Log("Mentett legjobb pontsz�m: " + savedHighScore); // Debug �zenet

        // Ellen�rizz�k, hogy a score nagyobb-e, mint a mentett highscore
        Debug.Log("Aktu�lis score: " + score); // Debug �zenet

        // Ha az aktu�lis pontsz�m nagyobb, mint a mentett highscore, friss�tj�k
        if (score > savedHighScore)
        {
            savedHighScore = score;
            PlayerPrefs.SetInt("SavedHighScore", savedHighScore); // Ment�s
            PlayerPrefs.Save(); // Ment�s biztos�t�sa
            Debug.Log("�j highscore ment�se: " + savedHighScore); // Debug �zenet
        }


        // UI friss�t�se
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

    // Pontsz�m UI friss�t�se
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // HighScore UI friss�t�se (indul�skor)
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
    public int score; // Az aktu�lis pontsz�m
    public TMP_Text scoreText; // A pontsz�m megjelen�t�s�re szolg�l� UI sz�veg
    public TMP_Text finalScoreText; // A j�t�k v�gi pontsz�m sz�veg
    public TMP_Text highScoreText; // A legjobb pontsz�m sz�veg

    // Inicializ�l�s
    void Start()
    {
        // Az aktu�lis pontsz�m megjelen�t�se a j�t�k kezdetekor
        UpdateScoreUI();
    }

    // Pontsz�m n�vel�se
    public void AddPoints(int amount)
    {
        score += amount;
        Debug.Log("Pontok hozz�adva: " + amount + ", �sszes pont: " + score);
        UpdateScoreUI();
    }

    // Pontsz�m vissza�ll�t�sa alaphelyzetbe
    public void ResetPoints()
    {
        score = 0;
        Debug.Log("Pontsz�m vissza�ll�tva: " + score);
        UpdateScoreUI();
    }

    // A legjobb pontsz�m friss�t�se �s megjelen�t�se
    public void UpdateHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);

        // Ha az aktu�lis pontsz�m magasabb, friss�tj�k a legjobb pontsz�mot
        if (score > savedHighScore)
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
            savedHighScore = score;
            Debug.Log("�j legjobb pontsz�m: " + savedHighScore);
        }

        // A j�t�k v�gi pontsz�m �s a legjobb pontsz�m megjelen�t�se
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

    // Pontsz�m UI friss�t�se
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
        scoreText.text = "Score: " + score; // A pontsz�m sz�veg inicializ�l�sa
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public int points = 0; // A pontok sz�ma

    // Pontsz�m n�vel�se (ha van ilyen met�dusod)
    public void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("Pontok: " + points);
    }

    // Pontsz�m vissza�ll�t�sa alaphelyzetbe
    public void ResetPoints()
    {
        points = 0;
        Debug.Log("Pontsz�m vissza�ll�tva: " + points);
    }

    // Met�dus a legjobb pontsz�m friss�t�s�re, ha az aktu�lis pontsz�m meghaladja azt
    public void HighScoreUpdate()
    {
        // Ellen�rizz�k, hogy m�r van elmentett legjobb pontsz�m
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            // Ha az aktu�lis pontsz�m magasabb, mint a mentett legjobb, friss�tj�k
            if (score > PlayerPrefs.GetInt("SavedHighScore", score))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }
        
        // Friss�tj�k a v�gs� pontsz�mot �s a legjobb pontsz�mot a k�perny�n
        finalScoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("SavedHighScore").ToString(); // A legjobb pontsz�m ment�se 
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
        scoreText.text = "Score: " + score; // A pontsz�m sz�veg inicializ�l�sa
    }

  public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    public int points = 0; // A pontok sz�ma

    // Pontsz�m n�vel�se (ha van ilyen met�dusod)
    public void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("Pontok: " + points);
    }

    // Pontsz�m vissza�ll�t�sa alaphelyzetbe
    public void ResetPoints()
    {
        points = 0;
        Debug.Log("Pontsz�m vissza�ll�tva: " + points);
    }
    // Met�dus a legjobb pontsz�m friss�t�s�re, ha az aktu�lis pontsz�m meghaladja azt
    public void HighScoreUpdate()
    {
        // Ellen�rizz�k, hogy m�r van elmentett legjobb pontsz�m
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            // Ha az aktu�lis pontsz�m magasabb, mint a mentett legjobb, friss�tj�k
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
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString(); // A legjobb pontsz�m ment�se 
    }
}
*/