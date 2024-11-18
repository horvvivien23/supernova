using UnityEngine;
using UnityEngine.UI; // Az UI kezel�s�hez

public class Boss : MonoBehaviour
{
    public int maxLives = 3; // Maxim�lis �letek sz�ma
    public int currentLives; // Jelenlegi �letek sz�ma
    public Image[] hearts; // A sz�vek UI elemek
    public GameObject heartPickup; // Az inakt�v sz�v GameObject

    void Start()
    {
        currentLives = maxLives; // Kezd� �letek be�ll�t�sa
        UpdateLivesUI();
    }

    // Ez a met�dus h�v�dik meg, amikor a boss-t eltal�lj�k
    public void TakeDamage()
    {
        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            Die(); // A boss meghal, ha elfogynak az �letei
        }
    }

    // Friss�ti a sz�vek UI megjelen�t�s�t
    private void UpdateLivesUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].enabled = true; // A sz�v megjelen�t�se, ha van �lete
            }
            else
            {
                hearts[i].enabled = false; // A sz�v elrejt�se, ha elfogyott az �lete
            }
        }
    }

    // A boss hal�l�nak kezel�se
    private void Die()
    {
        Debug.Log("Boss defeated!");

        // Aktiv�lja a sz�v GameObjectet
        if (heartPickup != null)
        {
            heartPickup.SetActive(true);
        }

        Destroy(gameObject); // Elt�vol�tja a boss objektumot
    }
}


/*using UnityEngine;
using UnityEngine.UI; // Az UI kezel�s�hez
using TMPro;

public class Boss : MonoBehaviour
{
    public int maxLives = 3; // Maxim�lis �letek sz�ma
    public int currentLives; // Jelenlegi �letek sz�ma
    public Image[] hearts; // A sz�vek UI elemek

    void Start()
    {
        currentLives = maxLives; // Kezd� �letek be�ll�t�sa
        UpdateLivesUI();
    }

    // Ez a met�dus h�v�dik meg, amikor a boss-t eltal�lj�k
    public void TakeDamage()
    {
        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            Die(); // A boss meghal, ha elfogynak az �letei
        }
    }

    // Friss�ti a sz�vek UI megjelen�t�s�t
    private void UpdateLivesUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].enabled = true; // A sz�v megjelen�t�se, ha van �lete
            }
            else
            {
                hearts[i].enabled = false; // A sz�v elrejt�se, ha elfogyott az �lete
            }
        }
    }

    // A boss hal�l�nak kezel�se
    private void Die()
    {
        Debug.Log("Boss defeated!");
        // (pl. anim�ci�, j�t�k v�ge, stb.)

        Destroy(gameObject); // Elt�vol�tja a boss objektumot
    }

    /*
    // A l�v�sek �rz�kel�s�hez
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet")) // Felt�telezve, hogy a j�t�kos l�ved�kei "PlayerBullet" tag-el rendelkeznek
        {
            TakeDamage();
            Destroy(other.gameObject); // Elt�vol�tja a l�ved�ket
        }
    }
}*/

