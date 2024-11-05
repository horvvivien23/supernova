using UnityEngine;

public class BossHealthUI : MonoBehaviour
{
    public GameObject boss; // A boss referencia
    public Canvas bossLivesCanvas; // A boss �let�t jelz� canvas
    public Vector3 offset; // Az elmozdul�s a boss poz�ci�j�hoz k�pest

    void Update()
    {
        // Ellen�rizz�k, hogy a boss l�tezik-e
        if (boss == null)
        {
            //Debug.LogWarning("Boss object is null. Please check if it has been destroyed.");
            return; // Ne folytassuk, ha a boss null
        }

        // A boss poz�ci�j�nak vil�gkoordin�t�j�t k�perny�koordin�t�v� alak�tjuk
        Vector3 bossScreenPosition = Camera.main.WorldToScreenPoint(boss.transform.position + offset);

        // A canvas sz�veinek poz�ci�j�t �ll�tjuk a k�perny�koordin�t�k alapj�n
        transform.position = bossScreenPosition;
    }

    // Met�dus a boss hal�l�nak kezel�s�re
    public void OnBossDeath()
    {
        if (boss != null)
        {
            Destroy(boss); // T�r�ld a boss-t
            boss = null; // �ll�tsd null-ra, hogy elker�ld a MissingReferenceException-t
            bossLivesCanvas.gameObject.SetActive(false); // Opci�: rejtsd el a canvas-t, ha a boss meghal
        }
    }
}
