using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        Patrol,
        Chase,
        Attack
    }

    public EnemyState currentState = EnemyState.Patrol;

    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

    public float chaseDistance = 10f;
    public float attackDistance = 2f;

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private EnemyStats enemyStats;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null )
        {
            Debug.Log("player == null");
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyStats = GetComponent<EnemyStats>();

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

        // Example: Set up patrol-specific variables
        SetDestinationToNextPatrolPoint();
    }

    void InitializeChaseState()
    {
        Debug.Log("In Chase State");

        // Example: Stop any ongoing patrol or attack behaviors
        StopPatrol();
        StopAttack();
    }

    void InitializeAttackState()
    {
        Debug.Log("In Attack State");

        // Example: Stop any ongoing patrol or chase behaviors
        StopPatrol();
        StopChase();

        // Example: Set up attack-specific variables
    }

    void StopPatrol()
    {
        // Example: Stop patrol-related behaviors
        navMeshAgent.isStopped = true;
    }

    void StopChase()
    {
        // Example: Stop chase-related behaviors
        navMeshAgent.isStopped = true;
    }

    void StopAttack()
    {
        // Example: Stop attack-related behaviors
        navMeshAgent.isStopped = true;
    }

    void Patrol()
    {
        // Example: Move towards the current patrol point
        navMeshAgent.isStopped = false;

        if (patrolPoints != null && patrolPoints.Length > 0)
        {
            navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);

            // Check if the enemy has reached the current patrol point
            if (Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 1f)
            {
                // Move to the next patrol point
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            }
        }
        else
        {
            Debug.Log("patrolPoints array is null or empty.");
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
        // Example: Perform attack actions
        // This can include dealing damage to the player or triggering attack animations

        // Check if the player is outside the attack distance, go back to chasing
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            SetState(EnemyState.Chase);
        }
    }

    void SetDestinationToNextPatrolPoint()
    {
        // Example: Set the destination to the next patrol point
        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }
}
