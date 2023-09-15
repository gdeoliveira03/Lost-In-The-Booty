using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookFollowCamera : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float sensitivity = 2.0f; // Mouse sensitivity
    public float followSpeed = 5.0f; // Camera follow speed
    public float minYAngle = -80.0f; // Minimum vertical angle
    public float maxYAngle = 80.0f; // Maximum vertical angle

    private float rotationX = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    private void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the camera horizontally (around the player)
        player.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically (up and down)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle); // Clamp the vertical rotation

        // Apply the vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    private void LateUpdate()
    {
        // Calculate the desired camera position (behind the player)
        float distance = 5.0f; // Distance from the player
        float height = 2.0f; // Height above the player
        Vector3 targetPosition = player.position - player.forward * distance + player.up * height; // Adjust these values for desired camera position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);

        // Make the camera look at the player's position
        transform.LookAt(player.position + player.up * height); // Keep the camera's view level with the player's height
    }
}
