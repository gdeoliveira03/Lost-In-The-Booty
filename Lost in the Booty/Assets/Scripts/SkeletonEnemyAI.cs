using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        Patrol,
        Chase,
        Attack
    }

    private bool isPaused = false;
    private float patrolTimer = 0f;
    private float patrolPauseTimer = 0f;
    private float timeUntilNextAttack = 0f;
    private float runSpeed = 4f;
    private float walkSpeed = 2f;

    public EnemyState currentState = EnemyState.Patrol;

    public float patrolAreaRadius = 10f; // Set the radius of the patrol area
    public float patrolInterval = 5f; // Set the interval between patrols
    public float patrolPauseDuration = 2f;
    public float attackCooldown = 2f;
    public float chaseSpeed = 4f;
    public float patrolSpeed = 2f;

    public float chaseDistance = 10f;
    public float attackDistance = 2f;

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private EnemyStats enemyStats;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyStats = GetComponent<EnemyStats>();
        animator = GetComponent<Animator>();

        navMeshAgent.enabled = true;

        SetState(EnemyState.Patrol);
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    void SetState(EnemyState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case EnemyState.Patrol:
                InitializePatrolState();
                break;
            case EnemyState.Chase:
                InitializeChaseState();
                break;
            case EnemyState.Attack:
                InitializeAttackState();
                break;
        }
    }

    void InitializePatrolState()
    {
        Debug.Log("Patrolling");
        // Example: Stop any ongoing chase or attack behaviors
        StopChase();
        StopAttack();

        // Set walking speed to patrol
        navMeshAgent.speed = patrolSpeed;

        // Example: Set up patrol-specific variables
        SetRandomDestinationInPatrolArea();

        isPaused = false;
        animator.SetBool("IsPaused", isPaused);
        animator.SetBool("IsPatrolling", true);
        animator.SetBool("IsChasing", false);
    }

    void InitializeChaseState()
    {
        Debug.Log("Chasing");
        // Example: Stop any ongoing patrol or attack behaviors
        StopPatrol();
        StopAttack();

        navMeshAgent.speed = chaseSpeed;

        animator.SetBool("IsChasing", true);
        animator.SetBool("IsPatrolling", false);
    }

    void InitializeAttackState()
    {
        Debug.Log("Attacking");
        // Example: Stop any ongoing patrol or chase behaviors
        StopPatrol();
        StopChase();

        animator.SetBool("IsAttacking", true);
        animator.SetBool("IsChasing", false);
        animator.SetBool("IsPatrolling", false);
    }

    void StopPatrol()
    {
        // Example: Stop patrol-related behaviors
        animator.SetBool("IsPatrolling", false);
        navMeshAgent.isStopped = true;
    }

    void StopChase()
    {
        // Example: Stop chase-related behaviors
        animator.SetBool("IsChasing", false);
        navMeshAgent.isStopped = true;
    }

    void StopAttack()
    {
        // Example: Stop attack-related behaviors
        navMeshAgent.isStopped = true;
    }

    void Patrol()
    {
        // Set IsPatrolling parameter in the Animator
        animator.SetBool("IsPatrolling", true);

        // Set the "IsPaused" parameter in the Animator
        animator.SetBool("IsPaused", isPaused);

        if (isPaused)
        {
            // Check if the patrol pause timer has elapsed
            if (patrolPauseTimer <= 0f)
            {
                // Resume patrolling
                isPaused = false;

                // Set a random destination within the patrol area
                SetRandomDestinationInPatrolArea();

                // Reset the patrol timer
                patrolTimer = patrolInterval;
            }
            else
            {
                // Continue counting down the patrol pause timer
                patrolPauseTimer -= Time.deltaTime;
            }
        }
        else
        {
            // Check if the patrol timer has elapsed
            if (patrolTimer <= 0f)
            {
                // Pause patrolling
                isPaused = true;

                // Reset the patrol pause timer
                patrolPauseTimer = patrolPauseDuration;

                // Stop the navigation agent immediately
                navMeshAgent.isStopped = true;
            }
            else
            {
                // Continue counting down the patrol timer
                patrolTimer -= Time.deltaTime;

                // Move towards the current patrol destination
                navMeshAgent.isStopped = false;

                // Check if the skeleton has reached the destination
                if (!navMeshAgent.hasPath || navMeshAgent.remainingDistance < 0.5f)
                {
                    // Stop the navigation agent immediately
                    navMeshAgent.isStopped = true;

                    // Set a new random destination within the patrol area
                    SetRandomDestinationInPatrolArea();
                }
            }
        }

        // Check if the player is within the chase distance
        if (Vector3.Distance(transform.position, player.position) < chaseDistance)
        {
            SetState(EnemyState.Chase);
            navMeshAgent.speed = chaseSpeed;
            animator.SetBool("IsChasing", true);
        }
    }

    void Chase()
    {
        // Example: Move towards the player
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(player.position);

        // Set IsChasing parameter in the Animator
        animator.SetBool("IsChasing", true);

        // Check if the player is within the attack distance
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            SetState(EnemyState.Attack);
        }

        // Check if the player is outside the chase distance, go back to patrolling
        if (Vector3.Distance(transform.position, player.position) > chaseDistance)
        {
            SetState(EnemyState.Patrol);
        }
    }

    void Attack()
    {
        // Check if the cooldown has elapsed
        if (timeUntilNextAttack > 0f)
        {
            // Cooldown still active, wait for next frame
            timeUntilNextAttack -= Time.deltaTime;
            return;
        }

        // Replaced with animation events
        // PerformAttack(); 
        // timeUntilNextAttack = attackCooldown;

        // Check if the player is outside the attack distance, go back to chasing
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            animator.SetBool("IsAttacking", false);
            SetState(EnemyState.Chase);
        }
    }

    void PerformAttack()
    {
        // Check if the player is within the attack distance
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            player.GetComponent<ScruffyStats>().TakeDamage(10);
        }
    }


    void SetRandomDestinationInPatrolArea()
    {
        // Set the destination to a random point within the patrol area
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * patrolAreaRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolAreaRadius, 1);
        navMeshAgent.SetDestination(hit.position);
    }
}
