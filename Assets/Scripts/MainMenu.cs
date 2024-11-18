
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Referencia a szintválasztó panelhez
    public GameObject levelSelectPanel;

    // Elindítja a játékot, amikor a "Play" gomb megnyomásra kerül.
    public void PlayGame()
    {
        Debug.Log("Play gomb megnyomva!");

        // Alaphelyzetbe állítja az állapotokat
        ResetGameState();

        // Az elsõ játékszint betöltése
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Megjeleníti a szintválasztó panelt, amikor a "Level" gomb megnyomásra kerül.
    public void ShowLevelSelect()
    {
        levelSelectPanel.SetActive(true);
    }

    // Elrejti a szintválasztó panelt
    public void HideLevelSelect()
    {
        levelSelectPanel.SetActive(false);
    }

    // Kilépteti az alkalmazást, amikor a "Quit" gomb megnyomásra kerül.
    public void QuitGame()
    {
        Application.Quit();
    }

    // Visszaállítja a játék alapállapotát
    private void ResetGameState()
    {
        // Idõ visszaállítása normál sebességre
        Time.timeScale = 1;

        // Életek visszaállítása
        PlayerLives playerLives = FindObjectOfType<PlayerLives>();
        if (playerLives != null)
        {
            playerLives.ResetLives(); // Meghívja az életek alaphelyzetbe állítását
        }

        // Pontszám alaphelyzetbe állítása
        PointManager scoreManager = FindObjectOfType<PointManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetPoints(); // Feltételezve, hogy van egy ilyen metódus
        }

        // Game Over Panel elrejtése
        GameObject gameOverPanel = GameObject.Find("GameOverPanel"); // Nevezd el pontosan az UI elemet!
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Ha más globális állapotokat is vissza kell állítani, itt add hozzá õket!
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Referencia a szintválasztó panelhez
    public GameObject levelSelectPanel;

    // Elindítja a játékot, amikor a "Play" gomb megnyomásra kerül.
    public void PlayGame()
    {
        Debug.Log("Play gomb megnyomva!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Megjeleníti a szintválasztó panelt, amikor a "Level" gomb megnyomásra kerül.
    public void ShowLevelSelect()
    {
        levelSelectPanel.SetActive(true);
    }
    // Elrejti a szintválasztó panelt
    public void HideLevelSelect()
    {
        levelSelectPanel.SetActive(false);
    }


    // Kilépteti az alkalmazást, amikor a "Quit" gomb megnyomásra kerül.
    public void QuitGame()
    {
        Application.Quit();
    }
}
*/