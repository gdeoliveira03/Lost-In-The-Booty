using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    private InputActionAsset InputAction;

    public float speed;
    public float walkSpeed = 4;
    public float runSpeed = 8;
    private Vector2 move, mouseLook;
    private float isRun = 0;
    private float isAbility = 0;

    // send info to animator
    private Animator animator;

    // accessed when shift is clicked
    public void onRun(InputAction.CallbackContext context) {
        isRun = context.ReadValue<float>();
    }

    // called when ability 1 is clicked
    public void onAbility1(InputAction.CallbackContext context) {
        isAbility = 1;
    }

    // called when ability 2 is clicked
    public void onAbility2(InputAction.CallbackContext context) {
        isAbility = 2;
    }

    // called when ability 3 is clicked
    public void onAbility3(InputAction.CallbackContext context) {
        isAbility = 3;
    }

    // called when ability 4 is clicked
    public void onAbility4(InputAction.CallbackContext context) {
        isAbility = 4;
    }

    // called when ability 5 is clicked
    public void onAbility5(InputAction.CallbackContext context) {
        isAbility = 5;
    }

    // will be called for mouse vector 
    public void onMouseLook(InputAction.CallbackContext context) {

        mouseLook = context.ReadValue<Vector2>();
    }

    // accessed when "WASD" is pressed 
    public void OnMove(InputAction.CallbackContext context) {
        move = context.ReadValue<Vector2>();
        isAbility = 0; // allows player run again
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        // if the ability is pressed call ability function
        if(isAbility != 0) {

            useAbility();
            movePlayer();
        }
        else {
            movePlayer();
        }
        
    }

    public void movePlayer() {
        if (isRun > 0) {
            speed = runSpeed;
        }
        else {
            speed = walkSpeed;
        }
        // take in the movement
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if(isAbility == 0) 
        {
            if(movement != Vector3.zero) 
            {
                // character rotates and look at the location faced
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            }

            // have character move towards that location
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        

        // float to use as Speed parameter for animator
        float charSpeed = (movement.magnitude * speed);
        animator.SetFloat("Speed", charSpeed);
    }

    
    public void useAbility() {
        
        Debug.Log("Ability used float is: " + isAbility);
        
    } 
}
