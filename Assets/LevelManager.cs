using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();  // Az �sszes ellens�g
    public int nextLevelIndex;  // A k�vetkez� szint indexe

    void Start()
    {
        // Kezdetben hozz�adjuk az �sszes l�tez� ellens�get �s a boss-t, ha azok m�r a sz�nt bet�ltve jelen vannak
        AddAllEnemiesAndBoss();
    }

    void Update()
    {
        // Ha minden ellens�g el van puszt�tva, akkor a k�vetkez� szintre ugrik
        if (AllEnemiesDefeated())
        {
            Debug.Log("Minden ellens�g legy�zve! Bet�ltj�k a k�vetkez� szintet.");
            SceneManager.LoadScene(nextLevelIndex);
        }
    }

    // Ellen�rzi, hogy minden ellens�g el van-e puszt�tva
    bool AllEnemiesDefeated()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)  // Ha van m�g �letben ellens�g
            {
                return false;
            }
        }
        return true;  // Ha az �sszes ellens�g el van puszt�tva
    }

    // Hozz�adja az �sszes jelenlegi ellens�get �s a bosst, ha m�g nem lettek hozz�adva
    void AddAllEnemiesAndBoss()
    {
        // Az "Enemy" �s "Boss" taggel rendelkez� �sszes ellens�g (bele�rtve a bosst)
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] allBosses = GameObject.FindGameObjectsWithTag("Boss");

        foreach (GameObject enemy in allEnemies)
        {
            if (!enemies.Contains(enemy))  // Ha m�g nincs benne a list�ban
            {
                enemies.Add(enemy);  // Hozz�adja az ellens�get
            }
        }

        foreach (GameObject boss in allBosses)
        {
            if (!enemies.Contains(boss))  // Ha m�g nincs benne a list�ban
            {
                enemies.Add(boss);  // Hozz�adja a bosst is
            }
        }
    }

    // Ezt a met�dust akkor h�vhatod, ha egy �j ellens�get gener�lt�l
    public void AddEnemy(GameObject newEnemy)
    {
        if (!enemies.Contains(newEnemy))  // Ellen�rzi, hogy nincs-e m�r benne a list�ban
        {
            enemies.Add(newEnemy);  // Hozz�adja az �j ellens�get
        }
    }
}
