using UnityEngine;

public class HelpController : MonoBehaviour
{
    public GameObject helpPanel;

    private bool isHelpActive = false;

    // Ezt a funkciót a súgó panel kezelésére használjuk
    public void ToggleHelp()
    {
        isHelpActive = !isHelpActive;
        helpPanel.SetActive(isHelpActive);
        Time.timeScale = isHelpActive ? 0 : 1; // Ha a súgó aktív, állítsuk le az idõt
    }

    void Update()
    {
        // ESC billentyû lenyomása
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleHelp();
        }
    }
}
