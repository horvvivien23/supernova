using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3; // Kezd� �letek
    public Image[] livesUI; // Az �let ikonok UI elemei
    public GameObject explosionPrefab; // Robban�s prefab
    public GameObject gameOverPanel; // Game Over panel referencia

    public PointManager scoreManager;

    private void Start()
    {
        // UI inicializ�l�sa
        InitializeLivesUI();
    }
    private void ResetDontDestroyOnLoadObjects()
    {
        // T�r�lj�k az �sszes PlayerLives objektumot, ha l�tezik t�bb p�ld�ny
        foreach (var playerLives in FindObjectsOfType<PlayerLives>())
        {
            Destroy(playerLives.gameObject);
        }
    }

    public void ResetLives()
    {
        // Vissza�ll�tja az �leteket az alap�rt�kre
        lives = 3;
        UpdateLivesUI();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void InitializeLivesUI()
    {
        // Ha a livesUI �res, pr�b�ljuk meg bet�lteni a "LifeIcon" tag alapj�n
        if (livesUI == null || livesUI.Length == 0)
        {
            GameObject[] lifeIcons = GameObject.FindGameObjectsWithTag("LifeIcon");
            livesUI = lifeIcons.OrderBy(icon => icon.name).Select(icon => icon.GetComponent<Image>()).ToArray();
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("Enemy Projectile"))
        {
            HandlePlayerDamage(collision.gameObject);
        }
        if (collision.gameObject.tag == "Heart")
        {
            Destroy(collision.gameObject); // A sz�v elt�vol�t�sa
            if (lives < livesUI.Length) // Max �let ellen�rz�s
            {
                lives++; // �let n�vel�se
                for (int i = 0; i < livesUI.Length; i++)
                {
                    livesUI[i].enabled = i < lives; // UI friss�t�se
                }
            }
            return; // Kil�p�nk, hogy ne fusson le m�s �tk�z�s logika
        }
        if (collision.gameObject.CompareTag("Goal"))  // P�lda, amikor el�rj�k a c�lt
        {
            SaveHighScoreIfNeeded(); // A highscore ment�se
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            // �letek cs�kkent�se
            lives--;

            // UI friss�t�se
            UpdateLivesUI();

            if (lives <= 0)
            {
                // J�t�k v�ge logika
                if (gameOverPanel != null)
                {
                    gameOverPanel.SetActive(true);
                }
                if (scoreManager != null)
                {
                    scoreManager.UpdateHighScore();
                }
                Destroy(gameObject);
                Time.timeScale = 0;
            }
        }


    }
    private void SaveHighScoreIfNeeded()
    {
        if (scoreManager != null)
        {
            scoreManager.UpdateHighScore(); // Highscore friss�t�se
        }
    }


    private void HandlePlayerDamage(GameObject collisionObject)
    {
        Destroy(collisionObject);

        // Robban�s anim�ci�
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // �letek cs�kkent�se
        lives--;

        // UI friss�t�se
        UpdateLivesUI();

        if (lives <= 0)
        {
            // J�t�k v�ge logika
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
            if (scoreManager != null)
            {
                scoreManager.UpdateHighScore();
            }
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;// A j�t�kos �leteinek sz�m�t t�rolja, kezd��rt�ke 3.
    public Image[] livesUI; // A UI elemek t�mbje, amely az �let ikonokat tartalmazza.
    public GameObject explosionPrefab; // Az expon�l� prefab, amely a j�t�kos hal�lakor jelenik meg.
    public GameObject gameOverPanel;// A j�t�k v�ge panel, amely a j�t�kos hal�la ut�n jelenik meg.

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
        lives = 3; // Vissza�ll�t�s a kezd� �rt�kre
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives; // UI friss�t�se
        }
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // J�t�k v�ge panel elrejt�se
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


    }
// Trigger esem�ny kezel�se; ha a j�t�kos �tk�zik m�s objektumokkal.
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            Destroy(collision.gameObject); // A sz�v elt�vol�t�sa
            if (lives < livesUI.Length) // Max �let ellen�rz�s
            {
                lives++; // �let n�vel�se
                for (int i = 0; i < livesUI.Length; i++)
                {
                    livesUI[i].enabled = i < lives; // UI friss�t�se
                }
            }
            return; // Kil�p�nk, hogy ne fusson le m�s �tk�z�s logika
        }
        // Ha az �tk�z�s sor�n ellens�ges l�ved�kkel �tk�zik.
        if (collision.gameObject.tag == "Enemy Projectile")
        {
            Destroy(collision.gameObject);// Az ellens�ges l�ved�k elpuszt�t�sa.
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Az expon�l� prefab l�trehoz�sa.
            lives -= 1; //�letek cs�kkent�se
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true; // Az �let ikon megjelen�t�se.
                }
                else
                {
                    livesUI[i].enabled = false; // Az �let ikon elrejt�se.
                }
            }
            // Ha az �let sz�m 0-ra cs�kkent, a j�t�kos elpusztul.
            if (lives <= 0)
            {
                Destroy(gameObject); // A j�t�kos elpuszt�t�sa.
                Time.timeScale = 0;//Id� meg�ll�t�sa
                gameOverPanel.SetActive(true);// A j�t�k v�ge panel megjelen�t�se.
                scoreManager.UpdateHighScore();// A legmagasabb pontsz�m friss�t�se.
            }
        }//Ugyan az mint az el�z� csak Enemy tag
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
                scoreManager.UpdateHighScore();
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
                scoreManager.UpdateHighScore();
            }
        }//u.a.
        if (collision.gameObject.tag == "Boss")
        {
            // Cs�kkentsd a boss �leteit
            Boss BossScript = collision.gameObject.GetComponent<Boss>(); // Felt�telezz�k, hogy van egy Boss script, ami kezeli a boss logik�t
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
                scoreManager.UpdateHighScore();
            }
        }

    }
}
*/