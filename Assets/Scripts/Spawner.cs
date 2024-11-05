using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;  // Az aszteroida prefab
    public float spawnInterval = 2f;   // Mennyi idõnként generálódjanak az aszteroidák
    public float spawnYMin = 3f;       // Minimális Y koordináta
    public float spawnYMax = 6f;       // Maximális Y koordináta

    private GameObject leftBoundary;
    private GameObject rightBoundary;

    void Start()
    {
        // Keresd meg az összes "Boundary" taggel rendelkezõ objektumot
        GameObject[] boundaries = GameObject.FindGameObjectsWithTag("Boundary");

        if (boundaries.Length >= 2)
        {
            // Eldöntjük, melyik a bal és jobb határ a pozíció alapján
            if (boundaries[0].transform.position.x < boundaries[1].transform.position.x)
            {
                leftBoundary = boundaries[0];
                rightBoundary = boundaries[1];
            }
            else
            {
                leftBoundary = boundaries[1];
                rightBoundary = boundaries[0];
            }

            // Aszteroidák idõzített generálása
            InvokeRepeating("SpawnAsteroid", spawnInterval, spawnInterval);
        }
        else
        {
            Debug.LogError("Nem található legalább két Boundary tag a játékban!");
        }
    }

    void SpawnAsteroid()
    {
        // Véletlenszerû X koordináta a bal és jobb határ között
        float randomX = Random.Range(leftBoundary.transform.position.x, rightBoundary.transform.position.x);

        // Véletlenszerû Y koordináta a megadott tartományban
        float randomY = Random.Range(spawnYMin, spawnYMax);

        // Aszteroida pozíciója
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // Az aszteroida létrehozása
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}
