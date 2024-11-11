using UnityEngine;

public class MainBoss : MonoBehaviour
{
    public GameObject enemyPrefab;  // Az ellens�gek prefabja
    public int numberOfEnemies = 5; // Ennyi ellens�get spawnol a boss
    public float verticalOffset = 1f; // A boss alatti t�vols�g, ahova az ellens�gek ker�lnek
    public GameObject leftBoundary;  // Bal oldali boundary
    public GameObject rightBoundary; // Jobb oldali boundary
    public float delayBeforeSpawning = 2f; // K�sleltet�s a spawn el�tt
    public float spawnInterval = 5f; // Az �jra spawnol�s id�intervalluma

    void Start()
    {
        // K�sleltetve spawnolja az ellens�geket
        InvokeRepeating("SpawnEnemies", delayBeforeSpawning, spawnInterval);
    }

    void SpawnEnemies()
    {
        // Ha a boss �lete m�g van
        Boss bossScript = GetComponent<Boss>();
        if (bossScript != null && bossScript.currentLives > 0)
        {
            // Sz�moljuk ki a boundary-k sz�ls� x poz�ci�it
            float leftBoundaryX = leftBoundary.transform.position.x;
            float rightBoundaryX = rightBoundary.transform.position.x;

            // Az ellens�gek a boss alatti sorban spawnol�dnak
            for (int i = 0; i < numberOfEnemies; i++)
            {
                // Random x poz�ci� a boundary-n bel�l
                float randomX = Mathf.Clamp(Random.Range(leftBoundaryX, rightBoundaryX), leftBoundaryX, rightBoundaryX);

                // Az ellens�gek poz�ci�ja egy sorral lejjebb, mint a boss
                Vector3 spawnPosition = new Vector3(randomX, transform.position.y - verticalOffset, 0);

                // Ellens�g l�trehoz�sa
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // Ha az ellens�g a bal oldalon lenne, fix�ljuk a poz�ci�j�t, hogy a k�perny�n bel�l maradjon
                if (enemy.transform.position.x < leftBoundaryX)
                {
                    enemy.transform.position = new Vector3(leftBoundaryX, enemy.transform.position.y, enemy.transform.position.z);
                }
                // Ha az ellens�g a jobb oldalon lenne, fix�ljuk a poz�ci�j�t
                else if (enemy.transform.position.x > rightBoundaryX)
                {
                    enemy.transform.position = new Vector3(rightBoundaryX, enemy.transform.position.y, enemy.transform.position.z);
                }
            }
        }
        else
        {
            CancelInvoke("SpawnEnemies"); // Meg�ll�tja az �jra spawnol�st, ha a boss meghalt
        }
    }
}
