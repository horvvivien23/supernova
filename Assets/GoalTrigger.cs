using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject nextSceneButton; // A gomb GameObject-je

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellenõrizzük, hogy a játékos érte el a "Goal" objektumot
        if (collision.gameObject.CompareTag("Spaceship")) // Itt a "Player" tag legyen az ûrhajóé
        {
            nextSceneButton.SetActive(true); // A gomb megjelenítése
        }
    }
}
