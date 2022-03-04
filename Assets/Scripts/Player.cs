using System.Collections;
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
    private bool jumpKeyPressed;
    private int doubleJump = 0;
    private bool failedLanding = false;
    private float horizontalInput;
    private bool coinCollected;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;  
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -4)
        {
            transform.position = active_checkpoint;
            setFailedLanding();
        }
        

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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning", false);
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
        if(other.tag == "checkpoint")
        {
            active_checkpoint = transform.position;
        }

        else if(other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            setCoinCollected();
        }
    }

    public bool setCoinCollected()
    {
        if(coinCollected)
        {
            return coinCollected = false;
        } else
        {
            return coinCollected = true;
        }
    }

    public bool getCoinCollected()
    {
        return coinCollected;
    }

    public bool setFailedLanding()
    {
        if (failedLanding)
        {
            return failedLanding = false;
        }
        else
        {
            return failedLanding = true;
        }
    }

    public bool getFailedLanding()
    {
        return failedLanding;
    }

}
