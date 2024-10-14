using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 5f;  // Az aszteroida mozg�si sebess�ge
    private Vector3 direction = Vector3.right; // Kezdeti ir�ny: jobbra
    //public float moveSpeed;
    public GameObject explosionPrefab; // A robban�s prefabja


    void Update()
    {
        // Mozgatjuk az aszteroid�t jobbra vagy balra
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // �tk�z�s ellen�rz�s (boundary objektumokkal)
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellen�rizz�k, hogy az aszteroida a "boundary" Tag-gel ell�tott objektummal �tk�z�tt-e
        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            direction *= -1;
        }
        if(collision.gameObject.tag=="Spaceship") // Itt a Spaceship tag kell, ami az �rhaj�hoz van rendelve
        {
            // Hozz�f�r�nk az �rhaj� PlayerLives szkriptj�hez
            PlayerLives playerLives = collision.GetComponent<PlayerLives>();
            if (playerLives != null)
            {
                // Robban�s
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                // �let cs�kkent�se
                playerLives.lives -= 1; // K�zvetlen cs�kkent�s

                // Ellen�rizz�k, hogy az �letek elfogytak-e
                if (playerLives.lives <= 0)
                {
                    Destroy(collision.gameObject); // Az �rhaj� elt�vol�t�sa
                    Time.timeScale = 0; // J�t�k meg�ll�t�sa
                    playerLives.gameOverPanel.SetActive(true); // J�t�kv�gi panel megjelen�t�se
                    playerLives.scoreManager.HighScoreUpdate(); // Magas pontsz�m friss�t�se
                }
                Explode(); // Robban�s
            Destroy(gameObject); // Aszteroida elt�vol�t�sa
            }
        }

    }
    void Explode()
    {
        // Robban�s prefab l�trehoz�sa
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
