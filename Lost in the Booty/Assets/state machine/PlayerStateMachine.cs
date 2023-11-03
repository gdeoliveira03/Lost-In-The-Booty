using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
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

    // state variables
    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    // getters and setters
    public CharacterController CharacterController { get { return characterController; } set {characterController = value; } }
    public PlayerBaseState CurrentState { get {return _currentState; } set {_currentState = value;}}
    public Animator Animator { get { return animator;}}
    public int IsJumpingHash { get { return isJumpingHash; } }
    public int IsRunningHash {get {return isRunningHash;} }
    public int IsWalkingHash {get {return isWalkingHash;} }

    public bool IsJumpPressed { get {return isJumpPressed;} set {isJumpPressed = value;} }
    public bool IsJumping { get { return isJumping;} set {isJumping = value;} }
    public bool IsJumpAnimating { get { return isJumpAnimating;} set {isJumpAnimating = value;} }
    public bool IsRunPressed { get {return isRunPressed;} }
    public bool IsMovementPressed {get {return isMovementPressed;} }

    public float InitialJumpVelocity {get { return initialJumpVelocity;} }
    public float Gravity { get { return gravity; } set {gravity = value; } }
    public float GroundedGravity { get { return groundedGravity; } set {groundedGravity = value; } }

    public float CurrentMovementY { get { return currentMovement.y;} set {currentMovement.y = value; } }
    public float CurrentRunMovementY { get { return currentRunMovement.y;} set {currentMovement.y = value; } }
    public float CurrentMovementX { get { return currentMovement.x;} set {currentMovement.x = value; } }
    public float CurrentRunMovementX { get { return currentRunMovement.x;} set {currentMovement.x = value; } }
    public float CurrentMovementZ { get { return currentMovement.z;} set {currentMovement.z = value; } }
    public float CurrentRunMovementZ { get { return currentRunMovement.z;} set {currentMovement.z = value; } }

    public float RunMultiplier { get { return runSpeed;} }

    public Vector2 CurrentMovementInput { get {return currentMovementInput;} }
    //public float AppliedMovementX { get {return }}
    //public float AppliedMovementY { get { return appliedtMovement.y;} set {currentMovement.y = value; } }
    /*
    public Vector3 CurrentMovement { get {return currentMovement;} } // might need to modify
    public Vector3 CurrentRunMovement { get {return currentRunMovement;} } // might need to modify */


    // (callback func) change boolean if jump is called
    void onJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
        Debug.Log("HELLO we have pressed jump");
    }

    // (callback func) handler for run
    void onRun(InputAction.CallbackContext context)
    {
        // read button value
        isRunPressed = context.ReadValueAsButton();
    }

    // (callback func) assign movement for walk / run
    void onMovementInput(InputAction.CallbackContext context) 
    {
        currentMovementInput = context.ReadValue<Vector2>();
        // assign x and z in 3D space from xy in 2D vector
        //currentMovement.x = currentMovementInput.x * walkSpeed;
        //currentMovement.z = currentMovementInput.y * walkSpeed;

        // multiply by runSpeed can be changed in project (public)
        //currentRunMovement.x = currentMovementInput.x * runSpeed;
        //currentRunMovement.z = currentMovementInput.y * runSpeed;

        // change boolean if moving
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
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


    // set the callbacks on awake
    void Awake() 
    {
        //set player input of type ScruffyInput class
        playerInput = new ScruffyInput();
        characterController = GetComponent<CharacterController>();

        // get the animator component that belongs to Scruffy
        animator = GetComponent<Animator>();

        // setup state
        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleRotation();
        _currentState.UpdateStates();
        characterController.Move(currentMovement * Time.deltaTime);
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
