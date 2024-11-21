using UnityEngine;
using UnityEngine.SceneManagement; // Szükséges a scene kezeléshez

public class MenuButtonScript : MonoBehaviour
{
    // Ez a függvény fogja kezelni a gomb megnyomására történõ jelenetváltást
    public void LoadMainMenu()
    {
        // Betölti a MainMenu nevû jelenetet
        SceneManager.LoadScene("MainMenu");
    }
}
