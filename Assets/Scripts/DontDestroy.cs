using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] presistentObjects = new GameObject[3];
    public int objectIndex;
    // Start is called before the first frame update
    void Awake()
    {
        if (presistentObjects[objectIndex] == null)
        {
            presistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (presistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }

        
    }

  
}
