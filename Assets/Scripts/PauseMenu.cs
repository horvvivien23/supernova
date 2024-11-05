using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // A j�t�k �llapot�nak nyomon k�vet�s�re szolg�l� v�ltoz�, amely megmondja, hogy a j�t�k sz�neteltetve van-e.
    private bool isPaused;
    // A sz�netpanel GameObject-je, amely a sz�neteltetett j�t�k sor�n megjelenik.
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ellen�rzi, hogy a "Cancel" gomb (�ltal�ban az ESC billenty�) meg lett-e nyomva.
        if (Input.GetButtonDown("Cancel"))
        {
            // Ha a j�t�k sz�neteltetve van, folytatja a j�t�kot, k�l�nben sz�netelteti.
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
