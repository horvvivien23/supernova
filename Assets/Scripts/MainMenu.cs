
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Referencia a szintv�laszt� panelhez
    public GameObject levelSelectPanel;

    // Elind�tja a j�t�kot, amikor a "Play" gomb megnyom�sra ker�l.
    public void PlayGame()
    {
        Debug.Log("Play gomb megnyomva!");

        // Alaphelyzetbe �ll�tja az �llapotokat
        ResetGameState();

        // Az els� j�t�kszint bet�lt�se
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Megjelen�ti a szintv�laszt� panelt, amikor a "Level" gomb megnyom�sra ker�l.
    public void ShowLevelSelect()
    {
        levelSelectPanel.SetActive(true);
    }

    // Elrejti a szintv�laszt� panelt
    public void HideLevelSelect()
    {
        levelSelectPanel.SetActive(false);
    }

    // Kil�pteti az alkalmaz�st, amikor a "Quit" gomb megnyom�sra ker�l.
    public void QuitGame()
    {
        Application.Quit();
    }

    // Vissza�ll�tja a j�t�k alap�llapot�t
    private void ResetGameState()
    {
        // Id� vissza�ll�t�sa norm�l sebess�gre
        Time.timeScale = 1;

        // �letek vissza�ll�t�sa
        PlayerLives playerLives = FindObjectOfType<PlayerLives>();
        if (playerLives != null)
        {
            playerLives.ResetLives(); // Megh�vja az �letek alaphelyzetbe �ll�t�s�t
        }

        // Pontsz�m alaphelyzetbe �ll�t�sa
        PointManager scoreManager = FindObjectOfType<PointManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetPoints(); // Felt�telezve, hogy van egy ilyen met�dus
        }

        // Game Over Panel elrejt�se
        GameObject gameOverPanel = GameObject.Find("GameOverPanel"); // Nevezd el pontosan az UI elemet!
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Ha m�s glob�lis �llapotokat is vissza kell �ll�tani, itt add hozz� �ket!
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Referencia a szintv�laszt� panelhez
    public GameObject levelSelectPanel;

    // Elind�tja a j�t�kot, amikor a "Play" gomb megnyom�sra ker�l.
    public void PlayGame()
    {
        Debug.Log("Play gomb megnyomva!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Megjelen�ti a szintv�laszt� panelt, amikor a "Level" gomb megnyom�sra ker�l.
    public void ShowLevelSelect()
    {
        levelSelectPanel.SetActive(true);
    }
    // Elrejti a szintv�laszt� panelt
    public void HideLevelSelect()
    {
        levelSelectPanel.SetActive(false);
    }


    // Kil�pteti az alkalmaz�st, amikor a "Quit" gomb megnyom�sra ker�l.
    public void QuitGame()
    {
        Application.Quit();
    }
}
*/