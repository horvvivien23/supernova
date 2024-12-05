using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator; // Az anim�ci��rt felel�s Animator

    private void Start()
    {
        // Ellen�rizz�k, hogy van-e Animator
        if (animator != null)
        {
            // Az anim�ci� ind�t�sa, a n�v legyen az Animatorban szerepl� anim�ci� neve
            animator.Play("AnimationName");
        }
        else
        {
            Debug.LogWarning("Animator nincs be�ll�tva!");
        }
    }
}

/*using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator; // Az anim�ci��rt felel�s Animator
    public Canvas canvas; // A megjelen�tend� Canvas
    public GameObject animationObject; // Az anim�ci� GameObject-je

    private void Start()
    {
        // Kezdetben a Canvas l�thatatlan
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }

        // Ind�tsd el az anim�ci�t
        if (animator != null)
        {
            animator.Play("AnimationName"); // Cser�ld ki az anim�ci� nev�re
        }

        // 3 m�sodperc ut�n hajtsd v�gre a Canvas megjelen�t�s�t �s az anim�ci� elrejt�s�t
        Invoke("EndAnimationAndShowCanvas", 3f);
    }

    private void EndAnimationAndShowCanvas()
    {
        // Az anim�ci� GameObject deaktiv�l�sa
        if (animationObject != null)
        {
            animationObject.SetActive(false);
        }

        // A Canvas megjelen�t�se
        if (canvas != null)
        {
            canvas.gameObject.SetActive(true);
        }
    }
}*/
