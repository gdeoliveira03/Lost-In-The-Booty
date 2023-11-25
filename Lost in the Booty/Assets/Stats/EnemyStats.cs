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
    private int movementspeed;
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
    public GameObject OnFireEffect;
    public GameObject LightningElement;
    public GameObject LightningExplosion;
    public GameObject SlowEffect;
    public GameObject FrostBiteEffect;
    public GameObject FreezeEffect;
    int originalMovementSpeed; 
    private float slowtime = 0f;
    private bool isslowed = false;

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
            originalMovementSpeed = 100;
            movementspeed = 100;

        }

        CurrentHealth = MaxHealth;
        healthbar = GetComponentInChildren<FloatingHealthBar>();

    }


    void Update()
    {
        if(isslowed){
            slowtime += Time.deltaTime;

            if (slowtime >= slowDuration)
            {
                slowStacks = 0;
                SlowEffect.SetActive(false);
                isslowed = false;
                slowtime = 0f;
                movementspeed = originalMovementSpeed;
            }
        }
        if (isStunned)
        {
            // Player cannot move
        }

    }

    //STUNNED ENEMY

    public void Stun(float duration)
    {
        isStunned = true;

        RecoverFromStun(duration);
    }

    IEnumerator RecoverFromStun(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Reset the flag and allow the enemy to move again
        isStunned = false;
    }

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
            if(DOTType == "ice"){
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
            isburning = false;
        }
        if (DOTType == "ice")
        {
            FrostBiteEffect.SetActive(false);
        }
    }

    private int shockStacks = 0;
    private int shockThreshold = 3;
    private int shockDamage = 5; // Adjust the damage as needed

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

    public void StopLightningExplosion (){
        LightningExplosion.SetActive(false);
    }





    private int slowStacks = 0;
    private int maxSlowStacks = 4;
    private float slowDuration = 0f;
   

    public void ApplySlow(int stacksToAdd)
    {
        slowStacks = Mathf.Min(slowStacks + stacksToAdd, maxSlowStacks);
        slowDuration = Mathf.Min(slowDuration + (stacksToAdd*5), 20f);
        isslowed = true;

        if (stacksToAdd > 0 && slowStacks == stacksToAdd)
        {
            SlowEffect.SetActive(true);
        }

        float newMovementSpeed = originalMovementSpeed * (1f - 0.2f * slowStacks);
        movementspeed = Mathf.RoundToInt(newMovementSpeed);
    }


    public void freezeOn(){
        FreezeEffect.SetActive(true);
        movementspeed = 0;
        Invoke("freezeOff", 5f);

    }

    public void freezeOff(){
        FreezeEffect.SetActive(false);
        movementspeed = originalMovementSpeed;
    }

    public void TakeDamage (int damage)
    {
        damage -= armor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        healthbar.UpdateHealthBar(CurrentHealth, MaxHealth);
        DamagePopUp indicator = Instantiate(DamageText, transform.position, Quaternion.identity).GetComponent<DamagePopUp>();
        indicator.SetDamageTextColor(Color.black);
        indicator.SetDamageText(damage.ToString());

        if (CurrentHealth <= 0){
            Die();
        }
    }

    public virtual void Die ()
    {
        //Destroy(DeadEnemy);
    }
}
