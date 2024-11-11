using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    // A szint indexe vagy neve, amit ez a gomb megnyit
    public int levelIndex; // Ha indexszel akarod megadni
    // public string levelName; // Ha n�vvel szeretn�d megadni

    // Ezt a f�ggv�nyt add hozz� a gomb OnClick() esem�ny�hez
    public void LoadLevel()
    {
        // Szint bet�lt�se a be�ll�tott index alapj�n
        SceneManager.LoadScene(levelIndex);
        // Vagy, ha n�vvel haszn�lod, ezt a sort haszn�ld:
        // SceneManager.LoadScene(levelName);
    }
}
