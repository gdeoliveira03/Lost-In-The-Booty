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

    //gravity variables
    float gravity = -9.8f;
    float groundedGravity = -.05f;

    // higher the faster the rotate time
    float rotationFactorPerFrame = 14.0f;
    public float walkSpeed;
    public float runSpeed;

    // jumping variables
    bool isJumpPressed = false;
    float initialJumpVelocity;
    float maxJumpHeight = 2.0f;
    float maxJumpTime = 0.8f;
    bool isJumping = false;
    int isJumpingHash;
    bool isJumpAnimating = false;


    // checks if slope limit has not been reached
    bool IsGroundBelowMaxSlope()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, characterController.height / 2 + 0.1f))
        {
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
            return slopeAngle <= characterController.slopeLimit;
        }
        return true; // If no ground detected, allow the jump.
    }


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
        isJumpingHash = Animator.StringToHash("isJumping");

        playerInput.CharacterControls.Move.started += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;
        playerInput.CharacterControls.Move.performed += onMovementInput;

        playerInput.CharacterControls.Run.started += onRun;
        playerInput.CharacterControls.Run.canceled += onRun;

        playerInput.CharacterControls.Jump.started += onJump;
        playerInput.CharacterControls.Jump.canceled += onJump;

        setupJumpVariables();
    }

    // assigns initial jump velocity as timeToApex
    void setupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight / Mathf.Pow(timeToApex, 2));
        initialJumpVelocity = (2 * maxJumpHeight)/ timeToApex;
    }

    // will change vectors if jump is valid
    void handleJump()
    {
        if(!isJumping && characterController.isGrounded && isJumpPressed && IsGroundBelowMaxSlope()){
            animator.SetBool(isJumpingHash, true);
            isJumpAnimating = true;
            isJumping = true;

            currentMovement.y = initialJumpVelocity * .5f;
            currentRunMovement.y = initialJumpVelocity *.5f;
        }
        else if(!isJumpPressed && isJumping && characterController.isGrounded){
            isJumping = false;

        }
    }

    // change boolean if jump is called
    void onJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
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
            if(isJumpAnimating) {
                animator.SetBool(isJumpingHash, false);
                isJumpAnimating = false;
            }

            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }
        else {
            float previousYVelocity = currentMovement.y;
            float newYVelocity = currentMovement.y + (gravity * Time.deltaTime);
            float nextYvelocity = (previousYVelocity + newYVelocity) * .5f;

            currentMovement.y = nextYvelocity;
            currentRunMovement.y = nextYvelocity;
            /*
            currentMovement.y += gravity * Time.deltaTime * 3.0f;
            currentRunMovement.y += gravity * Time.deltaTime * 3.0f; */
        }
    }


    /*
    // function that takes in world space vector3 and returns local space camera vector
    Vector3 ConvertToCameraSpace(Vector3 vectorToRotate)
    {

    }

    */

    // Update is called once per frame
    void Update()
    {
        
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
        
        handleGravity();
        handleJump();
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
