using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{ 
    public GameObject enemyProjectile;// Az ellenség lövedék prefab
    public float spawnTimer; // Az idõzítõ, ami a következõ lövedék spawnolásáig hátralévõ idõt mutat
    public float spawnMax = 10;// Maximális idõ (másodperc) a spawnolás elõtt
    public float spawnMin = 5;// Minimális idõ (másodperc) a spawnolás elõtt



    // Start is called before the first frame update
    void Start()
    {
        // Véletlenszerû idõzítõ beállítása a minimális és maximális érték között
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        // Csökkentjük a spawn idõzítõt a delta idõvel
        spawnTimer -= Time.deltaTime;
        // Ha az idõzítõ elérte a nullát
        if (spawnTimer <= 0) 
        {
            // Létrehozunk egy új ellenség lövedéket az aktuális pozícióban
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            // Új véletlenszerû idõzítõ beállítása a következõ spawnoláshoz 
            spawnTimer = Random.Range(spawnMin, spawnMax); 
        } 
    }
}
