using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator; // Az animációért felelõs Animator

    private void Start()
    {
        // Ellenõrizzük, hogy van-e Animator
        if (animator != null)
        {
            // Az animáció indítása, a név legyen az Animatorban szereplõ animáció neve
            animator.Play("AnimationName");
        }
        else
        {
            Debug.LogWarning("Animator nincs beállítva!");
        }
    }
}

/*using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator; // Az animációért felelõs Animator
    public Canvas canvas; // A megjelenítendõ Canvas
    public GameObject animationObject; // Az animáció GameObject-je

    private void Start()
    {
        // Kezdetben a Canvas láthatatlan
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }

        // Indítsd el az animációt
        if (animator != null)
        {
            animator.Play("AnimationName"); // Cseréld ki az animáció nevére
        }

        // 3 másodperc után hajtsd végre a Canvas megjelenítését és az animáció elrejtését
        Invoke("EndAnimationAndShowCanvas", 3f);
    }

    private void EndAnimationAndShowCanvas()
    {
        // Az animáció GameObject deaktiválása
        if (animationObject != null)
        {
            animationObject.SetActive(false);
        }

        // A Canvas megjelenítése
        if (canvas != null)
        {
            canvas.gameObject.SetActive(true);
        }
    }
}*/
