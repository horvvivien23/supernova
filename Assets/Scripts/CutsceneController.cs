using System.Collections;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Animator cutsceneAnimator;  // Animator hivatkoz�s a cutscene anim�ci�hoz
    public GameObject cutsceneObject;  // Az anim�ci� GameObject-je
    public float cutsceneDuration = 3f;  // Anim�ci� id�tartama

    void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        // Anim�ci� elind�t�sa
        cutsceneAnimator.SetTrigger("PlayCutscene");

        // V�r az anim�ci� id�tartama alatt
        yield return new WaitForSeconds(cutsceneDuration);

        // Anim�ci� objektum�nak deaktiv�l�sa
        cutsceneObject.SetActive(false);

        Debug.Log("Anim�ci� v�ge, j�t�k indul!");
    }
}
