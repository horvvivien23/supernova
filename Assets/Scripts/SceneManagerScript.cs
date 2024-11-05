using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // A SceneManager oszt�ly LoadScene met�dusa bet�lti a megadott nev� jelenetet
        SceneManager.LoadScene(sceneName);
    }
}
