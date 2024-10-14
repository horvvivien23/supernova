using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hInput;
    private float vInput;  // Függõleges input


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        // Függõleges input
        vInput = Input.GetAxisRaw("Vertical");
        //transform.Translate(Vector2.right*hInput *moveSpeed* Time.deltaTime);
        transform.Translate(new Vector2(hInput, vInput) * moveSpeed * Time.deltaTime);

    }
}
