using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cameraFollow : MonoBehaviour
{

    public Transform target;
    // how long it takes to reach our character
    // (larger means smoother)
    public float smoothTime = 0.3f;
    public Vector3 offset;

    // larger float means faster transition for camera angle
    private float rotationSpeed = 5.0f;

    private Vector3 velocity = Vector3.zero;
    private Quaternion targetRotation;
    private Quaternion initialRotation;

    // this int acts as a boolean to see if camera should be moving
    private int isCamActive = 0;

    // direction 0 = positive-z, 1 = negative-x, 2 = negative-z, and 3 = positive x  
    private int rotationCount = 0;

    // two seperate floats to prevent overWriting if both are are pressed
    private float isPressedDownR = 0.0f, isPressedDownL = 0.0f;

    
    // context called is "R" button type float
    public void rotateCamLeft(InputAction.CallbackContext context) 
    {
        isPressedDownL = context.ReadValue<float>();

        // when button is released
        if(isPressedDownL < 0.01f)
        {
            
            rotationCount++;

            // calculate the rotation that will occur
            targetRotation = Quaternion.Euler(0, 90*rotationCount, 0);

            // will now tell the update function to update target rotation
            isCamActive = 1;

            
            // prevents rotation from exceeding float limit in the future
            if(rotationCount > 3)
            {
                rotationCount = 0;
            }
        }
    }


    // context called is "E" button type float
    public void rotateCamRight(InputAction.CallbackContext context) 
    {
        isPressedDownR = context.ReadValue<float>();

        // when button is released
        if(isPressedDownR < 0.01f)
        {
            // make sure we are within bounds
            if(rotationCount != 0) {
                rotationCount--;
            }
            // if zero, it means our left direction is now 3
            else
            {
                rotationCount = 3;
            }

            // calculate the rotation that will occur
            targetRotation = Quaternion.Euler(0, 90*rotationCount, 0);

            // will now tell the update function to update target rotation
            isCamActive = 1;
            
            // prevents rotation from exceeding float limit in the future
            if(rotationCount > 3)
            {
                rotationCount = 0;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // initialize our camera rotation angles
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) 
        {

            Vector3 targetPosition = target.position + offset;

            // if the camera should not move, set the target to its current rotation
            if(isCamActive == 0) 
            {
                targetRotation = initialRotation;
            }
            
            // perform rotation smoothly
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);

        }
    }

}
