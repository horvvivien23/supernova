using UnityEngine;

public class BossHealthUI : MonoBehaviour
{
    public GameObject boss; // A boss referencia
    public Canvas bossLivesCanvas; // A boss �let�t jelz� canvas
    public Vector3 offset; // Az elmozdul�s a boss poz�ci�j�hoz k�pest

    void Update()
    {
        // A boss poz�ci�j�nak vil�gkoordin�t�j�t k�perny�koordin�t�v� alak�tjuk
        Vector3 bossScreenPosition = Camera.main.WorldToScreenPoint(boss.transform.position + offset);

        // A canvas sz�veinek poz�ci�j�t �ll�tjuk a k�perny�koordin�t�k alapj�n
        transform.position = bossScreenPosition;
    }
}
