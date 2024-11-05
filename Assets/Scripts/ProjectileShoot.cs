using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject ProjectalePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ellenõrizzük, hogy megnyomták-e a lövés gombot
        if (Input.GetButtonDown("Fire1"))
        {
            // Új lövedék példány létrehozása a megadott pozícióban
            Instantiate(ProjectalePrefab, transform.position, Quaternion.identity);
        }
    }
}
