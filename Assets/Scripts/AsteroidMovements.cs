using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 5f;  // Az aszteroida mozgási sebessége
    private Vector3 direction = Vector3.right; // Kezdeti irány: jobbra
    //public float moveSpeed;
    public GameObject explosionPrefab; // A robbanás prefabja


    void Update()
    {
        // Mozgatjuk az aszteroidát jobbra vagy balra
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Ütközés ellenõrzés (boundary objektumokkal)
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellenõrizzük, hogy az aszteroida a "boundary" Tag-gel ellátott objektummal ütközött-e
        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            direction *= -1;
        }
        if(collision.gameObject.tag=="Spaceship") // Itt a Spaceship tag kell, ami az ûrhajóhoz van rendelve
        {
            // Hozzáférünk az ûrhajó PlayerLives szkriptjéhez
            PlayerLives playerLives = collision.GetComponent<PlayerLives>();
            if (playerLives != null)
            {
                // Robbanás
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                // Élet csökkentése
                playerLives.lives -= 1; // Közvetlen csökkentés

                // Ellenõrizzük, hogy az életek elfogytak-e
                if (playerLives.lives <= 0)
                {
                    Destroy(collision.gameObject); // Az ûrhajó eltávolítása
                    Time.timeScale = 0; // Játék megállítása
                    playerLives.gameOverPanel.SetActive(true); // Játékvégi panel megjelenítése
                    playerLives.scoreManager.HighScoreUpdate(); // Magas pontszám frissítése
                }
                Explode(); // Robbanás
            Destroy(gameObject); // Aszteroida eltávolítása
            }
        }

    }
    void Explode()
    {
        // Robbanás prefab létrehozása
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
