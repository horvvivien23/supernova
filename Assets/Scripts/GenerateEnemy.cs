using UnityEngine;

public class MainBoss : MonoBehaviour
{
    public GameObject enemyPrefab;  // Az ellenségek prefabja
    public int numberOfEnemies = 5; // Ennyi ellenséget spawnol a boss
    public float verticalOffset = 1f; // A boss alatti távolság, ahova az ellenségek kerülnek
    public GameObject leftBoundary;  // Bal oldali boundary
    public GameObject rightBoundary; // Jobb oldali boundary
    public float delayBeforeSpawning = 2f; // Késleltetés a spawn elõtt
    public float spawnInterval = 5f; // Az újra spawnolás idõintervalluma

    void Start()
    {
        // Késleltetve spawnolja az ellenségeket
        InvokeRepeating("SpawnEnemies", delayBeforeSpawning, spawnInterval);
    }

    void SpawnEnemies()
    {
        // Ha a boss élete még van
        Boss bossScript = GetComponent<Boss>();
        if (bossScript != null && bossScript.currentLives > 0)
        {
            // Számoljuk ki a boundary-k szélsõ x pozícióit
            float leftBoundaryX = leftBoundary.transform.position.x;
            float rightBoundaryX = rightBoundary.transform.position.x;

            // Az ellenségek a boss alatti sorban spawnolódnak
            for (int i = 0; i < numberOfEnemies; i++)
            {
                // Random x pozíció a boundary-n belül
                float randomX = Mathf.Clamp(Random.Range(leftBoundaryX, rightBoundaryX), leftBoundaryX, rightBoundaryX);

                // Az ellenségek pozíciója egy sorral lejjebb, mint a boss
                Vector3 spawnPosition = new Vector3(randomX, transform.position.y - verticalOffset, 0);

                // Ellenség létrehozása
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // Ha az ellenség a bal oldalon lenne, fixáljuk a pozícióját, hogy a képernyõn belül maradjon
                if (enemy.transform.position.x < leftBoundaryX)
                {
                    enemy.transform.position = new Vector3(leftBoundaryX, enemy.transform.position.y, enemy.transform.position.z);
                }
                // Ha az ellenség a jobb oldalon lenne, fixáljuk a pozícióját
                else if (enemy.transform.position.x > rightBoundaryX)
                {
                    enemy.transform.position = new Vector3(rightBoundaryX, enemy.transform.position.y, enemy.transform.position.z);
                }
            }
        }
        else
        {
            CancelInvoke("SpawnEnemies"); // Megállítja az újra spawnolást, ha a boss meghalt
        }
    }
}
