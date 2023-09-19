using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    
    public float speed;
    private Vector2 move;

    // send info to animator
    private Animator animator;

    public void onMove(InputAction.CallbackContext context) {
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

        
    }

    public void movePlayer() {

        // take in the movement
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        // character rotates and look at the location faced
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        // have character move towards that location
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // float to use as Speed parameter for animator
        float charSpeed = (movement.magnitude * speed);
        animator.SetFloat("Speed", charSpeed);
    }
}
