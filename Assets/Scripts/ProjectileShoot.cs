using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject ProjectalePrefab;
    // Start is called before the first frame update

    public AudioSource audioSource; // Referencia az AudioSource-ra
    public AudioClip shootSound;   // A l�v�s hangja
    void Start()
    {
        // Opcion�lisan: ellen�rizheted, hogy az audioSource be van - e �ll�tva
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Ellen�rizz�k, hogy megnyomt�k-e a l�v�s gombot
        if (Input.GetButtonDown("Fire1"))
        {
            // �j l�ved�k p�ld�ny l�trehoz�sa a megadott poz�ci�ban
            Instantiate(ProjectalePrefab, transform.position, Quaternion.identity);
            // L�v�s hang lej�tsz�sa
            if (audioSource != null && shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
    }
    
}
