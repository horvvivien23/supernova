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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(50); 
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Boss")
        {
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
        if (collision.gameObject.tag == "Asteroid")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(50);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);

        }
    }
}
