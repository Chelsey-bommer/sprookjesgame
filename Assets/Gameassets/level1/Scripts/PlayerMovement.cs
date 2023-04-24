using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    private SpriteRenderer sprite;
    private Animator anim;
    public float movementSpeed = 2f;
    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float time;

    public float drag;
    enum MovementState { idle, running, jumping, falling };
    

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
        // This will detect forward and backward movement
        horizontalInput = Input.GetAxis("Horizontal");
        // This will detect sideways movement
        verticalInput = Input.GetAxis("Vertical");

        // Calculate the direction to move the player
        Vector3 movementDirection = Vector3.forward * verticalInput + transform.right * horizontalInput;
        // Move the player
        rb.AddForce(movementDirection * movementSpeed, ForceMode.Force);
        
        // Apply drag
        rb.drag = drag;

        UpdateAnimation();
        SurfaceAlignment();
    }

    void UpdateAnimation()
    {
        MovementState state;

        if (horizontalInput > 0.1f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }else
        {
            state = MovementState.idle;
            //anim.SetBool("walking", false);

        }

        anim.SetInteger("state", (int)state);
    }



    void SurfaceAlignment()
    {

        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit info = new RaycastHit();
        Quaternion RotationRef = Quaternion.Euler(0, 0, 0);


        if (Physics.Raycast(ray, out info, WhatIsGround))
        {
            RotationRef = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, info.normal), animCurve.Evaluate(time));
            transform.rotation = Quaternion.Euler(45, transform.eulerAngles.y, RotationRef.eulerAngles.z);
        }
    }
}
