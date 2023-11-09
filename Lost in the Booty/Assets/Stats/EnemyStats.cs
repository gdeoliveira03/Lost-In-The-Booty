using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI; // Add this for NavMeshAgent support

public class EnemyStats : MonoBehaviour
{
        private int damage = 5;
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

        private float detectionRadius = 10f; // Adjust as needed
        private float attackRange = 2f; // Adjust as needed
        private Transform player;

        void Start()
        {

            // Set Enemy Stats Here
            if (EnemyType == "Skeleton"){
                detectionRadius = 10f;
                attackRange = 2f;
                damage = 5;
                MaxHealth = 25;
                MaxMana = 0;
                armor = 0;
                evasion = 0;
                attackspeed = 0;
                healthregen = 0;
                manaregen = 0;
            }

        }

        void Awake ()
        {
            CurrentHealth = MaxHealth;
            healthbar = GetComponentInChildren<FloatingHealthBar>();
        }

        void Update (){
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
            Destroy(DeadEnemy);
        }
}
