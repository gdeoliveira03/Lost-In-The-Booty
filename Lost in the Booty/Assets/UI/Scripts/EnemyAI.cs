using System.Collections;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Stats
    private int damage = 0;
    private int armor = 0;
    private float movementSpeed;
    private float healthRegen = 0f;

    // Health and Mana
    public int MaxHealth;
    public int CurrentHealth { get; private set; }
    public int MaxMana;
    public int CurrentMana { get; private set; }

    // Prefabs and UI
    public GameObject DeadEnemy;
    public GameObject DamageText;
    public string EnemyType;

    [SerializeField]
    FloatingHealthBar healthBar;

    // Effects
    public bool isDoctor = false;
    public bool isFriendly = false;
    private bool isSkeleton = false;
    private bool isMinotaur = false;
    private bool isCrab = false;
    private bool isStunned = false;
    private bool isSlowed = false;
    private bool isBurning = false;
    private bool isFrozen = false;
    private bool healingeffect = false;
    private int activeDOTEffects = 0;

    // Effect Prefabs
    public GameObject OnFireEffect;
    public GameObject LightningElement;
    public GameObject LightningExplosion;
    public GameObject StunEffect;
    public GameObject SlowEffect;
    public GameObject FrostBiteEffect;
    public GameObject FreezeEffect;
    public GameObject DoctorHeal;

    // Effect Variables
    private float slowTime = 0f;
    private int slowStacks = 0;
    private int maxSlowStacks = 4;
    private float slowDuration = 0f;
    private float slowToAffectMovement = 0.2f; // Multiplier to slow movement per stack
    private int shockStacks = 0;
    private int shockThreshold = 3;
    private int shockDamage = 5; // Adjust the damage as needed
    private float chaseSpeed;
    private float patrolSpeed;
    private float attackDistance;
    private float timeInPatrol = 0f;

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
    public float chaseDistance = 10f;
    public float HealDistance = 10f;
    private float originalMovementSpeed;
    private float slowedamount = 1f;
    private float lastHealTime;
    public float healCooldown = 10f;
    private bool isHealing = false;

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private ScruffyStats scruffystats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Debug.Log("We are being hit");
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        scruffystats = player.GetComponent<ScruffyStats>();
        DeadEnemy = gameObject;

        navMeshAgent.enabled = true;

        // Set Enemy Stats Here
        if (EnemyType == "Skeleton")
        {
            UpdateEnemyStatsBasedOnSkullsSkeleton();
            MaxMana = 0;
            armor = 0;
            healthRegen = MaxHealth * 0.1f;
            isFriendly = false;
            attackDistance = 2f;
            patrolSpeed = 1f;
            chaseSpeed = 6f;
        }
        if (EnemyType == "Minotaur")
        {
            UpdateEnemyStatsBasedOnSkullsMinotaur();
            MaxMana = 0;
            armor = 0;
            healthRegen = MaxHealth * 0.1f;
            isFriendly = false;
            attackDistance = 2f;
            patrolSpeed = 2f;
            chaseSpeed = 6.5f;
        }
        if (EnemyType == "Crab")
        {
            UpdateEnemyStatsBasedOnSkullsCrab();
            MaxMana = 0;
            armor = 0;
            healthRegen = MaxHealth * 0.1f;
            isFriendly = false;
            attackDistance = 2f;
            patrolSpeed = 1f;
            chaseSpeed = 6.0f;
        }

        if (EnemyType == "Doctor")
        {
            isDoctor = true;
            isFriendly = true;
            attackDistance = 2f;
            patrolSpeed = 2f;
            chaseSpeed = 6.5f;
        }

        CurrentHealth = MaxHealth;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        navMeshAgent.speed = patrolSpeed;
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

            navMeshAgent.speed = slowedamount;

            if (slowTime >= slowDuration)
            {
                slowStacks = 0;
                slowTime = 0;
                navMeshAgent.speed = Mathf.Max(0f, chaseSpeed);
                SlowEffect.SetActive(false);
                animator.speed = 1f;
                isSlowed = false;
            }
        }

        if (isFrozen)
        {
            navMeshAgent.velocity = Vector3.zero; // Stop the movement
            navMeshAgent.isStopped = true; // Ensure that the agent is stopped
            animator.speed = 0f;
        }

        if (isStunned)
        {
            navMeshAgent.velocity = Vector3.zero; // Stop the movement
            navMeshAgent.isStopped = true; // Ensure that the agent is stopped
            animator.speed = 0f;
        }

        if (isDoctor)
        {
            StartCoroutine(HealOverTime());
        }
    }

    // ---------------------------- AI METHODS ----------------------------

    public void UpdateEnemyStatsBasedOnSkullsSkeleton()
    {
        if (EnemyType == "Skeleton")
        {
            MaxHealth = (GameManager.Instance.scruffyInventory.Skulls * 30) + 30;
            damage = (GameManager.Instance.scruffyInventory.Skulls * 5) + 8;
            CurrentHealth = MaxHealth;
        }
    }

    public void UpdateEnemyStatsBasedOnSkullsCrab()
    {
        if (EnemyType == "Crab")
        {
            MaxHealth = (GameManager.Instance.scruffyInventory.Skulls * 10) + 10;
            damage = (GameManager.Instance.scruffyInventory.Skulls * 5) + 6;
            CurrentHealth = MaxHealth;
        }
    }

    public void UpdateEnemyStatsBasedOnSkullsMinotaur()
    {
        if (EnemyType == "Minotaur")
        {
            MaxHealth = (GameManager.Instance.scruffyInventory.Skulls * 200) + 200;
            damage = (GameManager.Instance.scruffyInventory.Skulls * 5) + 15;
            CurrentHealth = MaxHealth;
        }
    }

    public void DoctorHealOff()
    {
        DoctorHeal.SetActive(false);
        healingeffect = false;
    }

    public bool CanHeal() //Cooldown for healing ability
    {
        return Time.time - lastHealTime >= healCooldown;
    }

    IEnumerator HealOverTime()
    {
        while (true)
        {
            // Check if it's time to heal
            if (CanHeal())
            {
                // Check if the conditions for healing are met
                if (
                    Vector3.Distance(transform.position, player.position) < HealDistance
                    && scruffystats.CurrentHealth < scruffystats.MaxHealth * 0.7f
                )
                {
                    healingeffect = true;
                    scruffystats.FlatHeal(scruffystats.MaxHealth * 2 / 7);

                    // Show healing effect
                    DoctorHeal.SetActive(true);

                    // Wait for 1 second (you can adjust the duration as needed)
                    yield return new WaitForSeconds(1f);

                    // Hide healing effect
                    DoctorHeal.SetActive(false);
                }

                lastHealTime = Time.time;
            }

            // Wait for the next iteration (10 seconds)
            yield return new WaitForSeconds(healCooldown);
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

        if (isFriendly)
        {
            animator.SetTrigger("ChaseYes"); // Set "ChaseYes" trigger only for the doctor
        }

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
        if (navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete)
            return;
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
        /*
        if (currentState == EnemyState.Patrol)
        {
            timeInPatrol += Time.deltaTime;

            if (timeInPatrol >= 5f)
            {
                timeInPatrol = 0f;
                StartHealing();
            }
        }*/
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
            if (isFriendly)
            {
                animator.SetTrigger("ChaseNo"); // Set "ChaseNo" trigger only for the doctor
            }
        }

        // Check if the player is outside the chase distance, go back to patrolling
        if (Vector3.Distance(transform.position, player.position) > chaseDistance)
        {
            SetState(EnemyState.Patrol);
            if (isFriendly)
            {
                animator.SetTrigger("ChaseYes"); // Set "ChaseYes" trigger only for the doctor
            }
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

    void StartHealing()
    {
        if (CurrentHealth < MaxHealth)
        {
            int healAmount = (int)Mathf.Min(healthRegen, (MaxHealth - CurrentHealth));
            FlatHeal(healAmount);
        }
    }

    public void FlatHeal(int amount)
    {
        CurrentHealth += amount;
        healthBar.UpdateHealthBar(CurrentHealth, MaxHealth);
        DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity)
            .GetComponent<DamagePopUp>();
        indicator.SetDamageTextColor(Color.green);
        indicator.SetDamageText(amount.ToString());
    }

    void PerformAttack()
    {
        // Check if the player is within the attack distance
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            player.GetComponent<ScruffyStats>().TakeDamage(damage); // Change 0 to damage
        }
    }

    void SetRandomDestinationInPatrolArea()
    {
        // Set the destination to a random point within the patrol area
        Vector3 randomDirection = Random.insideUnitSphere * patrolAreaRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolAreaRadius, 1);
        navMeshAgent.SetDestination(hit.position);
    }

    // ---------------------------- STAT METHODS ----------------------------

    public void Stun(float duration)
    {
        isStunned = true;
        originalMovementSpeed = movementSpeed;
        StunEffect.SetActive(true);
        Invoke("StunOff", duration);
    }

    public void StunOff()
    {
        isStunned = false;
        StunEffect.SetActive(false);
        movementSpeed = originalMovementSpeed;
        navMeshAgent.speed = Mathf.Max(0f, movementSpeed);
        animator.speed = 1f;
    }

    public void freezeOn()
    {
        FreezeEffect.SetActive(true);
        originalMovementSpeed = movementSpeed;
        isFrozen = true;
        Invoke("freezeOff", 5f);
    }

    public void freezeOff()
    {
        FreezeEffect.SetActive(false);
        navMeshAgent.isStopped = false;
        isFrozen = false;
        animator.speed = 1f;
        movementSpeed = originalMovementSpeed;
        navMeshAgent.speed = Mathf.Max(0f, movementSpeed);
    }

    public void ApplySlow(int stacksToAdd)
    {
        slowStacks = Mathf.Min(slowStacks + stacksToAdd, maxSlowStacks);
        slowDuration = Mathf.Min(slowDuration + (stacksToAdd * 4), 12f);
        isSlowed = true;

        if (stacksToAdd > 0 && slowStacks == stacksToAdd)
        {
            SlowEffect.SetActive(true);
        }

        float slowMultiplier = 1.0f - (slowStacks * 0.2f); // 20% reduction per stack
        slowedamount = slowMultiplier * navMeshAgent.speed;
        animator.speed = slowMultiplier * 1f;
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

    public IEnumerator TakeDamageOverTime(
        string DOTType,
        int damages,
        float duration,
        float tickSpeed
    )
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
        DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity)
            .GetComponent<DamagePopUp>();
        indicator.SetDamageTextColor(Color.black);
        indicator.SetDamageText(damage.ToString());

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if (EnemyType == "Skeleton")
        {
            GameManager.Instance.scruffyInventory.Coins += 1;
        }
        if (EnemyType == "Minotaur")
        {
            GameManager.Instance.scruffyInventory.Coins += 5;
            scruffystats.IncreaseSkulls(1);
            scruffystats.UpdateEnemyStatsBasedOnSkulls();
        }
        if (EnemyType == "Crab")
        {
            GameManager.Instance.scruffyInventory.Coins += 1;
        }
        Destroy(DeadEnemy);
    }
}
