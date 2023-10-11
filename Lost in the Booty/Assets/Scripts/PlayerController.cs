using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    
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

    // called when ability is clicked
    public void onAbility(InputAction.CallbackContext context) {
        isAbility = context.ReadValue<float>();
    }


    // will be called for mouse vector 
    public void onMouseLook(InputAction.CallbackContext context) {

        mouseLook = context.ReadValue<Vector2>();
    }

    // accessed when "WASD" is pressed 
    public void OnMove(InputAction.CallbackContext context) {
        move = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

        // if the ability is pressed call ability function
        if(isAbility != 0) {
            useAbility();
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


        if(movement != Vector3.zero) {
            // character rotates and look at the location faced
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        // have character move towards that location
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // float to use as Speed parameter for animator
        float charSpeed = (movement.magnitude * speed);
        animator.SetFloat("Speed", charSpeed);
    }

    public void useAbility() {
       
    }
}
