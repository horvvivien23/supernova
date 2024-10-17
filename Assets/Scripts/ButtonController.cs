using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject nextSceneButton; // A gomb GameObject-je
    public Vector2 playerStartPosition = new Vector2(0, -4.5f); // Kezdõ pozíció az ûrhajónak

    void Start()
    {
        // Kezdetben a gomb legyen elrejtve
        nextSceneButton.SetActive(false);

        // Feliratkozunk a jelenet betöltési eseményre
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            if (nextSceneButton != null) // Ellenõrzés, hogy a gomb nem null
            {
                nextSceneButton.SetActive(true); // A gomb megjelenítése
            }
        }

        if (collision.gameObject.tag == "Newgoal")
        {
            if (nextSceneButton != null) // Ellenõrzés, hogy a gomb nem null
            {
                nextSceneButton.SetActive(true); // A gomb megjelenítése
            }
        }
    }
    /*
    public void OnNextSceneButtonClick()
    {
        Debug.Log("Next scene button clicked."); // Ellenõrzés
        // Jelenet betöltése
        SceneManager.LoadScene("AsteroidsScene"); // Használj szöveges nevet a következõ jelenethez
    }*/

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Csak akkor állítsuk be a pozíciót, ha nem az elsõ jelenetben vagyunk
        transform.position = playerStartPosition;
    }

    void OnDestroy()
    {
        // Ne felejtsük el leiratkozni az eseményrõl, amikor az objektum megsemmisül
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}


/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour;
{
    public GameObject nextSceneButton; // A gomb GameObject-je
    public Vector2 playerStartPosition = new Vector2(0, -4.5f); // Kezdõ pozíció az ûrhajónak

    void Start()
    {
        // Kezdetben a gomb legyen elrejtve
        nextSceneButton.SetActive(false);

        // Feliratkozunk a jelenet betöltési eseményre
        SceneManager.sceneLoaded += OnSceneLoaded;
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
        // Jelenet betöltése
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Amikor egy új jelenet betöltõdik
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Csak akkor állítsuk be a pozíciót, ha nem az elsõ jelenetben vagyunk
        transform.position = playerStartPosition;
    }

    void OnDestroy()
    {
        // Ne felejtsük el leiratkozni az eseményrõl, amikor az objektum megsemmisül
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}


/*
public class ButtonController : MonoBehaviour
{
    public GameObject nextSceneButton; // A gomb GameObject-je

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
}
*/