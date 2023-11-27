using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    // Stats
    private int damage = 0;
    private int armor = 0;
    private int evasion = 0;
    private int attackSpeed = 0;
    private float movementSpeed;
    private int luck = 0;
    private int healthRegen = 0;
    private int manaRegen = 0;

    // Health and Mana
    public int MaxHealth;
    public int CurrentHealth { get; private set; }
    public int MaxMana;
    public int CurrentMana { get; private set; }

    // Prefabs and UI
    public GameObject DeadEnemy;
    public GameObject DamageText;
    public string EnemyType;
    [SerializeField] FloatingHealthBar healthBar;

    // Effects
    private bool isStunned = false;
    private bool isSlowed = false;
    private bool isBurning = false;
    private bool isFrozen = false;
    private int activeDOTEffects = 0;

    // Effect Prefabs
    public GameObject OnFireEffect;
    public GameObject LightningElement;
    public GameObject LightningExplosion;
    public GameObject StunEffect;
    public GameObject SlowEffect;
    public GameObject FrostBiteEffect;
    public GameObject FreezeEffect;

    // Effect Variables
    private float slowTime = 0f;
    private int slowStacks = 0;
    private int maxSlowStacks = 4;
    private float slowDuration = 0f;
    private float slowToAffectMovement = 0.2f; // Multiplier to slow movement per stack
    private int shockStacks = 0;
    private int shockThreshold = 3;
    private int shockDamage = 5; // Adjust the damage as needed

    // Tags
    public string playerTag = "Player";

    // AI
    private bool isPaused = false;
    private float patrolTimer = 0f;
    private float patrolPauseTimer = 0f;
    private float timeUntilNextAttack = 0f;
    public enum EnemyState
    {
        Patrol,
        Chase,
        Attack
    }
    public EnemyState currentState = EnemyState.Patrol;
    public float patrolAreaRadius = 10f;
    public float patrolInterval = 5f;
    public float patrolPauseDuration = 2f;
    public float chaseSpeed = 4f;
    public float patrolSpeed = 2f;
    public float chaseDistance = 10f;
    public float attackDistance = 2f;

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();

        navMeshAgent.enabled = true;

        // Set Enemy Stats Here
        if (EnemyType == "Skeleton")
        {
            damage = 5;
            MaxHealth = 30;
            CurrentHealth = MaxHealth;
            MaxMana = 0;
            armor = 0;
            evasion = 0;
            attackSpeed = 0;
            healthRegen = 0;
            manaRegen = 0;
        }

        CurrentHealth = MaxHealth;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
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

        if (isSlowed)
        {
            slowTime += Time.deltaTime;

            if (slowTime >= slowDuration)
            {
                slowStacks = 0;
                SlowEffect.SetActive(false);
                isSlowed = false;
                slowTime = 0;
            }
        }
    }

    // ---------------------------- AI METHODS ----------------------------

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

        StopChase();
        StopAttack();

        // Set patrolling speed
        movementSpeed = patrolSpeed;
        navMeshAgent.speed = movementSpeed;

        SetRandomDestinationInPatrolArea();

        isPaused = false;
        animator.SetBool("IsPaused", isPaused);
        animator.SetBool("IsPatrolling", true);
    }

    void InitializeChaseState()
    {
        Debug.Log("Chasing");

        StopPatrol();
        StopAttack();

        // Set chasing speed
        movementSpeed = chaseSpeed;
        navMeshAgent.speed = movementSpeed;

        animator.SetBool("IsChasing", true);
    }

    void InitializeAttackState()
    {
        Debug.Log("Attacking");

        StopPatrol();
        StopChase();

        animator.SetBool("IsAttacking", true);
    }

    void StopPatrol()
    {
        // Stop patrol-related behaviors
        animator.SetBool("IsPatrolling", false);
        animator.SetBool("IsPaused", false);
        navMeshAgent.isStopped = true;
    }

    void StopChase()
    {
        // Stop chase-related behaviors
        animator.SetBool("IsChasing", false);
        navMeshAgent.isStopped = true;
    }

    void StopAttack()
    {
        // Stop attack-related behaviors
        animator.SetBool("IsAttacking", false);
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
            movementSpeed = chaseSpeed;
            animator.SetBool("IsChasing", true);
        }
    }

    void Chase()
    {
        // Move towards the player
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
        // Check if the cooldown has elapsed
        if (timeUntilNextAttack > 0f)
        {
            // Cooldown still active, wait for next frame
            timeUntilNextAttack -= Time.deltaTime;
            return;
        }

        // PerformAttack() done in AnimationEvents

        // Check if the player is outside the attack distance, go back to chasing
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            SetState(EnemyState.Chase);
        }
    }

    void PerformAttack()
    {
        // Check if the player is within the attack distance
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            player.GetComponent<ScruffyStats>().TakeDamage(0); // Change 0 to damage
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





    // ---------------------------- STAT METHODS ----------------------------

    public void Stun(float duration)
    {
        isStunned = true;
        StunEffect.SetActive(true);
        RecoverFromStun(duration);
    }

    IEnumerator RecoverFromStun(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Reset the flag and allow the enemy to move again
        isStunned = false;
    }

    public void freezeOn()
    {
        FreezeEffect.SetActive(true);
        navMeshAgent.isStopped = true;
        isFrozen = true;
        animator.speed = 0f;
        Invoke("freezeOff", 5f);
    }

    public void freezeOff()
    {
        FreezeEffect.SetActive(false);
        navMeshAgent.isStopped = false;
        isFrozen = false;
        animator.speed = 1f;
    }

    public void ApplySlow(int stacksToAdd)
    {
        slowStacks = Mathf.Min(slowStacks + stacksToAdd, maxSlowStacks);
        slowDuration = Mathf.Min(slowDuration + (stacksToAdd * 5), 20f);
        isSlowed = true;

        if (stacksToAdd > 0 && slowStacks == stacksToAdd)
        {
            SlowEffect.SetActive(true);
        }

        movementSpeed = movementSpeed - (slowToAffectMovement * slowStacks * movementSpeed);
        navMeshAgent.speed = Mathf.RoundToInt(Mathf.Max(0f, movementSpeed));
    }

    public void InflictShock()
    {
        shockStacks++;
        LightningElement.SetActive(true);

        // Check if the shock threshold is reached
        if (shockStacks >= shockThreshold)
        {
            // Reset shock stacks
            shockStacks = 0;
            LightningElement.SetActive(false);
            LightningExplosion.SetActive(true);
            Invoke("StopLightningExplosion", 0.5f);

            // Apply shock damage
            TakeDamage(shockDamage);
        }
    }

    public void StopLightningExplosion()
    {
        LightningExplosion.SetActive(false);
    }

    public IEnumerator TakeDamageOverTime(string DOTType, int damages, float duration, float tickSpeed)
    {
        float elapsedTime = 0f;

        activeDOTEffects++;

        while (elapsedTime < duration)
        {
            if (DOTType == "fire" && !isBurning)
            {
                OnFireEffect.SetActive(true);
                isBurning = true;
            }
            if (DOTType == "ice")
            {
                FrostBiteEffect.SetActive(true);
            }

            yield return new WaitForSeconds(tickSpeed);

            // Apply damage
            TakeDamage(damages);

            // Update elapsed time
            elapsedTime += tickSpeed;
        }

        // Decrement active DOT effects
        activeDOTEffects--;

        if (DOTType == "fire" && activeDOTEffects == 0)
        {
            OnFireEffect.SetActive(false);
            isBurning = false;
        }
        if (DOTType == "ice")
        {
            FrostBiteEffect.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        healthBar.UpdateHealthBar(CurrentHealth, MaxHealth);
        DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
        indicator.SetDamageTextColor(Color.black);
        indicator.SetDamageText(damage.ToString());

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Destroy(DeadEnemy);
    }
}
