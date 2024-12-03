using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject ProjectalePrefab;
    // Start is called before the first frame update

    public AudioSource audioSource; // Referencia az AudioSource-ra
    public AudioClip shootSound;   // A lövés hangja
    void Start()
    {
        // Opcionálisan: ellenõrizheted, hogy az audioSource be van - e állítva
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Ellenõrizzük, hogy megnyomták-e a lövés gombot
        if (Input.GetButtonDown("Fire1"))
        {
            // Új lövedék példány létrehozása a megadott pozícióban
            Instantiate(ProjectalePrefab, transform.position, Quaternion.identity);
            // Lövés hang lejátszása
            if (audioSource != null && shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
    }
    
}
