using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public Button nextSceneButton; // Hivatkozz a gombra

    void Start()
    {
        nextSceneButton.onClick.AddListener(LoadNextScene); // Feliratkozunk a gomb kattint�s esem�ny�re
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Boss"); // Itt add meg a k�vetkez� jelenet nev�t
    }
}
