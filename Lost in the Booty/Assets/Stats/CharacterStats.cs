using UnityEngine;

public class CharacterStats : MonoBehaviour
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

        void Awake ()
        {
            CurrentHealth = MaxHealth;
        }

        void Update (){
            if (Input.GetKeyDown(KeyCode.T)){
                TakeDamage(10);
            }
        }


        public void TakeDamage (int damage)
        {
            damage -= armor.getValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            CurrentHealth -= damage;
            Debug.Log(transform.name + " takes " + damage + "damage.");

            if (CurrentHealth < 0){
                Die();
            }
        }

        public virtual void Die ()
        {
            Debug.Log(transform.name + " died.");
        }
}
