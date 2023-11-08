using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
        public Stat damage;
        public Stat armor;
        public Stat evasion;
        public Stat attackspeed;
        public Stat movementspeed;
        public Stat luck;
        public Stat healthregen;
        public Stat manaregen;
        
        public int MaxHealth;
        public int CurrentHealth {get; private set; }

        public int MaxMana;
        public int CurrentMana {get; private set; }

        public GameObject DeadEnemy;

        [SerializeField] FloatingHealthBar healthbar;

        void Awake ()
        {
            CurrentHealth = MaxHealth;
            healthbar = GetComponentInChildren<FloatingHealthBar>();
        }

        void Update (){
        }


        public void TakeDamage (int damage)
        {
            damage -= armor.getValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            CurrentHealth -= damage;
            healthbar.UpdateHealthBar(CurrentHealth, MaxHealth);
            Debug.Log(transform.name + " takes " + damage + "damage.");

            if (CurrentHealth <= 0){
                Die();
            }
        }

        public virtual void Die ()
        {
            Destroy(DeadEnemy);
            Debug.Log(transform.name + " died.");
        }
}
