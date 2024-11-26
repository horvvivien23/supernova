using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetManager : MonoBehaviour
{
    public GameObject gameOverPanel; // A Game Over panel referencia

    public void ResetGame()
    {
        // Deaktiv�lja a Game Over panelt
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        Time.timeScale = 1f;
        // Bet�lti �jra az aktu�lis szintet
        SceneManager.LoadScene("SampleScene");

        // Vissza�ll�tja az �llapotokat a bet�lt�s ut�n
        ResetDontDestroyOnLoadObjects();
    }

    private void ResetDontDestroyOnLoadObjects()
    {
        // T�r�lj�k az �sszes DontDestroyOnLoad objektumot
        var dontDestroyObjects = FindObjectsOfType<DontDestroy>();
        foreach (var dontDestroy in dontDestroyObjects)
        {
            Destroy(dontDestroy.gameObject); // Elt�vol�tjuk a r�gi objektumokat
        }

        // J�t�kos �s egy�b objektumok resetel�se
        var player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.ResetPlayer();  // Vissza�ll�tja a j�t�kos poz�ci�j�t �s mozg�s�t
        }

        // Pontsz�mok vissza�ll�t�sa
        var pointManager = FindObjectOfType<PointManager>();
        if (pointManager != null)
        {
            pointManager.UpdateScore(0); // Alap�rtelmezett pontsz�m vissza�ll�t�sa
        }

        // J�t�kos �letek vissza�ll�t�sa
        var playerLives = FindObjectOfType<PlayerLives>();
        if (playerLives != null)
        {
            playerLives.ResetLives(); // Vissza�ll�tja a j�t�kos �leteit
        }

        // �rhaj� poz�ci�j�nak vissza�ll�t�sa �s aktiv�l�sa
        var playerShip = FindObjectOfType<PlayerController>();
        if (playerShip != null)
        {
            playerShip.gameObject.SetActive(true); // Aktiv�lja az �rhaj�t, ha nem akt�v
            playerShip.transform.position = new Vector2(-1, -120); // Kezd� poz�ci� be�ll�t�sa
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
        // Deaktiv�lja a Game Over panelt
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        

        // Vissza�ll�t minden sz�ks�ges �llapotot
        ResetDontDestroyOnLoadObjects();

        // Bet�lti az aktu�lis jelenetet �jra
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ResetDontDestroyOnLoadObjects()
    {
        var player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.ResetPlayer();
        }
        // P�lda arra, hogyan �ll�thatsz vissza k�l�nb�z� �llapotokat
        // Itt �ll�tsd vissza a pontokat, �leteket, stb.
        var playerLives = FindObjectOfType<PlayerLives>();
        if (playerLives != null)
        {
            playerLives.ResetLives();
        }

        // Pontsz�m vissza�ll�t�sa
        var pointManager = FindObjectOfType<PointManager>();
        if (pointManager != null)
        {
            pointManager.UpdateScore(0); // Itt alaphelyzetbe �ll�thatod a pontsz�mot, ha sz�ks�ges
        }

        // �rhaj� poz�ci�j�nak vissza�ll�t�sa �s aktiv�l�sa
        var playerShip = FindObjectOfType<PlayerController>(); // Cser�ld le a PlayerController-re, ha m�s a neve
        if (playerShip != null)
        {
            playerShip.gameObject.SetActive(true); // Aktiv�lja az �rhaj�t, ha inaktiv�l�dott
            playerShip.transform.position = new Vector2(-1, -120); // Kezd�poz�ci� be�ll�t�sa
        }

    }


}*/
