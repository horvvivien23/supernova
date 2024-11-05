using UnityEngine;

public class BossHealthUI : MonoBehaviour
{
    public GameObject boss; // A boss referencia
    public Canvas bossLivesCanvas; // A boss életét jelzõ canvas
    public Vector3 offset; // Az elmozdulás a boss pozíciójához képest

    void Update()
    {
        // Ellenõrizzük, hogy a boss létezik-e
        if (boss == null)
        {
            //Debug.LogWarning("Boss object is null. Please check if it has been destroyed.");
            return; // Ne folytassuk, ha a boss null
        }

        // A boss pozíciójának világkoordinátáját képernyõkoordinátává alakítjuk
        Vector3 bossScreenPosition = Camera.main.WorldToScreenPoint(boss.transform.position + offset);

        // A canvas szíveinek pozícióját állítjuk a képernyõkoordináták alapján
        transform.position = bossScreenPosition;
    }

    // Metódus a boss halálának kezelésére
    public void OnBossDeath()
    {
        if (boss != null)
        {
            Destroy(boss); // Töröld a boss-t
            boss = null; // Állítsd null-ra, hogy elkerüld a MissingReferenceException-t
            bossLivesCanvas.gameObject.SetActive(false); // Opció: rejtsd el a canvas-t, ha a boss meghal
        }
    }
}
