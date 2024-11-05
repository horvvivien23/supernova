using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{ 
    public GameObject enemyProjectile;// Az ellens�g l�ved�k prefab
    public float spawnTimer; // Az id�z�t�, ami a k�vetkez� l�ved�k spawnol�s�ig h�tral�v� id�t mutat
    public float spawnMax = 10;// Maxim�lis id� (m�sodperc) a spawnol�s el�tt
    public float spawnMin = 5;// Minim�lis id� (m�sodperc) a spawnol�s el�tt



    // Start is called before the first frame update
    void Start()
    {
        // V�letlenszer� id�z�t� be�ll�t�sa a minim�lis �s maxim�lis �rt�k k�z�tt
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        // Cs�kkentj�k a spawn id�z�t�t a delta id�vel
        spawnTimer -= Time.deltaTime;
        // Ha az id�z�t� el�rte a null�t
        if (spawnTimer <= 0) 
        {
            // L�trehozunk egy �j ellens�g l�ved�ket az aktu�lis poz�ci�ban
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            // �j v�letlenszer� id�z�t� be�ll�t�sa a k�vetkez� spawnol�shoz 
            spawnTimer = Random.Range(spawnMin, spawnMax); 
        } 
    }
}
