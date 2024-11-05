using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public Button nextSceneButton; // Hivatkozz a gombra

    void Start()
    {
        nextSceneButton.onClick.AddListener(LoadNextScene); // Feliratkozunk a gomb kattintás eseményére
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Boss"); // Itt add meg a következõ jelenet nevét
    }
}
