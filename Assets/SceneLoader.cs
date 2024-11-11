using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    // A szint indexe vagy neve, amit ez a gomb megnyit
    public int levelIndex; // Ha indexszel akarod megadni
    // public string levelName; // Ha névvel szeretnéd megadni

    // Ezt a függvényt add hozzá a gomb OnClick() eseményéhez
    public void LoadLevel()
    {
        // Szint betöltése a beállított index alapján
        SceneManager.LoadScene(levelIndex);
        // Vagy, ha névvel használod, ezt a sort használd:
        // SceneManager.LoadScene(levelName);
    }
}
