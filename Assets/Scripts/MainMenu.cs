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
