using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // A SceneManager osztály LoadScene metódusa betölti a megadott nevû jelenetet
        SceneManager.LoadScene(sceneName);
    }
}
