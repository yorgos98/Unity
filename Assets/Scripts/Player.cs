using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodycomponent;

    private bool isgrounded;

    // Start is called before the first frame update
    void Start()
    {
       rigidbodycomponent = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    
    {
        // If statement saying if space is pressed down.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;

        }


        horizontalInput = Input.GetAxis("Horizontal");
    }


    private void FixedUpdate()
    {   
        if (!isgrounded)
        {
            return;
        }


         if (jumpKeyWasPressed)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up*5,  ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput,rigidbodycomponent.velocity.y ,0);

    }
    private void OnCollisionEnter(Collision collision)
    {
        isgrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isgrounded = false;
    }
}

