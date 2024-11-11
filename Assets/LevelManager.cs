using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();  // Az összes ellenség
    public int nextLevelIndex;  // A következõ szint indexe

    void Start()
    {
        // Kezdetben hozzáadjuk az összes létezõ ellenséget és a boss-t, ha azok már a színt betöltve jelen vannak
        AddAllEnemiesAndBoss();
    }

    void Update()
    {
        // Ha minden ellenség el van pusztítva, akkor a következõ szintre ugrik
        if (AllEnemiesDefeated())
        {
            Debug.Log("Minden ellenség legyõzve! Betöltjük a következõ szintet.");
            SceneManager.LoadScene(nextLevelIndex);
        }
    }

    // Ellenõrzi, hogy minden ellenség el van-e pusztítva
    bool AllEnemiesDefeated()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)  // Ha van még életben ellenség
            {
                return false;
            }
        }
        return true;  // Ha az összes ellenség el van pusztítva
    }

    // Hozzáadja az összes jelenlegi ellenséget és a bosst, ha még nem lettek hozzáadva
    void AddAllEnemiesAndBoss()
    {
        // Az "Enemy" és "Boss" taggel rendelkezõ összes ellenség (beleértve a bosst)
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] allBosses = GameObject.FindGameObjectsWithTag("Boss");

        foreach (GameObject enemy in allEnemies)
        {
            if (!enemies.Contains(enemy))  // Ha még nincs benne a listában
            {
                enemies.Add(enemy);  // Hozzáadja az ellenséget
            }
        }

        foreach (GameObject boss in allBosses)
        {
            if (!enemies.Contains(boss))  // Ha még nincs benne a listában
            {
                enemies.Add(boss);  // Hozzáadja a bosst is
            }
        }
    }

    // Ezt a metódust akkor hívhatod, ha egy új ellenséget generáltál
    public void AddEnemy(GameObject newEnemy)
    {
        if (!enemies.Contains(newEnemy))  // Ellenõrzi, hogy nincs-e már benne a listában
        {
            enemies.Add(newEnemy);  // Hozzáadja az új ellenséget
        }
    }
}
