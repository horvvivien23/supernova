using UnityEngine;

public class FreezingSpot : MonoBehaviour
{
    // A lassulási tényezõ, amelyet beállíthatsz az inspectorban is.
    public float slowDownFactor = 0.5f; // 0.5 azt jelenti, hogy a sebesség felezõdik.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellenõrizzük, hogy az ûrhajó érintkezett-e a freezing spottal
        if (collision.CompareTag("Spaceship")) // Tegyük fel, hogy az ûrhajónak van egy "Player" tagje
        {
            // Megkeressük az ûrhajó sebességét a Rigidbody2D-n keresztül, és lelassítjuk
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity *= slowDownFactor;
            }
        }
    }
}
