using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private bool doJump;
    private bool isGrounded;
    private bool canDoubleJump;
    public bool enableDoubleJump;
    public Transform top_left;
    public Transform bottom_right;
    public LayerMask ground_layers;

    private Rigidbody rb;
    private SpriteRenderer sprite;
    private Animator anim;
    public float movementSpeed = 2f;
    public float jumpingPower = 600f;
    [SerializeField] private LayerMask WhatIsGround;

    public float drag;
    enum MovementState { idle, running, jumping, falling, backward, forward };


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        // This will stop the player game object from rotating
        rb.freezeRotation = true;
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(top_left.position, 2.5f, ground_layers);
        bool isGrounded = hitColliders.Length > 0;
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);


        if (Input.GetButtonDown("Jump"))
        {   //If jump button is pressed,
            if (isGrounded)
            {               // and player is on ground
                doJump = true;              // player will jump (in FixedUpdate),
                canDoubleJump = true;       // and player can double jump.
            }
            else if (enableDoubleJump)
            {   //If jump button is pressed, player is not on ground, but double jump is enabled in inspector,
                if (canDoubleJump)
                {       // and player has not used double jump yet,
                    doJump = true;          // player will jump again (in FixedUpdate),
                    canDoubleJump = false;  // and cannot jump again until he touches ground.
                }
            }
        }

        // // Apply drag
        // rb.drag = drag;

        UpdateAnimation();
        
    }

    void FixedUpdate(){

        if (doJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);    //Set upwards velocity to 0 to prevent double jump from jumping very high
            rb.AddForce(new Vector2(0, jumpingPower));  //Apply upwards force to player (jump)
            doJump = false;
            isGrounded = false;
        }

    }

    void UpdateAnimation()
    {
        MovementState state;
        //side to side walking
        if (horizontalInput > 0.1f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            //anim.SetBool("walking", false);

        }
        //backwards walking
        if (verticalInput > 0.1f)
        {
            state = MovementState.backward;

            if (horizontalInput > 0.1f)
            {
                sprite.flipX = true;
            }
            else if (horizontalInput < 0f)
            {
                sprite.flipX = false;
            }
        }
        if (verticalInput < 0f)
        {
            state = MovementState.forward;
        }
        //jumping
        if(rb.velocity.y > .1f){
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f){
        	state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }



}
