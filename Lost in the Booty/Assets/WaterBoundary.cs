using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoundary : MonoBehaviour
{
    [SerializeField] private float waterDepth = -5f; // Adjust this value to the depth of your water collider

    private void Update()
    {
        // Check if the player's position is below the water depth
        if (transform.position.y < waterDepth)
        {
            // If the player is below the water, restrict movement
            RestrictPlayerMovement();
        }
    }

    private void RestrictPlayerMovement()
    {
        // You can implement your logic here to restrict player movement
        // For example, you can set the player's position to the nearest valid position
        // or prevent them from moving forward in the water.

        // Here is a simple example that stops movement in the z-axis when below the water
        Vector3 playerPosition = transform.position;
        playerPosition.z = Mathf.Max(playerPosition.z, transform.position.z);
        transform.position = playerPosition;
    }
}