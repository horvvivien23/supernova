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
        // Ha az �rhaj� el�ri a "Goal" tag-gel rendelkez� objektumot
        if (collision.gameObject.tag == "Goal")
        {
            nextSceneButton.SetActive(true); // A gomb megjelen�t�se
        }
    }
}
