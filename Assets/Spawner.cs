using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;  // Az aszteroida prefab
    public float spawnInterval = 2f;   // Mennyi id�nk�nt gener�l�djanak az aszteroid�k
    public float spawnYMin = 3f;       // Minim�lis Y koordin�ta
    public float spawnYMax = 6f;       // Maxim�lis Y koordin�ta

    private GameObject leftBoundary;
    private GameObject rightBoundary;

    void Start()
    {
        // Keresd meg az �sszes "Boundary" taggel rendelkez� objektumot
        GameObject[] boundaries = GameObject.FindGameObjectsWithTag("Boundary");

        if (boundaries.Length >= 2)
        {
            // Eld�ntj�k, melyik a bal �s jobb hat�r a poz�ci� alapj�n
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

            // Aszteroid�k id�z�tett gener�l�sa
            InvokeRepeating("SpawnAsteroid", spawnInterval, spawnInterval);
        }
        else
        {
            Debug.LogError("Nem tal�lhat� legal�bb k�t Boundary tag a j�t�kban!");
        }
    }

    void SpawnAsteroid()
    {
        // V�letlenszer� X koordin�ta a bal �s jobb hat�r k�z�tt
        float randomX = Random.Range(leftBoundary.transform.position.x, rightBoundary.transform.position.x);

        // V�letlenszer� Y koordin�ta a megadott tartom�nyban
        float randomY = Random.Range(spawnYMin, spawnYMax);

        // Aszteroida poz�ci�ja
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // Az aszteroida l�trehoz�sa
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}
