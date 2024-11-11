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
