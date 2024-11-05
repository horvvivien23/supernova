using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Elindítja a játékot, amikor a "Play" gomb megnyomásra kerül.
    public void PLayGame()
    {
        Debug.Log("Play gomb megnyomva!");
        // Betölti a következõ jelenetet a build index alapján,
        // így elindítva a játék elsõ jelenetét.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Kilépteti az alkalmazást, amikor a "Quit" gomb megnyomásra kerül.
    public void QuitGame()
    {
        // Leállítja az alkalmazást. Editor módban nem lép ki, de a buildelt játékban mûködik.
        Application.Quit();
    }
}
