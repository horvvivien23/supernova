using UnityEngine;

public class HelpController : MonoBehaviour
{
    public GameObject helpPanel;

    private bool isHelpActive = false;

    // Ezt a funkci�t a s�g� panel kezel�s�re haszn�ljuk
    public void ToggleHelp()
    {
        isHelpActive = !isHelpActive;
        helpPanel.SetActive(isHelpActive);
        Time.timeScale = isHelpActive ? 0 : 1; // Ha a s�g� akt�v, �ll�tsuk le az id�t
    }

    void Update()
    {
        // ESC billenty� lenyom�sa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleHelp();
        }
    }
}
