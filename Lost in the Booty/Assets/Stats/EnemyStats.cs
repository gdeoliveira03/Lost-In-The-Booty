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

            }

            CurrentHealth = MaxHealth;
            healthbar = GetComponentInChildren<FloatingHealthBar>();

        }


        void Update()
        {
            if (isStunned)
            {
                // Player cannot move
            }
        }

        //STUNNED ENEMY

        public void Stun()
        {
            isStunned = true;
        }

        IEnumerator RecoverFromStun()
        {
            yield return new WaitForSeconds(2f);

            // Reset the flag and allow the enemy to move again
            isStunned = false;
        }

        public GameObject OnFireEffect;
        // Keeps Track of Burning   
        private bool isburning = false;
        private int activeDOTEffects = 0;

        public IEnumerator TakeDamageOverTime(string DOTType, int damages, float duration, float tickSpeed)
        {
            float elapsedTime = 0f;

            activeDOTEffects++;

            while (elapsedTime < duration)
            {
                if(DOTType == "fire" && !isburning){
                    OnFireEffect.SetActive(true);
                    isburning = true;
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
                isburning = false;
            }
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
