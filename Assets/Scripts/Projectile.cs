using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject explosionPrefab;
    private PointManager pointManager;
    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up *moveSpeed * Time.deltaTime);
    }
    // Amikor a lövedék ütközik egy másik colliderrel
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellenõrizzük, hogy a lövedék egy ellenséggel ütközött
        if (collision.gameObject.tag == "Enemy")
        {
            // Robbanás effektus létrehozása
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);// Az ellenség megsemmisítése
            pointManager.UpdateScore(50); // Pontszám frissítése
            Destroy(gameObject); //Lövedék eltávolítása
        }
        if(collision.gameObject.tag == "Boss")
        {
            // Robbanás effektus létrehozása
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Hozzáférés a boss scripthez és élet csökkentése
            Boss boss = collision.gameObject.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(); // Csökkenti a boss életét
            }

            pointManager.UpdateScore(50); // Frissíti a pontszámot
            Destroy(gameObject); // Eltávolítja a lövedéket
        }
        //u.a.
        if (collision.gameObject.tag == "Asteroid")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(50);
            Destroy(gameObject);
        }
        //u.a.
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);

        }
    }
}
