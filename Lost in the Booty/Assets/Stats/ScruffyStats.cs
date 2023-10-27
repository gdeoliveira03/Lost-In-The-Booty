using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScruffyStats : MonoBehaviour
{
        public Stat damage;
        public Stat armor;
        public Stat evasion;
        public Stat attackspeed;

        public int MaxHealth;
        public int CurrentHealth {get; private set; }
        public Slider healthBar;

        public int MaxMana;
        public int CurrentMana {get; private set; }
        public Slider manaBar;
     
        void Start ()
        {
            CurrentHealth = MaxHealth;
            CurrentMana = MaxMana;
            healthBar.maxValue = MaxHealth;
            manaBar.maxValue = MaxMana;
        }

        void Update (){

            healthBar.value = CurrentHealth;
            manaBar.value = CurrentMana;

            if (Input.GetKeyDown(KeyCode.T)){
                TakeDamage(10);
            }
            if (Input.GetKeyDown(KeyCode.Y)){
                UseMana(5);
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

        public void UseMana (int manacost)
        {
            if(CurrentMana < manacost){
                Debug.Log("Not Enough Mana");
            }
            else{
                CurrentMana -= manacost;
                Debug.Log(transform.name + " used up " + manacost + " mana.");
            }
        }

        public virtual void Die ()
        {
            Debug.Log(transform.name + " died.");
        }
}
