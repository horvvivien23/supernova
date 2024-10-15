using UnityEngine;

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
