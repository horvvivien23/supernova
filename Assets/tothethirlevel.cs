using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    public GameObject nextSceneButton; // A gomb GameObject-je
    public string nextSceneName; // A k�vetkez� szint neve

    void Start()
    {
        // Kezdetben a gomb legyen elrejtve
        nextSceneButton.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Ha az �rhaj� el�ri a "Goal" tag-gel rendelkez� objektumot
        if (collision.gameObject.tag == "Goal")
        {
            nextSceneButton.SetActive(true); // A gomb megjelen�t�se
        }
    }

    public void OnNextSceneButtonClick()
    {
        // Bet�ltj�k a k�vetkez� jelenetet
        SceneManager.LoadScene(nextSceneName);
    }
}
