using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    // call class ScruffyInput
    ScruffyInput playerInput;

    CharacterController characterController;
    Animator animator;

    // hash optomization
    int isWalkingHash;
    int isRunningHash;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;

    bool isMovementPressed;
    bool isRunPressed;

    // higher the faster the rotate time
    float rotationFactorPerFrame = 14.0f;
    public float walkSpeed;
    public float runSpeed;
    
    void Awake() 
    {
        //set player input of type ScruffyInput class
        playerInput = new ScruffyInput();
        characterController = GetComponent<CharacterController>();

        // get the animator component that belongs to Scruffy
        animator = GetComponent<Animator>();

        // set hash to our animators 
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        playerInput.CharacterControls.Move.started += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;
        playerInput.CharacterControls.Move.performed += onMovementInput;

        playerInput.CharacterControls.Run.started += onRun;
        playerInput.CharacterControls.Run.canceled += onRun;
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        // current rotation of our character
        Quaternion currentRotation = transform.rotation;

        // creates a new rotation where the player is curr pressing
        if(isMovementPressed) {
           Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
           transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame *Time.deltaTime);
        }
    }

    void onRun(InputAction.CallbackContext context)
    {
        // read button value
        isRunPressed = context.ReadValueAsButton();
    }

    void onMovementInput(InputAction.CallbackContext context) 
    {
        currentMovementInput = context.ReadValue<Vector2>();
        // assign x and z in 3D space from xy in 2D vector
        currentMovement.x = currentMovementInput.x * walkSpeed;
        currentMovement.z = currentMovementInput.y * walkSpeed;

        // multiply by runSpeed can be changed in project (public)
        currentRunMovement.x = currentMovementInput.x * runSpeed;
        currentRunMovement.z = currentMovementInput.y * runSpeed;

        // change boolean if moving
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void handleAnimation()
     {
         bool isWalking = animator.GetBool(isWalkingHash);
         bool isRunning = animator.GetBool(isRunningHash);

         // if input inserted and animation is not walking, set to walk
         if(isMovementPressed && !isWalking) {
             animator.SetBool("isWalking", true);
         }

         //if input not inserted and animation is walking, set to stop
         else if(!isMovementPressed && isWalking) {
             animator.SetBool("isWalking", false);
         }

         // if both move and run are pressed but not currently running
         if((isMovementPressed && isRunPressed) && !isRunning) {
             // set animator bool true to run
             animator.SetBool(isRunningHash, true);
         }
         // if no movement or run detected and currently is running
         else if ((!isMovementPressed || !isRunPressed) && isRunning) {
             // set animator boolean false to stop running
             animator.SetBool(isRunningHash, false);
         }
     }


     // temp function to lightly handle gravity
    void handleGravity() 
    {
        if (characterController.isGrounded) {
            float groundedGravity = -.05f;
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }
        else {
            float gravity = -9.8f;
            currentMovement.y += gravity * Time.deltaTime * 3.0f;
            currentRunMovement.y += gravity * Time.deltaTime * 3.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleGravity();
        handleRotation();
        handleAnimation();

        // if character is running then multiply the speed
        if (isRunPressed) {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }
        // if not then keep the current movement
        else {
            // constant update to move based on currentMovement 
            characterController.Move(currentMovement * Time.deltaTime);
        }
        
        
    }

    void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }

    void OnDisable() 
    {
        playerInput.CharacterControls.Disable();
    }
}
