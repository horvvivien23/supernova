using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 5f;  // Az aszteroida mozgási sebessége
    private Vector3 direction = Vector3.right; // Kezdeti irány: jobbra
    public GameObject explosionPrefab; // A robbanás prefabja

    void Update()
    {
        // Mozgatjuk az aszteroidát jobbra vagy balra
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Ütközés ellenõrzés (boundary objektumokkal)
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            direction *= -1; // Irányváltás, ha elérjük a határt
        }
        /*if (collision.gameObject.tag == "Spaceship") // Ütközés az ûrhajóval
        {
            // Hozzáférünk az ûrhajó PlayerLives szkriptjéhez
            PlayerLives playerLives = collision.GetComponent<PlayerLives>();
            if (playerLives != null)
            {
                // Robbanás és az aszteroida elpusztítása
                Explode();
                Destroy(gameObject); // Aszteroida eltávolítása
            }
        }*/
    }

    void Explode()
    {
        // Robbanás prefab létrehozása
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
