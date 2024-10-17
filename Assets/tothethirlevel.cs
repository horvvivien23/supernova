using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    public GameObject nextSceneButton; // A gomb GameObject-je
    public string nextSceneName; // A következõ szint neve

    void Start()
    {
        // Kezdetben a gomb legyen elrejtve
        nextSceneButton.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Ha az ûrhajó eléri a "Goal" tag-gel rendelkezõ objektumot
        if (collision.gameObject.tag == "Goal")
        {
            nextSceneButton.SetActive(true); // A gomb megjelenítése
        }
    }

    public void OnNextSceneButtonClick()
    {
        // Betöltjük a következõ jelenetet
        SceneManager.LoadScene(nextSceneName);
    }
}
