using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] public float jumpHeight = 5f;
    [SerializeField] public float doubleJumpHeight = 7f;
    [SerializeField] public float speed = 2.5f;

    private bool jumpKeyPressed;
    private int doubleJump = 0 ;
    public float horizontalInput;
    public Rigidbody rigidbodyComponent;
    




    // Start is called before the first frame update
    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;  
        }

        horizontalInput = Input.GetAxis("Horizontal");


    }

    //Something to do with Physics Update (Makes sure Physics runs in identical manner, regardless of the computer power)
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = HorizontalMovement(horizontalInput, speed);



        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
        {
            doubleJump = 0;
        }


        if (jumpKeyPressed)
        {
            if(doubleJump == 1)
            {
                DoubleJump(doubleJumpHeight);
                doubleJump = 0;
            }

            if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
            {
                SingleJump(jumpHeight);
                jumpKeyPressed = false;
                doubleJump = 1;

            }


        }



    }

    public Vector3 HorizontalMovement(float horizontalInput, float speed)
    {
        return new Vector3(horizontalInput * speed, rigidbodyComponent.velocity.y, 0);
    }

    public void DoubleJump(float doubleJumpHeight)
    {
        rigidbodyComponent.AddForce(Vector3.up * doubleJumpHeight, ForceMode.VelocityChange);
    }

    public void SingleJump(float jumpHeight)
    {
        rigidbodyComponent.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }

}
