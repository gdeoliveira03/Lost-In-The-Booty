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
        Debug.Log("In Patrol State");

        // Example: Stop any ongoing chase or attack behaviors
        StopChase();
        StopAttack();

        // Set walking speed to patrol
        navMeshAgent.speed = walkSpeed;

        // Example: Set up patrol-specific variables
        SetRandomDestinationInPatrolArea();

        isPaused = false;
        animator.SetBool("IsPaused", isPaused);
        animator.SetBool("IsPatrolling", true);
        animator.SetBool("IsChasing", false);
    }

    void InitializeChaseState()
    {
        Debug.Log("In Chase State");

        // Example: Stop any ongoing patrol or attack behaviors
        StopPatrol();
        StopAttack();

        navMeshAgent.speed = runSpeed;

        animator.SetBool("IsChasing", true);
        animator.SetBool("IsPatrolling", false);
    }

    void InitializeAttackState()
    {
        Debug.Log("In Attack State");

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
            Debug.Log("PAUSED");

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
            Debug.Log("PATROLLING");

            // Check if the patrol timer has elapsed
            if (patrolTimer <= 0f)
            {
                // Pause patrolling
                isPaused = true;

                // Reset the patrol pause timer
                patrolPauseTimer = patrolPauseDuration;
            }
            else
            {
                // Continue counting down the patrol timer
                patrolTimer -= Time.deltaTime;

                // Move towards the current patrol destination
                navMeshAgent.isStopped = false;
                if (!navMeshAgent.hasPath || navMeshAgent.remainingDistance < 0.5f)
                {
                    SetRandomDestinationInPatrolArea();
                }
            }
        }

        // Check if the player is within the chase distance
        if (Vector3.Distance(transform.position, player.position) < chaseDistance)
        {
            SetState(EnemyState.Chase);
        }
    }

    void Chase()
    {
        Debug.Log("Chasing...");
        Debug.Log("NavMeshAgent.isActiveAndEnabled: " + navMeshAgent.isActiveAndEnabled);
        Debug.Log("NavMeshAgent.isOnNavMesh: " + navMeshAgent.isOnNavMesh);
        Debug.Log("NavMeshAgent.hasPath: " + navMeshAgent.hasPath);

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

        PerformAttack();
        timeUntilNextAttack = attackCooldown;

        // Check if the player is outside the attack distance, go back to chasing
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            animator.SetBool("IsAttacking", false);
            SetState(EnemyState.Chase);
        }
    }

    void PerformAttack()
    {
        // Perform your attack logic here
        Debug.Log("Performing attack!");

        // For demonstration purposes, let's assume the attack deals damage to the player
        player.GetComponent<ScruffyStats>().TakeDamage(10);
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
