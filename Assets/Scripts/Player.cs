using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jumpKeyPressed;
    float horizontalInput;
    Rigidbody rigidbodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
            
        }

        horizontalInput = Input.GetAxis("Horizontal");


    }

    //Something to do with Physics Update (Makes sure Physics runs in identical manner, regardless of the computer power)
    void FixedUpdate()
    {
        if(jumpKeyPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpKeyPressed = false;

        }

        rigidbodyComponent.velocity = new Vector3(horizontalInput * 1.5f, rigidbodyComponent.velocity.y, 0);

    }

    
}
