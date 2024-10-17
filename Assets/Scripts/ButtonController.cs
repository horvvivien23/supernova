using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject nextSceneButton; // A gomb GameObject-je
    public Vector2 playerStartPosition = new Vector2(0, -4.5f); // Kezd� poz�ci� az �rhaj�nak

    void Start()
    {
        // Kezdetben a gomb legyen elrejtve
        nextSceneButton.SetActive(false);

        // Feliratkozunk a jelenet bet�lt�si esem�nyre
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            if (nextSceneButton != null) // Ellen�rz�s, hogy a gomb nem null
            {
                nextSceneButton.SetActive(true); // A gomb megjelen�t�se
            }
        }

        if (collision.gameObject.tag == "Newgoal")
        {
            if (nextSceneButton != null) // Ellen�rz�s, hogy a gomb nem null
            {
                nextSceneButton.SetActive(true); // A gomb megjelen�t�se
            }
        }
    }
    /*
    public void OnNextSceneButtonClick()
    {
        Debug.Log("Next scene button clicked."); // Ellen�rz�s
        // Jelenet bet�lt�se
        SceneManager.LoadScene("AsteroidsScene"); // Haszn�lj sz�veges nevet a k�vetkez� jelenethez
    }*/

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Csak akkor �ll�tsuk be a poz�ci�t, ha nem az els� jelenetben vagyunk
        transform.position = playerStartPosition;
    }

    void OnDestroy()
    {
        // Ne felejts�k el leiratkozni az esem�nyr�l, amikor az objektum megsemmis�l
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}


/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour;
{
    public GameObject nextSceneButton; // A gomb GameObject-je
    public Vector2 playerStartPosition = new Vector2(0, -4.5f); // Kezd� poz�ci� az �rhaj�nak

    void Start()
    {
        // Kezdetben a gomb legyen elrejtve
        nextSceneButton.SetActive(false);

        // Feliratkozunk a jelenet bet�lt�si esem�nyre
        SceneManager.sceneLoaded += OnSceneLoaded;
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
        // Jelenet bet�lt�se
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Amikor egy �j jelenet bet�lt�dik
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Csak akkor �ll�tsuk be a poz�ci�t, ha nem az els� jelenetben vagyunk
        transform.position = playerStartPosition;
    }

    void OnDestroy()
    {
        // Ne felejts�k el leiratkozni az esem�nyr�l, amikor az objektum megsemmis�l
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
        // Ha az �rhaj� el�ri a "Goal" tag-gel rendelkez� objektumot
        if (collision.gameObject.tag == "Goal")
        {
            nextSceneButton.SetActive(true); // A gomb megjelen�t�se
        }
    }
}
*/