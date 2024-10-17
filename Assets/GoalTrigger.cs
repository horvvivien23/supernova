using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject nextSceneButton; // A gomb GameObject-je

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellen�rizz�k, hogy a j�t�kos �rte el a "Goal" objektumot
        if (collision.gameObject.CompareTag("Spaceship")) // Itt a "Player" tag legyen az �rhaj��
        {
            nextSceneButton.SetActive(true); // A gomb megjelen�t�se
        }
    }
}
