using UnityEngine;

public class BasicScruffyMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Apply movement to the character
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
