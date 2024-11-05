using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    Text textField;
    int number;

    // Start is called before the first frame update
    // Megkeresi a "NewScene" nevû GameObject-et a jelenetben,
    // majd lekéri a Text komponenst hozzá, és azt rendeli a textField változóhoz.
    // Ezután a textField változó segítségével közvetlenül kezelhetjük a szöveget a NewScene objektumon.
    void Start()
    {
        textField = GameObject.Find("NewScene").GetComponent<Text>();
       
    }

    
}
