using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 5f;  // Az aszteroida mozg�si sebess�ge
    private Vector3 direction = Vector3.right; // Kezdeti ir�ny: jobbra
    public GameObject explosionPrefab; // A robban�s prefabja

    void Update()
    {
        // Mozgatjuk az aszteroid�t jobbra vagy balra
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // �tk�z�s ellen�rz�s (boundary objektumokkal)
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            direction *= -1; // Ir�nyv�lt�s, ha el�rj�k a hat�rt
        }
        /*if (collision.gameObject.tag == "Spaceship") // �tk�z�s az �rhaj�val
        {
            // Hozz�f�r�nk az �rhaj� PlayerLives szkriptj�hez
            PlayerLives playerLives = collision.GetComponent<PlayerLives>();
            if (playerLives != null)
            {
                // Robban�s �s az aszteroida elpuszt�t�sa
                Explode();
                Destroy(gameObject); // Aszteroida elt�vol�t�sa
            }
        }*/
    }

    void Explode()
    {
        // Robban�s prefab l�trehoz�sa
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
