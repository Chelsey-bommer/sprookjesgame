using UnityEngine;

public class NPCSway : MonoBehaviour
{
    public float swayAmount = 1f;       // Amount of sway
    public float swaySpeed = 1f;        // Speed of sway
    public float rotationAmount = 10f;  // Amount of rotation

    private Quaternion initialRotation; // Initial rotation of the NPC

    private void Start()
    {
        initialRotation = transform.rotation; // Store the initial rotation of the NPC
    }

    private void Update()
    {
        // Calculate the sway using a sine wave
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

        // Rotate the NPC around the y-axis based on the sway
        transform.rotation = initialRotation * Quaternion.Euler(0f, 0f, sway * rotationAmount);
    }
}
