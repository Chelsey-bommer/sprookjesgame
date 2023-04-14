using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float horizontalMovement;
    public float verticalMovement;
    private Rigidbody rb;
    // A field editable from inside Unity with a default value of 5
    public float speed = 2f;

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
        horizontalMovement = Input.GetAxis("Horizontal");
        // This will detect sideways movement
        verticalMovement = Input.GetAxis("Vertical");

        // Calculate the direction to move the player
        Vector3 movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        // Move the player
        rb.AddForce(movementDirection * speed, ForceMode.Force);
    }
}
