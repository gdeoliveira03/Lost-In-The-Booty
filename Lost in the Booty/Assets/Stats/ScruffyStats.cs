using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScruffyStats : MonoBehaviour
{
        public int damage;
        public int armor;
        public int evasion;
        public int attackspeed;
        private int movementspeed = 0;
        private int luck = 0;

        public int MaxHealth;
        public int CurrentHealth {get; private set; }
        public Slider healthBar;

        public int MaxMana;
        public int CurrentMana {get; private set; }
        public Slider manaBar;

        public GameObject DamageText;
        public GameObject HealthText;

        private float healthrestoreTimer = 0f;
        private float manarestoreTimer = 0f;
        private float manaRestoreInterval = 5f; // Restore mana every x seconds
        private float healthRestoreInterval = 8f; // Restore health every y seconds
     
        void Start ()
        {
            CurrentHealth = MaxHealth;
            CurrentMana = MaxMana;
            healthBar.maxValue = MaxHealth;
            manaBar.maxValue = MaxMana;

            damage = 5;
        }

        void Update (){

            healthBar.value = CurrentHealth;
            manaBar.value = CurrentMana;

            // Natural Mana/Health regen
            healthrestoreTimer += Time.deltaTime;
            if (healthrestoreTimer >= healthRestoreInterval)
            {
                NaturalRestoreHealth(1);
                healthrestoreTimer = 0f;
            }

            manarestoreTimer += Time.deltaTime;
            if (manarestoreTimer >= manaRestoreInterval)
            {
                NaturalRestoreMana(1);
                manarestoreTimer = 0f;
            }
            

            if (Input.GetKeyDown(KeyCode.T)){
                TakeDamage(5);
            }
            if (Input.GetKeyDown(KeyCode.Y)){
                UseMana(5);
            }
        }

        void NaturalRestoreHealth(int amount)
        {
            if (CurrentHealth + amount <= MaxHealth)
            {
                CurrentHealth += amount;
                healthBar.value = CurrentHealth;
            }
        }

        void NaturalRestoreMana(int amount)
        {
            if (CurrentMana + amount <= MaxMana)
            {
                CurrentMana += amount;
                manaBar.value = CurrentMana;
            }
        }


        public void IncreaseArmor(int armorvalue){
            armor += armorvalue;
        }

        public void IncreaseArmorEnd(int armorvalue){
            armor -= armorvalue;
        }


        public void FlatHeal (int flatheal)
        {
            if (CurrentHealth + flatheal > MaxHealth){
                flatheal = MaxHealth - CurrentHealth; 
            }
            DamagePopUp indicator = Instantiate(HealthText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
            indicator.SetDamageText(flatheal);
            CurrentHealth += flatheal;   
        }



        public void HealOverTime (int DOTheal)
        {

        }


        private int initialdamage;
        private double takendamageboost;
        private bool isTakenboosted = false;

        public void DamageBoost (double BoostValue)
        {
            initialdamage = damage;
            damage = (int) (damage * BoostValue);
        }

        public void DamageBoostEnd (double BoostValue)
        {
            damage = initialdamage; 

        }

        public void TakenDamageBoost (double BoostValue)
        {
            takendamageboost = BoostValue;
            isTakenboosted = true;
        }

        public void TakenDamageBoostEnd (double BoostValue)
        {
            takendamageboost = 1;
            isTakenboosted = false;
        }




        public void TakeDamage (int damagetaken)
        {
            if (isTakenboosted == true){
                damagetaken = (int) (damagetaken * takendamageboost);
            }

            damagetaken -= armor;
            damagetaken = Mathf.Clamp(damagetaken, 0, int.MaxValue);

            CurrentHealth -= damagetaken;
            DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
            indicator.SetDamageText(damagetaken);
            Debug.Log(transform.name + " takes " + damagetaken + "damage.");

            if (CurrentHealth <= 0){
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
