using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    Text textField;
    int number;

    // Start is called before the first frame update
    void Start()
    {
        textField = GameObject.Find("NewScene").GetComponent<Text>();
       
    }

    
}
