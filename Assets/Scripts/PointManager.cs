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