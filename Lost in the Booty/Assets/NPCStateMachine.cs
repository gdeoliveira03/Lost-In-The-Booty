
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine;


public class NPCStateMachine : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 _cameraRelativeMovement;

    bool isMovementPressed;

    float gravity = -9.8f;
    float groundedGravity = -0.05f;

    float rotationFactorPerFrame = 14.0f;
    public float walkSpeed;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        // Subscribe to movement input
        // Replace this with your actual input handling
        // This is just for demonstration purposes
        currentMovementInput = new Vector2(0.0f, 0.0f);
    }

    void Update()
    {
        HandleMovement();
        ApplyGravity();

        // Convert movement to camera space
        _cameraRelativeMovement = ConvertToCameraSpace(currentMovement);

        // Apply movement to the CharacterController
        characterController.Move(_cameraRelativeMovement * Time.deltaTime);
    }

    void HandleMovement()
    {
        // Handle your movement logic here
        // Replace this with your actual movement input handling
        // This is just for demonstration purposes

        currentMovement.x = currentMovementInput.x * walkSpeed;
        currentMovement.z = currentMovementInput.y * walkSpeed;

        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;

        // Rotate the NPC
        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_cameraRelativeMovement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

        // Update animator parameters (assuming you have "isWalking" parameter)
        animator.SetBool("isWalking", isMovementPressed);
    }

    void ApplyGravity()
    {
        // Apply gravity to keep the NPC on the ground
        if (characterController.isGrounded)
        {
            currentMovement.y = groundedGravity;
        }
        else
        {
            currentMovement.y += gravity * Time.deltaTime;
        }
    }

    Vector3 ConvertToCameraSpace(Vector3 vectorToRotate)
    {
        // Your camera space conversion logic here
        // Replace this with your actual camera space conversion
        // This is just for demonstration purposes

        // For now, return the same vector (no conversion)
        return vectorToRotate;
    }
}
