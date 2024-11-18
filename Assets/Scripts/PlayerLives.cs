using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;// A játékos életeinek számát tárolja, kezdõértéke 3.
    public Image[] livesUI; // A UI elemek tömbje, amely az élet ikonokat tartalmazza.
    public GameObject explosionPrefab; // Az exponáló prefab, amely a játékos halálakor jelenik meg.
    public GameObject gameOverPanel;// A játék vége panel, amely a játékos halála után jelenik meg.

    public PointManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResetLives()
    {
        lives = 3; // Visszaállítás a kezdõ értékre
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives; // UI frissítése
        }
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Játék vége panel elrejtése
        }
    }
    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
                scoreManager.HighScoreUpdate();
            }
        }


    }*/
    // Trigger esemény kezelése; ha a játékos ütközik más objektumokkal.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            Destroy(collision.gameObject); // A szív eltávolítása
            if (lives < livesUI.Length) // Max élet ellenõrzés
            {
                lives++; // Élet növelése
                for (int i = 0; i < livesUI.Length; i++)
                {
                    livesUI[i].enabled = i < lives; // UI frissítése
                }
            }
            return; // Kilépünk, hogy ne fusson le más ütközés logika
        }
        // Ha az ütközés során ellenséges lövedékkel ütközik.
        if (collision.gameObject.tag == "Enemy Projectile")
        {
            Destroy(collision.gameObject);// Az ellenséges lövedék elpusztítása.
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Az exponáló prefab létrehozása.
            lives -= 1; //Életek csökkentése
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true; // Az élet ikon megjelenítése.
                }
                else
                {
                    livesUI[i].enabled = false; // Az élet ikon elrejtése.
                }
            }
            // Ha az élet szám 0-ra csökkent, a játékos elpusztul.
            if (lives <= 0)
            {
                Destroy(gameObject); // A játékos elpusztítása.
                Time.timeScale = 0;//Idõ megállítása
                gameOverPanel.SetActive(true);// A játék vége panel megjelenítése.
                scoreManager.HighScoreUpdate();// A legmagasabb pontszám frissítése.
            }
        }//Ugyan az mint az elõzõ csak Enemy tag
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
                scoreManager.HighScoreUpdate();
            }
        }
        // U.a.
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
                scoreManager.HighScoreUpdate();
            }
        }//u.a.
        if (collision.gameObject.tag == "Boss")
        {
            // Csökkentsd a boss életeit
            Boss BossScript = collision.gameObject.GetComponent<Boss>(); // Feltételezzük, hogy van egy Boss script, ami kezeli a boss logikát
            if (BossScript != null)
            {
                BossScript.TakeDamage();
            }
            //Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
                scoreManager.HighScoreUpdate();
            }
        }

    }
}
