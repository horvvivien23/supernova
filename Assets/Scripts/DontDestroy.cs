using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] persistentObjects = new GameObject[6];
    public int objectIndex;

    void Awake()
    {
        // Ha az objektum még nem létezik, akkor hozzáadjuk
        if (persistentObjects[objectIndex] == null)
        {
            persistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (persistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject); // Töröljük, ha már létezik
        }
    }

    // A metódus, amit a reseteléskor hívhatunk
    public void ResetObjectState()
    {
        if (objectIndex == 0) // Például a játékos objektum resetelése
        {
            var player = GetComponent<PlayerController>();
            if (player != null)
            {
                player.ResetPlayer();
            }
        }
        // Egyéb objektumok resetelése itt, ha szükséges
    }
}
