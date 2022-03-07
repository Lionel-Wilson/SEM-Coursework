using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float doubleJumpHeight = 5f;
    [SerializeField] private float speed = 2.5f;


    private Vector3 active_checkpoint;
    List<int> visited_checkpoints = new List<int>();
    private bool jumpKeyPressed;
    private int doubleJump = 0;
    private int check_checkpoint = 0;
    private bool failedLanding;
    private float horizontalInput;
    private bool coinCollected;
    private bool passedCheckpoint;
    private Rigidbody rigidbodyComponent;

    private Animator anim;
    




    // Start is called before the first frame update
    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        active_checkpoint = transform.position;
        anim = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    private void Update()
    {
        //If spacebar is pressed, then jumpKeyPressed is set to True
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;  
        }

        //Moves the Chick in the horizontal direction
        horizontalInput = Input.GetAxis("Horizontal");


        //If the player fails to land a jump then they get respawned to the previous checkpoint
        if (transform.position.y < -4)
        {
            transform.position = active_checkpoint;
            //A function to change the boolean value of failedLanding
            setFailedLanding();
        }
        

    }

    //Something to do with Physics Update (Makes sure Physics runs in identical manner, regardless of the computer power)
    private void FixedUpdate()
    {
        //Controls how fast the chick moves
        rigidbodyComponent.velocity = HorizontalMovement(horizontalInput, speed);


        //If the chick is touching the ground then they cannot double jump
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
        {
            doubleJump = 0;
        }


        //Handles player jumping
        if (jumpKeyPressed)
        {
            //If DoubleJump is 1, then the player is in a valid position to double jump
            if(doubleJump == 1)
            {
                DoubleJump(doubleJumpHeight);
                doubleJump = 0;
            }

            //Checking if the player is on the ground and then perform the single jump height
            if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
            {
                SingleJump(jumpHeight);
                jumpKeyPressed = false;
                doubleJump = 1;

            }


        }

        //If the player presses the left or right arrow keys then the animation boolean of the chick is altered.
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }

    //Function calculating Horizontal Movement of the chick
    public Vector3 HorizontalMovement(float horizontalInput, float speed)
    {
        return new Vector3(horizontalInput * speed, rigidbodyComponent.velocity.y, 0);
    }

    //Function adding the force to trigger the double jump
    public void DoubleJump(float doubleJumpHeight)
    {
        rigidbodyComponent.AddForce(Vector3.up * doubleJumpHeight, ForceMode.VelocityChange);
    }

    //Function adding the force to trigger the single jump
    public void SingleJump(float jumpHeight)
    {
        rigidbodyComponent.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
    }

    //If the player passes a checkpoint or collects a coin
    private void OnTriggerEnter(Collider other)
    {
        //If player passes a checkpoint then add this to the active_checkpoint vector3
        if(other.tag == "checkpoint")
        {
            active_checkpoint = transform.position;
            //Gets the x position of the checkpoint
            check_checkpoint = (int)active_checkpoint.x;
            //Then check if this checkpoint exists in the list
            if (!visited_checkpoints.Contains(check_checkpoint))
            {
                //If the checkpoint is not in the visited_checkpoints list then we add it to it
                visited_checkpoints.Add(check_checkpoint);

                //We then also add the X value that is 1 greater and 1 smaller to ensure that random errors don't have an affect
                if(!visited_checkpoints.Contains(check_checkpoint + 1))
                {
                    visited_checkpoints.Add(check_checkpoint + 1);
                }

                if(!visited_checkpoints.Contains(check_checkpoint - 1))
                {
                    visited_checkpoints.Add(check_checkpoint - 1);
                }
                print(active_checkpoint.x);
                //We change the boolean value of passedCheckpoints to true
                setCheckpointPassed();

            }
        }

        //If player collects coin, then destroy the coin
        else if(other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            //To set the coin collected variable true or false
            setCoinCollected();
        }
    }

    public bool setCoinCollected()
    {
        //If coin is collected, then when this function is called the boolean value is flipped back
        if(coinCollected)
        {
            return coinCollected = false;
        } else
        {
            return coinCollected = true;
        }
    }

    //Returns the boolean value of coinCollected
    public bool getCoinCollected()
    {
        return coinCollected;
    }

    
    public bool setFailedLanding()
    {
        //If the failedLanding boolean is true, then when this function is called the boolean value is flipped back
        if (failedLanding)
        {
            return failedLanding = false;
        }
        else
        {
            return failedLanding = true;
        }
    }

    //The function returns the value of the failedLanding boolean
    public bool getFailedLanding()
    {
        return failedLanding;
    }

    public bool setCheckpointPassed()
    {
        //If checkpoint is passed, then when this function is called the boolean value is flipped back
        if (passedCheckpoint)
        {
            return passedCheckpoint = false;
        }
        else
        {
            return passedCheckpoint = true;
        }
    }

    //The function returns the value of the passedCheckpoint boolean
    public bool getCheckpointPassed()
    {
        return passedCheckpoint;
    }

}
