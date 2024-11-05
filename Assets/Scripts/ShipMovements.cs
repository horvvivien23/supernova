using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovements : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // A haj� folyamatosan jobbra mozog a megadott sebess�ggel
        transform.Translate(Vector2.right  * moveSpeed * Time.deltaTime);
    }
    // Met�dus, amely akkor h�v�dik meg, ha a haj� �tk�zik egy m�sik objektummal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellen�rizz�k, hogy az �tk�z�s a "Boundary" c�mk�j� objektummal t�rt�nt-e
        if (collision.gameObject.tag == "Boundary")
        {
            // A haj� Y poz�ci�j�t cs�kkentj�k 1 egys�ggel, hogy alacsonyabbra ker�lj�n
            transform.position = new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z);
            // Megford�tjuk a haj� mozg�s�nak ir�ny�t
            moveSpeed *= -1;
        }
    }
}
