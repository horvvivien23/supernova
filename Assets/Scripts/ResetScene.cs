using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetManager : MonoBehaviour
{
    public GameObject gameOverPanel; // A Game Over panel referencia

    public void ResetGame()
    {
        // Deaktiválja a Game Over panelt
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        Time.timeScale = 1f;
        // Betölti újra az aktuális szintet
        SceneManager.LoadScene("SampleScene");

        // Visszaállítja az állapotokat a betöltés után
        ResetDontDestroyOnLoadObjects();
    }

    private void ResetDontDestroyOnLoadObjects()
    {
        // Töröljük az összes DontDestroyOnLoad objektumot
        var dontDestroyObjects = FindObjectsOfType<DontDestroy>();
        foreach (var dontDestroy in dontDestroyObjects)
        {
            Destroy(dontDestroy.gameObject); // Eltávolítjuk a régi objektumokat
        }

        // Játékos és egyéb objektumok resetelése
        var player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.ResetPlayer();  // Visszaállítja a játékos pozícióját és mozgását
        }

        // Pontszámok visszaállítása
        var pointManager = FindObjectOfType<PointManager>();
        if (pointManager != null)
        {
            pointManager.UpdateScore(0); // Alapértelmezett pontszám visszaállítása
        }

        // Játékos életek visszaállítása
        var playerLives = FindObjectOfType<PlayerLives>();
        if (playerLives != null)
        {
            playerLives.ResetLives(); // Visszaállítja a játékos életeit
        }

        // Ûrhajó pozíciójának visszaállítása és aktiválása
        var playerShip = FindObjectOfType<PlayerController>();
        if (playerShip != null)
        {
            playerShip.gameObject.SetActive(true); // Aktiválja az ûrhajót, ha nem aktív
            playerShip.transform.position = new Vector2(-1, -120); // Kezdõ pozíció beállítása
        }
    }
}


/*using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetManager : MonoBehaviour
{
    public GameObject gameOverPanel; // A Game Over panel referencia
    

    public void ResetGame()
    {
        // Deaktiválja a Game Over panelt
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        

        // Visszaállít minden szükséges állapotot
        ResetDontDestroyOnLoadObjects();

        // Betölti az aktuális jelenetet újra
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ResetDontDestroyOnLoadObjects()
    {
        var player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.ResetPlayer();
        }
        // Példa arra, hogyan állíthatsz vissza különbözõ állapotokat
        // Itt állítsd vissza a pontokat, életeket, stb.
        var playerLives = FindObjectOfType<PlayerLives>();
        if (playerLives != null)
        {
            playerLives.ResetLives();
        }

        // Pontszám visszaállítása
        var pointManager = FindObjectOfType<PointManager>();
        if (pointManager != null)
        {
            pointManager.UpdateScore(0); // Itt alaphelyzetbe állíthatod a pontszámot, ha szükséges
        }

        // Ûrhajó pozíciójának visszaállítása és aktiválása
        var playerShip = FindObjectOfType<PlayerController>(); // Cseréld le a PlayerController-re, ha más a neve
        if (playerShip != null)
        {
            playerShip.gameObject.SetActive(true); // Aktiválja az ûrhajót, ha inaktiválódott
            playerShip.transform.position = new Vector2(-1, -120); // Kezdõpozíció beállítása
        }

    }


}*/
