using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 90f; // Adjust this value to control rotation speed
    private Rigidbody2D rb;
    private float targetRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // Lock rotation
    }

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Apply movement to the rigidbody
        rb.velocity = movement * speed;

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        // Calculate the target rotation angle based on input
        if (horizontalInput > 0 && verticalInput == 0)
        {
            targetRotation = 90f;
        }
        else if (horizontalInput < 0 && verticalInput == 0)
        {
            targetRotation = -90f;
        }
        else if (verticalInput > 0 && horizontalInput == 0)
        {
            targetRotation = 180f;
        }
        else if (verticalInput < 0 && horizontalInput == 0)
        {
            targetRotation = 0f;
        }
        else if (horizontalInput > 0 && verticalInput > 0)
        {
            targetRotation = 135f;
        }
        else if (horizontalInput > 0 && verticalInput < 0)
        {
            targetRotation = 45f;
        }
        else if (horizontalInput < 0 && verticalInput > 0)
        {
            targetRotation = -135f;
        }
        else if (horizontalInput < 0 && verticalInput < 0)
        {
            targetRotation = -45f;
        }

        // Smoothly rotate the character
        float currentRotation = rb.rotation;
        rb.rotation = Mathf.LerpAngle(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
