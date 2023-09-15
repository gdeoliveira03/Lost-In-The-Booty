using UnityEngine;

public class Scruffy_Movement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5.0f;
    public float groundCheckDistance = 0.5f; // Adjust this value based on your terrain.
    public LayerMask groundLayer = LayerMask.GetMask("Ground");

    private Rigidbody rb; // Reference to the Rigidbody component.

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component.
        rb.freezeRotation = true; // Freeze rotation to prevent unwanted rotations.
    }

    void Update()
    {
        // Calculate the player's movement direction
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Set the "Speed" parameter in the Animator Controller
        float speed = Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);
        animator.SetFloat("Speed", speed);

        // Check if the character is moving (speed greater than 0)
        bool isMoving = speed > 0;
        animator.SetBool("IsMoving", isMoving);

        // Calculate movement vector based on input
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Check if the character is grounded
        bool isGrounded = IsGrounded();

        // Apply physics-based movement only if grounded
        if (isGrounded)
        {
            // Move the character based on input using Rigidbody velocity
            rb.velocity = movement * moveSpeed;
        }
    }

    bool IsGrounded()
    {
        // Define raycast positions around the character's base.
        Vector3[] raycastPositions = new Vector3[]
        {
            transform.position + Vector3.forward * 0.2f,
            transform.position - Vector3.forward * 0.2f,
            transform.position + Vector3.right * 0.2f,
            transform.position - Vector3.right * 0.2f,
            transform.position + Vector3.forward * 0.2f + Vector3.right * 0.2f,
            transform.position - Vector3.forward * 0.2f + Vector3.right * 0.2f,
            transform.position + Vector3.forward * 0.2f - Vector3.right * 0.2f,
            transform.position - Vector3.forward * 0.2f - Vector3.right * 0.2f
        };

        foreach (var position in raycastPositions)
        {
            // Perform raycast checks for each position.
            if (Physics.Raycast(position, Vector3.down, groundCheckDistance, groundLayer))
            {
                return true; // If any ray hits the ground, return true.
            }
        }

        return false; // If none of the rays hit the ground, return false.
    }
}
