using UnityEngine;
using UnityEngine.SceneManagement; // Sz�ks�ges a scene kezel�shez

public class MenuButtonScript : MonoBehaviour
{
    // Ez a f�ggv�ny fogja kezelni a gomb megnyom�s�ra t�rt�n� jelenetv�lt�st
    public void LoadMainMenu()
    {
        // Bet�lti a MainMenu nev� jelenetet
        SceneManager.LoadScene("MainMenu");
    }
}
