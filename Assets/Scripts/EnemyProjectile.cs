using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // A lövedék sebessége, amely meghatározza, hogy milyen gyorsan mozog a képernyõn lefelé.
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // A lövedék folyamatosan lefelé mozog a képernyõn a `speed` változó értékével szorozva,
        // figyelembe véve a frame-enkénti idõtartamot (Time.deltaTime) a folyamatos mozgás érdekében.
        transform.Translate(Vector2.down * speed * Time.deltaTime); 
    }
    // Ez a metódus akkor hívódik meg, amikor a lövedék ütközik egy másik 2D Collider-rel rendelkezõ objektummal.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ha az ütközésben részt vevõ objektum tag-je "Boundary",
        // akkor a lövedék megsemmisül, ezzel elkerülve a képernyõn kívüli mozgást.
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }

    }
}
