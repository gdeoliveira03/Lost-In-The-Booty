using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScruffyStats : MonoBehaviour
{
        public int damage = 5;
        public int armor;
        public int evasion;
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
        private float manaRestoreInterval = 4f; // Restore mana every x seconds
        private float healthRestoreInterval = 8f; // Restore health every y seconds

        private bool isTempHealth = false;
        private int TemporaryHealth;
        SkillList skills;

        private PlayerStateMachine MovementScript;
        private float normalwalkSpeed;
        private float normalrunSpeed;

        public TextMeshProUGUI[] StatTexts;
        Animator animator;

        public TextMeshProUGUI CoinsUI;
        public TextMeshProUGUI SkullsUI;
     
        void Start ()
        {
            InitializeStats();
        }

        void InitializeStats()
        {
            isdead = true;
            // Your initialization logic from the Start method
            MovementScript = GetComponent<PlayerStateMachine>();
            skills = GetComponent<SkillList>();
            animator = GetComponent<Animator>();

            CurrentHealth = MaxHealth;
            CurrentMana = MaxMana;
            healthBar.maxValue = MaxHealth;
            manaBar.maxValue = MaxMana;

            normalwalkSpeed = MovementScript.walkSpeed;
            normalrunSpeed = MovementScript.runSpeed;

            damage = 5;
            armor = 5;
            evasion = 5;

            StatTexts[0].text = "Health: " + MaxHealth;
            StatTexts[1].text = "Mana: " + MaxMana;
            StatTexts[2].text = "Damage: " + damage;
            StatTexts[3].text = "Armor: " + armor;
            StatTexts[4].text = "Evasion: " + evasion + "%";
        }


        void Update (){

            CoinsUI.text = "" + GameManager.Instance.scruffyInventory.Coins;
            SkullsUI.text = "" + GameManager.Instance.scruffyInventory.Skulls;

            healthBar.value = CurrentHealth;
            manaBar.value = CurrentMana;




            StatTexts[0].text = "Health: " + MaxHealth;
            StatTexts[1].text = "Mana: " + MaxMana;
            StatTexts[2].text = "Damage: " + damage;
            StatTexts[3].text = "Armor: " + armor;
            StatTexts[4].text = "Evasion: " + evasion + "%";

            // Natural Mana/Health regen
            healthrestoreTimer += Time.deltaTime;
            if (healthrestoreTimer >= healthRestoreInterval)
            {
                NaturalRestoreHealth((int) MaxHealth * 1/25 );
                healthrestoreTimer = 0f;
            }

            manarestoreTimer += Time.deltaTime;
            if (manarestoreTimer >= manaRestoreInterval)
            {
                NaturalRestoreMana((int) MaxMana * 1/5);
                manarestoreTimer = 0f;
            }
           

            if (CurrentHealth <= 0){
                Die();
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
            else if ((MaxMana-CurrentMana) < amount){
                CurrentMana = MaxMana;
                manaBar.value = CurrentMana;
            }
        }

        public void RestoreMana(int amount){
            if (CurrentMana + amount <= MaxMana)
            {
                CurrentMana += amount;
                manaBar.value = CurrentMana;
                DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                indicator.SetDamageText(amount.ToString());
                indicator.SetDamageTextColor(Color.blue);
            }
            else
            {
                DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                indicator.SetDamageText((MaxMana-CurrentMana).ToString());
                indicator.SetDamageTextColor(Color.blue);
                CurrentMana = MaxMana;
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
            indicator.SetDamageText(flatheal.ToString());
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

        public void AddEvasion(int evasionvalue){
            evasion += evasionvalue;
        }

        public void RemoveEvasion(int evasionvalue){
            evasion -= evasionvalue;
        }

        

        public void IncreaseMovementSpeed(float walkS, float runS){
            MovementScript.walkSpeed = walkS;
            MovementScript.runSpeed = runS;
        }

        public void ResetMovementSpeed(){
            MovementScript.walkSpeed = normalwalkSpeed;
            MovementScript.runSpeed = normalrunSpeed;
        }


        private bool isburning = false;
        private int activeDOTEffects = 0;

        public IEnumerator TakeDamageOverTimeX(string DOTType, int damages, float duration, float tickSpeed)
        {
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

        bool takenodamage = false;
        public void GainImmunity (){
            takenodamage = true;
        }

        public void RemoveImmunity (){
            takenodamage = false;
        }


        public void TakeDamage (int damagetaken)
        {
            if (isTakenboosted == true){
                damagetaken = (int) (damagetaken * takendamageboost);
            }

            if (Random.Range(0, 100) < evasion)
            {
                // Attack missed due to evasion
                DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                indicator.SetDamageText("Miss");
                indicator.SetDamageTextColor(Color.gray);
                Debug.Log(transform.name + " evaded the attack!");
            }
            else
            {
                if(takenodamage == true){
                    DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                    indicator.SetDamageText("Immune");
                    indicator.SetDamageTextColor(Color.white);
                }
                else{
                    damagetaken -= armor;
                    damagetaken = Mathf.Clamp(damagetaken, 0, int.MaxValue);

                    if(isTempHealth == true){
                        if(damagetaken <= TemporaryHealth){
                            TemporaryHealth -= damagetaken;
                            DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                            indicator.SetDamageText(damagetaken.ToString());
                            indicator.SetDamageTextColor(Color.white);
                        }
                        else if(damagetaken > TemporaryHealth){
                            damagetaken -= TemporaryHealth;
                            CurrentHealth -= damagetaken;
                            isTempHealth = false;
                            skills.IceP2.SetActive(false);
                            DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                            indicator.SetDamageText(damagetaken.ToString());
                            indicator.SetDamageTextColor(Color.white);
                        }
                    }
                    else{
                        CurrentHealth -= damagetaken;
                        DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                        indicator.SetDamageText(damagetaken.ToString());
                        indicator.SetDamageTextColor(Color.red);
                    }
                }
            }
        }


        public void UseMana (int manacost)
        {
            if(CurrentMana < manacost){
                DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
                indicator.SetDamageText("Need Mana");
                indicator.SetDamageTextColor(Color.cyan);
            }
            else{
                CurrentMana -= manacost;
            }
        }

        public void NeedMana(){
            DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
            indicator.SetDamageText("Need Mana");
            indicator.SetDamageTextColor(Color.cyan);
        }

        
        
        public GameObject deathScreenPrefab;
        public GameObject spawnPoint;
        Vector3 spawnPointPosition;
        public float fadeDuration = 2f;
        bool isdead = true;
        public virtual void Die ()
        {
            spawnPointPosition = spawnPoint.transform.position;
            if(isdead){
                animator.SetTrigger("Died");
                StartCoroutine(DeathSequence());
            }
            isdead = false;
        }

        private IEnumerator DeathSequence()
        {
            yield return new WaitForSeconds(2f);

            GameObject deathScreen = Instantiate(deathScreenPrefab, transform.position, Quaternion.identity);

            gameObject.transform.position = spawnPointPosition;
            InitializeStats();

            yield return new WaitForSeconds(0.5f);

            Time.timeScale = 0f;

        }

    void OnTriggerEnter(Collider other)
    {
        
           if(other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Die();
        } 

    }

}
