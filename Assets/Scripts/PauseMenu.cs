using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetButtonDown("Cancel"))
=======
        if (Input.GetButtonDown("Pause"))
>>>>>>> 6ea5eda5593e496d3216cb857078b9e1085be706
        {
            if (isPaused) ResumeGame();
            else
            {
                PauseGame();
            }
           
                   
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
    }
}
