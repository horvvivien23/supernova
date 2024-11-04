using System.Collections;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Animator cutsceneAnimator;  // Animator hivatkozás a cutscene animációhoz
    public GameObject cutsceneObject;  // Az animáció GameObject-je
    public float cutsceneDuration = 3f;  // Animáció idõtartama

    void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        // Animáció elindítása
        cutsceneAnimator.SetTrigger("PlayCutscene");

        // Vár az animáció idõtartama alatt
        yield return new WaitForSeconds(cutsceneDuration);

        // Animáció objektumának deaktiválása
        cutsceneObject.SetActive(false);

        Debug.Log("Animáció vége, játék indul!");
    }
}
