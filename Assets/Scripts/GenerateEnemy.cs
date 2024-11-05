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
                float randomX = Random.Range(leftBoundaryX, rightBoundaryX);

                // Az ellens�gek poz�ci�ja egy sorral lejjebb, mint a boss
                Vector3 spawnPosition = new Vector3(randomX, transform.position.y - verticalOffset, 0);

                // Ellens�g l�trehoz�sa
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
        else
        {
            CancelInvoke("SpawnEnemies"); // Meg�ll�tja az �jra spawnol�st, ha a boss meghalt
        }
    }
}


/*using UnityEngine;

public class MainBoss : MonoBehaviour
{
    public GameObject enemyPrefab;  // Az ellens�gek prefabja
    public int numberOfEnemies = 5; // Ennyi ellens�get spawnol a boss
    public float verticalOffset = 1f; // A boss alatti t�vols�g, ahova az ellens�gek ker�lnek
    public GameObject leftBoundary;  // Bal oldali boundary
    public GameObject rightBoundary; // Jobb oldali boundary
    public float delayBeforeSpawning = 2f; // K�sleltet�s a spawn el�tt

    void Start()
    {
        // K�sleltetve spawnolja az ellens�geket
        Invoke("SpawnEnemies", delayBeforeSpawning);
    }

    void SpawnEnemies()
    {
        // Sz�moljuk ki a boundary-k sz�ls� x poz�ci�it
        float leftBoundaryX = leftBoundary.transform.position.x;
        float rightBoundaryX = rightBoundary.transform.position.x;

        // Az ellens�gek a boss alatti sorban spawnol�dnak
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Random x poz�ci� a boundary-n bel�l
            float randomX = Random.Range(leftBoundaryX, rightBoundaryX);

            // Az ellens�gek poz�ci�ja egy sorral lejjebb, mint a boss
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y - verticalOffset, 0);

            // Ellens�g l�trehoz�sa
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
*/