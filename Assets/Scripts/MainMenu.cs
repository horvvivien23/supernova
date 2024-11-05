using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Elind�tja a j�t�kot, amikor a "Play" gomb megnyom�sra ker�l.
    public void PLayGame()
    {
        Debug.Log("Play gomb megnyomva!");
        // Bet�lti a k�vetkez� jelenetet a build index alapj�n,
        // �gy elind�tva a j�t�k els� jelenet�t.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Kil�pteti az alkalmaz�st, amikor a "Quit" gomb megnyom�sra ker�l.
    public void QuitGame()
    {
        // Le�ll�tja az alkalmaz�st. Editor m�dban nem l�p ki, de a buildelt j�t�kban m�k�dik.
        Application.Quit();
    }
}
