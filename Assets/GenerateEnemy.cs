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
                float randomX = Random.Range(leftBoundaryX, rightBoundaryX);

                // Az ellenségek pozíciója egy sorral lejjebb, mint a boss
                Vector3 spawnPosition = new Vector3(randomX, transform.position.y - verticalOffset, 0);

                // Ellenség létrehozása
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
        else
        {
            CancelInvoke("SpawnEnemies"); // Megállítja az újra spawnolást, ha a boss meghalt
        }
    }
}


/*using UnityEngine;

public class MainBoss : MonoBehaviour
{
    public GameObject enemyPrefab;  // Az ellenségek prefabja
    public int numberOfEnemies = 5; // Ennyi ellenséget spawnol a boss
    public float verticalOffset = 1f; // A boss alatti távolság, ahova az ellenségek kerülnek
    public GameObject leftBoundary;  // Bal oldali boundary
    public GameObject rightBoundary; // Jobb oldali boundary
    public float delayBeforeSpawning = 2f; // Késleltetés a spawn elõtt

    void Start()
    {
        // Késleltetve spawnolja az ellenségeket
        Invoke("SpawnEnemies", delayBeforeSpawning);
    }

    void SpawnEnemies()
    {
        // Számoljuk ki a boundary-k szélsõ x pozícióit
        float leftBoundaryX = leftBoundary.transform.position.x;
        float rightBoundaryX = rightBoundary.transform.position.x;

        // Az ellenségek a boss alatti sorban spawnolódnak
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Random x pozíció a boundary-n belül
            float randomX = Random.Range(leftBoundaryX, rightBoundaryX);

            // Az ellenségek pozíciója egy sorral lejjebb, mint a boss
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y - verticalOffset, 0);

            // Ellenség létrehozása
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
*/