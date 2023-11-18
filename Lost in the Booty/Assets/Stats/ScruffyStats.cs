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

        private bool isTempHealth = false;
        private int TemporaryHealth;
        SkillList skills;
     
        void Start ()
        {

            skills = GetComponent<SkillList>();

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

        public void TempMaxHPIncrease(int value){
            isTempHealth = true;
            TemporaryHealth = value;
        }

        public void TempMaxHPDecrease(int value){
            isTempHealth = false;
            TemporaryHealth = 0;
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



        public void HealOverTimeX(int healAmount, float duration, float tickSpeed)
        {
            StartCoroutine(HealOverTimeCoroutine(healAmount, duration, tickSpeed));
        }

        private IEnumerator HealOverTimeCoroutine(int healAmount, float duration, float tickSpeed)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                yield return new WaitForSeconds(tickSpeed);

                // Apply healing
                FlatHeal(healAmount);

                // Update elapsed time
                elapsedTime += tickSpeed;
            }
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

        private bool isburning = false;
        private int activeDOTEffects = 0;

        public IEnumerator TakeDamageOverTimeX(string DOTType, int damages, float duration, float tickSpeed)
        {
            Debug.Log("hi>");
            float elapsedTime = 0f;

            activeDOTEffects++;

            while (elapsedTime < duration)
            {
                yield return new WaitForSeconds(tickSpeed);

                // Apply damage
                TakeDamage(damages);

                // Update elapsed time
                elapsedTime += tickSpeed;
            }

            // Decrement active DOT effects
            activeDOTEffects--;

        }


        public void TakeDamage (int damagetaken)
        {
            if (isTakenboosted == true){
                damagetaken = (int) (damagetaken * takendamageboost);
            }

            damagetaken -= armor;
            damagetaken = Mathf.Clamp(damagetaken, 0, int.MaxValue);

            if(isTempHealth == true){
                if(damagetaken <= TemporaryHealth){
                    TemporaryHealth -= damagetaken;
                    DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                    indicator.SetDamageText(damagetaken);
                    indicator.SetDamageTextColor(Color.white);
                    Debug.Log(transform.name + " takes " + damagetaken + "damage.");
                }
                else if(damagetaken > TemporaryHealth){
                    damagetaken -= TemporaryHealth;
                    CurrentHealth -= damagetaken;
                    isTempHealth = false;
                    skills.IceP2.SetActive(false);
                    DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                    indicator.SetDamageText(damagetaken);
                    indicator.SetDamageTextColor(Color.white);
                    Debug.Log(transform.name + " takes " + damagetaken + "damage.");
                }
            }
            else{
                CurrentHealth -= damagetaken;
                DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                indicator.SetDamageText(damagetaken);
                indicator.SetDamageTextColor(Color.red);
                Debug.Log(transform.name + " takes " + damagetaken + "damage.");
            }

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
                DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                indicator.SetDamageText(manacost);
                indicator.SetDamageTextColor(Color.blue);
                Debug.Log(transform.name + " takes " + manacost + "damage.");

            }
        }

        public virtual void Die ()
        {
            Debug.Log(transform.name + " died.");
        }
}
