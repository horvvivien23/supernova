using UnityEngine;
using UnityEngine.UI; // Az UI kezeléséhez

public class Boss : MonoBehaviour
{
    public int maxLives = 3; // Maximális életek száma
    public int currentLives; // Jelenlegi életek száma
    public Image[] hearts; // A szívek UI elemek
    public GameObject heartPickup; // Az inaktív szív GameObject

    void Start()
    {
        currentLives = maxLives; // Kezdõ életek beállítása
        UpdateLivesUI();
    }

    // Ez a metódus hívódik meg, amikor a boss-t eltalálják
    public void TakeDamage()
    {
        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            Die(); // A boss meghal, ha elfogynak az életei
        }
    }

    // Frissíti a szívek UI megjelenítését
    private void UpdateLivesUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].enabled = true; // A szív megjelenítése, ha van élete
            }
            else
            {
                hearts[i].enabled = false; // A szív elrejtése, ha elfogyott az élete
            }
        }
    }

    // A boss halálának kezelése
    private void Die()
    {
        Debug.Log("Boss defeated!");

        // Aktiválja a szív GameObjectet
        if (heartPickup != null)
        {
            heartPickup.SetActive(true);
        }

        Destroy(gameObject); // Eltávolítja a boss objektumot
    }
}


/*using UnityEngine;
using UnityEngine.UI; // Az UI kezeléséhez
using TMPro;

public class Boss : MonoBehaviour
{
    public int maxLives = 3; // Maximális életek száma
    public int currentLives; // Jelenlegi életek száma
    public Image[] hearts; // A szívek UI elemek

    void Start()
    {
        currentLives = maxLives; // Kezdõ életek beállítása
        UpdateLivesUI();
    }

    // Ez a metódus hívódik meg, amikor a boss-t eltalálják
    public void TakeDamage()
    {
        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            Die(); // A boss meghal, ha elfogynak az életei
        }
    }

    // Frissíti a szívek UI megjelenítését
    private void UpdateLivesUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].enabled = true; // A szív megjelenítése, ha van élete
            }
            else
            {
                hearts[i].enabled = false; // A szív elrejtése, ha elfogyott az élete
            }
        }
    }

    // A boss halálának kezelése
    private void Die()
    {
        Debug.Log("Boss defeated!");
        // (pl. animáció, játék vége, stb.)

        Destroy(gameObject); // Eltávolítja a boss objektumot
    }

    /*
    // A lövések érzékeléséhez
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet")) // Feltételezve, hogy a játékos lövedékei "PlayerBullet" tag-el rendelkeznek
        {
            TakeDamage();
            Destroy(other.gameObject); // Eltávolítja a lövedéket
        }
    }
}*/

