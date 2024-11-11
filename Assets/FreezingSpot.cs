using UnityEngine;

public class FreezingSpot : MonoBehaviour
{
    // A lassul�si t�nyez�, amelyet be�ll�thatsz az inspectorban is.
    public float slowDownFactor = 0.5f; // 0.5 azt jelenti, hogy a sebess�g felez�dik.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellen�rizz�k, hogy az �rhaj� �rintkezett-e a freezing spottal
        if (collision.CompareTag("Spaceship")) // Tegy�k fel, hogy az �rhaj�nak van egy "Player" tagje
        {
            // Megkeress�k az �rhaj� sebess�g�t a Rigidbody2D-n kereszt�l, �s lelass�tjuk
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity *= slowDownFactor;
            }
        }
    }
}
