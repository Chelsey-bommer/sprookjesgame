using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    // A field editable from inside Unity with a default value of 5
    public float movementSpeed = 2f;
    public float drag;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
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
    }
}
