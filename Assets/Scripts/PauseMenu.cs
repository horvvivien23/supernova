using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // A játék állapotának nyomon követésére szolgáló változó, amely megmondja, hogy a játék szüneteltetve van-e.
    private bool isPaused;
    // A szünetpanel GameObject-je, amely a szüneteltetett játék során megjelenik.
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ellenõrzi, hogy a "Cancel" gomb (általában az ESC billentyû) meg lett-e nyomva.
        if (Input.GetButtonDown("Cancel"))
        {
            // Ha a játék szüneteltetve van, folytatja a játékot, különben szünetelteti.
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
