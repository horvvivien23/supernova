using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    Text textField;
    int number;

    // Start is called before the first frame update
    // Megkeresi a "NewScene" nev� GameObject-et a jelenetben,
    // majd lek�ri a Text komponenst hozz�, �s azt rendeli a textField v�ltoz�hoz.
    // Ezut�n a textField v�ltoz� seg�ts�g�vel k�zvetlen�l kezelhetj�k a sz�veget a NewScene objektumon.
    void Start()
    {
        textField = GameObject.Find("NewScene").GetComponent<Text>();
       
    }

    
}
