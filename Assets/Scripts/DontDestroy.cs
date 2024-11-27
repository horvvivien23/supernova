using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] persistentObjects = new GameObject[6];
    public int objectIndex;

    void Awake()
    {
        // Ha az objektum m�g nem l�tezik, akkor hozz�adjuk
        if (persistentObjects[objectIndex] == null)
        {
            persistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (persistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject); // T�r�lj�k, ha m�r l�tezik
        }
    }

    // A met�dus, amit a resetel�skor h�vhatunk
    public void ResetObjectState()
    {
        if (objectIndex == 0) // P�ld�ul a j�t�kos objektum resetel�se
        {
            var player = GetComponent<PlayerController>();
            if (player != null)
            {
                player.ResetPlayer();
            }
        }
        // Egy�b objektumok resetel�se itt, ha sz�ks�ges
    }
}
