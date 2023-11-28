/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Drag and drop your main character's Transform component here
    public float followSpeed = 5f;
    public float desiredDistance = 2f;  // Set the desired distance between Scruffy and the doctor
    public float stopRunningDistance = 1.5f;  // Set the distance at which the doctor should stop running
    public float distanceEpsilon = 0.01f;  // A small value to account for floating-point imprecision

    private Animator animator;  // Reference to the follower character's Animator component

    void Start()
    {
        // Get the Animator component from the follower character
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the follower to the player
            Vector3 direction = player.position - transform.position;

            // Calculate the distance between the doctor and Scruffy
            float distanceToPlayer = direction.magnitude;

            // Check if the doctor is within the acceptable range to stop running
            bool shouldStopRunning = distanceToPlayer < stopRunningDistance + distanceEpsilon;

            // Log distance information for debugging
            Debug.Log($"Distance to Player: {distanceToPlayer}, Stop Running Distance: {stopRunningDistance}, Should Stop Running: {shouldStopRunning}");

            // Calculate the desired position for the doctor
            Vector3 desiredPosition = player.position - direction.normalized * desiredDistance;

            // Move towards the desired position with a certain speed
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

            // Optionally, you can use LookAt to make the follower face the player
            transform.LookAt(player);

            // Set animator parameters based on movement and distance
            SetAnimatorParameters(direction.normalized, shouldStopRunning);
        }
    }

    // Set animator parameters based on movement direction and distance
    void SetAnimatorParameters(Vector3 movementDirection, bool shouldStopRunning)
    {
        if (animator != null)
        {
            // Assuming your Animator has parameters like "isWalking" and "isRunning"
            animator.SetBool("isWalking", movementDirection.magnitude > 0 && !shouldStopRunning);
            animator.SetBool("isRunning", movementDirection.magnitude > 0 && !shouldStopRunning);
            animator.SetBool("isIdle", shouldStopRunning);
        }
    }
}
*/

/*
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public float minDistance = 2f;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool isRunning = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Set initial destination to the current position
        navMeshAgent.destination = transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            // Set the destination to the player's position
            navMeshAgent.destination = player.position;

            // Check if the follower should run based on the remaining distance
            if (navMeshAgent.remainingDistance > minDistance)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }

            // Update the animator parameter
            animator.SetBool("isRunning", isRunning);
        }
    }
}
*/

using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Drag and drop your main character's Transform component here
    public float followSpeed = 5f;

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the follower to the player
            Vector3 direction = player.position - transform.position;

            // Move towards the player's position with a certain speed
            transform.Translate(direction.normalized * followSpeed * Time.deltaTime, Space.World);

            // Optionally, you can use LookAt to make the follower face the player
            transform.LookAt(player);
        }
    }
}
