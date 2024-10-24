using UnityEngine;

public class BossHealthUI : MonoBehaviour
{
    public GameObject boss; // A boss referencia
    public Canvas bossLivesCanvas; // A boss életét jelzõ canvas
    public Vector3 offset; // Az elmozdulás a boss pozíciójához képest

    void Update()
    {
        // A boss pozíciójának világkoordinátáját képernyõkoordinátává alakítjuk
        Vector3 bossScreenPosition = Camera.main.WorldToScreenPoint(boss.transform.position + offset);

        // A canvas szíveinek pozícióját állítjuk a képernyõkoordináták alapján
        transform.position = bossScreenPosition;
    }
}
