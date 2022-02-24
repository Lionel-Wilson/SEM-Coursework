using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float doubleJumpHeight = 7f;
    [SerializeField] private float speed = 2f;

    bool jumpKeyPressed;
    int doubleJump = 0 ;
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
        rigidbodyComponent.velocity = new Vector3(horizontalInput * speed, rigidbodyComponent.velocity.y, 0);
        
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
        {
            doubleJump = 0;
        }


        if (jumpKeyPressed)
        {
            if(doubleJump == 1)
            {
                rigidbodyComponent.AddForce(Vector3.up * doubleJumpHeight, ForceMode.VelocityChange);
                doubleJump = 0;
            }

            if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
            {
                rigidbodyComponent.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
                jumpKeyPressed = false;
                doubleJump = 1;

            }


        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }

}
