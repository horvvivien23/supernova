
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovements : MonoBehaviour
{
    public float moveSpeed;               // A mozgás sebessége
    public float leftBoundary;            // Bal oldali boundary
    public float rightBoundary;           // Jobb oldali boundary

    // Start is called before the first frame update
    void Start()
    {
        // A kezdõ pozíciók beállítása (opcionális)
    }

    // Update is called once per frame
    void Update()
    {
        // A hajó folyamatosan jobbra vagy balra mozog
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // Ha az ellenség a bal oldalon lép túl, visszafordítjuk
        if (transform.position.x <= leftBoundary)
        {
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
            moveSpeed = Mathf.Abs(moveSpeed);  // Mozgás jobbra
        }

        // Ha az ellenség a jobb oldalon lép túl, visszafordítjuk
        else if (transform.position.x >= rightBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
            moveSpeed = -Mathf.Abs(moveSpeed);  // Mozgás balra
        }
    }

    // Metódus, amely akkor hívódik meg, ha a hajó ütközik egy másik objektummal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellenõrizzük, hogy az ütközés a "Boundary" címkéjû objektummal történt-e
        if (collision.gameObject.tag == "Boundary")
        {
            // A hajó Y pozícióját csökkentjük 1 egységgel, hogy alacsonyabbra kerüljön
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

            // Megfordítjuk a hajó mozgásának irányát
            moveSpeed *= -1;
        }
    }
}

/*
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
        // A hajó folyamatosan jobbra mozog a megadott sebességgel
        transform.Translate(Vector2.right  * moveSpeed * Time.deltaTime);
    }
    // Metódus, amely akkor hívódik meg, ha a hajó ütközik egy másik objektummal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellenõrizzük, hogy az ütközés a "Boundary" címkéjû objektummal történt-e
        if (collision.gameObject.tag == "Boundary")
        {
            // A hajó Y pozícióját csökkentjük 1 egységgel, hogy alacsonyabbra kerüljön
            transform.position = new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z);
            // Megfordítjuk a hajó mozgásának irányát
            moveSpeed *= -1;
        }
    }
}
*/