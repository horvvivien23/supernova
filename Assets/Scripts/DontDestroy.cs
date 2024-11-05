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
        // Ha a `presistentObjects` array-ben az adott indexen még nincs objektum (null),
        // akkor a jelenlegi `gameObject`-et hozzárendeli ehhez az indexhez,
        // és meghívja a DontDestroyOnLoad metódust, hogy az objektum a jelenetváltások során is megmaradjon.
        if (presistentObjects[objectIndex] == null)
        {
            presistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        // Ha az adott indexen már van egy másik példány, és az nem a jelenlegi `gameObject`,
        // akkor ezt a példányt megsemmisíti, hogy ne legyenek duplikált objektumok.
        else if (presistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }

        
    }

  
}
