using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public float heightAbovePlayer = 2.0f; // Height above the player
    public float distanceBehindPlayer = -5.0f; // Distance behind the player
    public float rotationSpeed = 2.0f; // Mouse rotation speed

    private Vector3 offset;
    private float currentRotation = 0.0f;

    private void Start()
    {
        offset = new Vector3(0.0f, heightAbovePlayer, distanceBehindPlayer);
    }

    private void LateUpdate()
    {
        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the current camera position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;

        // Rotate the camera around the player using mouse input
        currentRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, currentRotation, 0);

        // Make the camera look at the player's position
        transform.LookAt(target);
    }
}
