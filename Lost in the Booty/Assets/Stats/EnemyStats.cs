using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
        private int damage = 0;
        private int armor = 0;
        private int evasion = 0;
        private int attackspeed = 0;
        private int movementspeed = 0;
        private int luck = 0;
        private int healthregen = 0;
        private int manaregen = 0;
        
        public int MaxHealth;
        public int CurrentHealth {get; private set; }

        public int MaxMana;
        public int CurrentMana {get; private set; }

        public GameObject DeadEnemy;
        public GameObject DamageText;
        public string EnemyType;

        [SerializeField] FloatingHealthBar healthbar;

        private NavMeshAgent navMeshAgent;
        private bool isStunned = false;
        public string playerTag = "Player";

        void Start()
        {
            // Set Enemy Stats Here
            if (EnemyType == "Skeleton"){
                damage = 5;
                MaxHealth = 30;
                CurrentHealth = MaxHealth;
                MaxMana = 0;
                armor = 0;
                evasion = 0;
                attackspeed = 0;
                healthregen = 0;
                manaregen = 0;

                if (navMeshAgent == null)
                {
                    navMeshAgent = GetComponent<NavMeshAgent>();
                }
            }

            CurrentHealth = MaxHealth;
            healthbar = GetComponentInChildren<FloatingHealthBar>();

        }


        void Update()
        {
            if (!isStunned)
            {
                // Find the player GameObject by tag
                GameObject player = GameObject.FindGameObjectWithTag(playerTag);

                if (player != null)
                {
                    // If the player is within a certain range, start chasing them
                    if (Vector3.Distance(transform.position, player.transform.position) < 10f)
                    {
                        ChasePlayer(player.transform.position);
                    }
                    else
                    {
                        // If the player is not in range, stop chasing
                        StopChasing();
                    }
                }
            }
        }

        void ChasePlayer(Vector3 targetPosition)
        {
             if (navMeshAgent != null)
            {
                // Set the destination to the player's position
                navMeshAgent.SetDestination(targetPosition);
            }
            else
            {
                Debug.LogError("NavMeshAgent is null. Ensure the GameObject has a NavMeshAgent component.");
            }
        }

        void StopChasing()
        {
            // Stop the NavMeshAgent from moving
            navMeshAgent.isStopped = true;
        }

        public void Stun()
        {
            // Set the flag to indicate that the enemy is stunned
            isStunned = true;
            // Stop chasing when stunned
            StopChasing();
        }

        IEnumerator RecoverFromStun()
        {
            yield return new WaitForSeconds(3f);

            // Reset the flag and allow the enemy to move again
            isStunned = false;
        }

        public void TakeDamage (int damage)
        {
            damage -= armor;
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            CurrentHealth -= damage;
            healthbar.UpdateHealthBar(CurrentHealth, MaxHealth);
            DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
            indicator.SetDamageText(damage);

            if (CurrentHealth <= 0){
                Die();
            }
        }

        public virtual void Die ()
        {
            //Destroy(DeadEnemy);
        }
}
