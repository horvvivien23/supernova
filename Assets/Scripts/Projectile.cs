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
    // Amikor a l�ved�k �tk�zik egy m�sik colliderrel
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellen�rizz�k, hogy a l�ved�k egy ellens�ggel �tk�z�tt
        if (collision.gameObject.tag == "Enemy")
        {
            // Robban�s effektus l�trehoz�sa
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);// Az ellens�g megsemmis�t�se
            pointManager.UpdateScore(50); // Pontsz�m friss�t�se
            Destroy(gameObject); //L�ved�k elt�vol�t�sa
        }
        if(collision.gameObject.tag == "Boss")
        {
            // Robban�s effektus l�trehoz�sa
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Hozz�f�r�s a boss scripthez �s �let cs�kkent�se
            Boss boss = collision.gameObject.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(); // Cs�kkenti a boss �let�t
            }

            pointManager.UpdateScore(50); // Friss�ti a pontsz�mot
            Destroy(gameObject); // Elt�vol�tja a l�ved�ket
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
