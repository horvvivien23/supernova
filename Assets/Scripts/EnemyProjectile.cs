using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // A l�ved�k sebess�ge, amely meghat�rozza, hogy milyen gyorsan mozog a k�perny�n lefel�.
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // A l�ved�k folyamatosan lefel� mozog a k�perny�n a `speed` v�ltoz� �rt�k�vel szorozva,
        // figyelembe v�ve a frame-enk�nti id�tartamot (Time.deltaTime) a folyamatos mozg�s �rdek�ben.
        transform.Translate(Vector2.down * speed * Time.deltaTime); 
    }
    // Ez a met�dus akkor h�v�dik meg, amikor a l�ved�k �tk�zik egy m�sik 2D Collider-rel rendelkez� objektummal.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ha az �tk�z�sben r�szt vev� objektum tag-je "Boundary",
        // akkor a l�ved�k megsemmis�l, ezzel elker�lve a k�perny�n k�v�li mozg�st.
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }

    }
}
