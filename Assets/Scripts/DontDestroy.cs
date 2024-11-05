using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] presistentObjects = new GameObject[5];
    public int objectIndex;
    // Start is called before the first frame update
    void Awake()
    {
        // Ha a `presistentObjects` array-ben az adott indexen m�g nincs objektum (null),
        // akkor a jelenlegi `gameObject`-et hozz�rendeli ehhez az indexhez,
        // �s megh�vja a DontDestroyOnLoad met�dust, hogy az objektum a jelenetv�lt�sok sor�n is megmaradjon.
        if (presistentObjects[objectIndex] == null)
        {
            presistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        // Ha az adott indexen m�r van egy m�sik p�ld�ny, �s az nem a jelenlegi `gameObject`,
        // akkor ezt a p�ld�nyt megsemmis�ti, hogy ne legyenek duplik�lt objektumok.
        else if (presistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }

        
    }

  
}
