using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    private SpriteRenderer sprite;
    public float movementSpeed = 2f;
    [SerializeField] private LayerMask WhatIsGround;
    public float drag;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        sprite = GetComponent<SpriteRenderer>();
        // This will stop the player game object from rotating
        // Try to comment this line and see what happens
        rb.freezeRotation = true;
    }

    void Update()
    {

        // This will detect forward and backward movement
        horizontalInput = Input.GetAxis("Horizontal");
        // This will detect sideways movement
        verticalInput = Input.GetAxis("Vertical");

        // Calculate the direction to move the player
        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        // Move the player
        rb.AddForce(movementDirection * movementSpeed, ForceMode.Force);
        
        // Apply drag
        rb.drag = drag;

        UpdateAnimation();
        SurfaceAlignment();
    }

    void UpdateAnimation(){
        if (horizontalInput > 0.1f)
        {
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            sprite.flipX = true;
        }
    }

    void SurfaceAlignment(){

        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit info = new RaycastHit();
        if(Physics.Raycast(ray, out info, WhatIsGround)){
          transform.rotation = Quaternion.FromToRotation(Vector3.up, info.normal);
        }
    }
}
