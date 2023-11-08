using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponElement : MonoBehaviour
{
    // WEAPON/ELEMENT BOOL FOR WHICH THEY CURRENTLY HAVE
    public bool Cutlass;
    public bool Spear;
    public bool Hammer;
    public bool Fire;
    public bool Ice;
    public bool Lightning;

    // GAME UI IMAGES FOR WEAPON/ELEMENT
    public GameObject GameUICutlass;
    public GameObject GameUISpear;
    public GameObject GameUIHammer;
    public GameObject GameUIFire;
    public GameObject GameUIIce;
    public GameObject GameUILightning;

    // SPELL BOOK TOP IMAGES FOR WEAPON/ELEMENT
    public GameObject SpellBookImageCutlass;
    public GameObject SpellBookImageSpear;
    public GameObject SpellBookImageHammer;
    public GameObject SpellBookImageFire;
    public GameObject SpellBookImageIce;
    public GameObject SpellBookImageLightning;

    // SPELL BOOK SKILL IMAGES FOR WEAPON/ELEMENT
    public GameObject SpellBookSkillsCutlass;
    public GameObject SpellBookSkillsSpear;
    public GameObject SpellBookSkillsHammer;
    public GameObject SpellBookSkillsFire;
    public GameObject SpellBookSkillsIce;
    public GameObject SpellBookSkillsLightning;

    // CURRENT HELD WEAPON
    public GameObject NormalCutlass;
    public GameObject NormalSpear;
    public GameObject NormalHammer;
    public GameObject FireCutlass;
    public GameObject FireSpear;
    public GameObject FireHammer;
    public GameObject IceCutlass;
    public GameObject IceSpear;
    public GameObject IceHammer;
    public GameObject LightningCutlass;
    public GameObject LightningSpear;
    public GameObject LightningHammer;

    // Stores the weapon colliders
    private Collider NCWeaponCollider;
    private Collider NSWeaponCollider;
    private Collider NHWeaponCollider;  
    private Collider FCWeaponCollider;
    private Collider FSWeaponCollider;
    private Collider FHWeaponCollider;
    private Collider ICWeaponCollider;
    private Collider ISWeaponCollider;
    private Collider IHWeaponCollider;
    private Collider LCWeaponCollider;
    private Collider LSWeaponCollider;
    private Collider LHWeaponCollider;

    // FOR BASIC ATTACK ANIMATIONS
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        // Get the colliders
        NCWeaponCollider = NormalCutlass.GetComponent<Collider>();
        NSWeaponCollider = NormalSpear.GetComponent<Collider>();
        NHWeaponCollider = NormalHammer.GetComponent<Collider>();
        FCWeaponCollider = FireCutlass.GetComponent<Collider>();
        FSWeaponCollider = FireSpear.GetComponent<Collider>();
        FHWeaponCollider = FireHammer.GetComponent<Collider>();
        ICWeaponCollider = IceCutlass.GetComponent<Collider>();
        ISWeaponCollider = IceSpear.GetComponent<Collider>();
        IHWeaponCollider = IceHammer.GetComponent<Collider>();
        LCWeaponCollider = LightningCutlass.GetComponent<Collider>();
        LSWeaponCollider = LightningSpear.GetComponent<Collider>();
        LHWeaponCollider = LightningHammer.GetComponent<Collider>();

        // Sets the colliders to off
        NCWeaponCollider.enabled = false;
        NSWeaponCollider.enabled = false;
        NHWeaponCollider.enabled = false;
        FCWeaponCollider.enabled = false;
        FSWeaponCollider.enabled = false;
        FHWeaponCollider.enabled = false;
        ICWeaponCollider.enabled = false;
        ISWeaponCollider.enabled = false;
        IHWeaponCollider.enabled = false;
        LCWeaponCollider.enabled = false;
        LSWeaponCollider.enabled = false;
        LHWeaponCollider.enabled = false;

        if (Cutlass == true){
            GameUICutlass.SetActive(true);
            SpellBookImageCutlass.SetActive(true);
            SpellBookSkillsCutlass.SetActive(true);

            // CUTLASS BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                CutlassBasicAttack();
            }

        }
        else {
            GameUICutlass.SetActive(false);
            SpellBookImageCutlass.SetActive(false);
            SpellBookSkillsCutlass.SetActive(false);
        }

        if (Spear == true){
            GameUISpear.SetActive(true);
            SpellBookImageSpear.SetActive(true);
            SpellBookSkillsSpear.SetActive(true);

            // SPEAR BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                SpearBasicAttack();
            }

        }
        else {
            GameUISpear.SetActive(false);
            SpellBookImageSpear.SetActive(false);
            SpellBookSkillsSpear.SetActive(false);
        }

        if (Hammer == true){
            GameUIHammer.SetActive(true);
            SpellBookImageHammer.SetActive(true);
            SpellBookSkillsHammer.SetActive(true);

            // HAMMER BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                HammerBasicAttack();
            }
        }
        else {
            GameUIHammer.SetActive(false);
            SpellBookImageHammer.SetActive(false);
            SpellBookSkillsHammer.SetActive(false);
        }

        if (Fire == true){
            GameUIFire.SetActive(true);
            SpellBookImageFire.SetActive(true);
            SpellBookSkillsFire.SetActive(true);

            // FIRE BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse1)){
                FireBasicAttack();
            }
        }
        else {
            GameUIFire.SetActive(false);
            SpellBookImageFire.SetActive(false);
            SpellBookSkillsFire.SetActive(false);
        }

        if (Ice == true){
            GameUIIce.SetActive(true);
            SpellBookImageIce.SetActive(true);
            SpellBookSkillsIce.SetActive(true);

            // ICE BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse1)){
                IceBasicAttack();
            }
        }
        else {
            GameUIIce.SetActive(false);
            SpellBookImageIce.SetActive(false);
            SpellBookSkillsIce.SetActive(false);
        }

        if (Lightning == true){
            GameUILightning.SetActive(true);
            SpellBookImageLightning.SetActive(true);
            SpellBookSkillsLightning.SetActive(true);

            // LIGHTNING BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse1)){
                LightningBasicAttack();
            }
        }
        else {
            GameUILightning.SetActive(false);
            SpellBookImageLightning.SetActive(false);
            SpellBookSkillsLightning.SetActive(false);
        }


        // FOR WEAPON HOLDING

        if (Cutlass == true && Fire == true){
            FireCutlass.SetActive(true);
        }
        else{
            FireCutlass.SetActive(false);
        }

        if (Cutlass == true && Ice == true){
            IceCutlass.SetActive(true);
        }
        else{
            IceCutlass.SetActive(false);           
        }

        if (Cutlass == true && Lightning == true){
            LightningCutlass.SetActive(true);           
        }
        else{
            LightningCutlass.SetActive(false);             
        }

        if (Spear == true && Fire == true){
            FireSpear.SetActive(true);
        }
        else{
            FireSpear.SetActive(false);
        }

        if (Spear == true && Ice == true){
            IceSpear.SetActive(true);
        }
        else{
            IceSpear.SetActive(false);
        }

        if (Spear == true && Lightning == true){
            LightningSpear.SetActive(true);
        }
        else{
            LightningSpear.SetActive(false);
        }

        if (Hammer == true && Fire == true){
            FireHammer.SetActive(true);
        }
        else{
            FireHammer.SetActive(false);
        }

        if (Hammer == true && Ice == true){
            IceHammer.SetActive(true);
        }
        else{
            IceHammer.SetActive(false);
        }

        if (Hammer == true && Lightning == true){
            LightningHammer.SetActive(true);
        }
        else{
            LightningHammer.SetActive(false);
        }

        // Implementation for normal weapons only
        // Normal Cutlass
        if (Cutlass == true && Spear == false && Hammer == false && Fire == false && Ice == false && Lightning == false){
            NormalCutlass.SetActive(true);
        }
        else{
            NormalCutlass.SetActive(false);        
        }

        // Normal Spear
        if (Spear == true && Cutlass == false && Hammer == false && Fire == false && Ice == false && Lightning == false){
            NormalSpear.SetActive(true);
        }
        else{
            NormalSpear.SetActive(false);
        }


        // Normal Hammer
        if (Hammer == true && Spear == false && Cutlass == false && Fire == false && Ice == false && Lightning == false){
            NormalHammer.SetActive(true);
        }
        else{
            NormalHammer.SetActive(false);
        }

    }

    // Cooldown times for basic abilities
    private float CutlassBasicCooldown = 1f;
    private float SpearBasicCooldown = 1f;
    private float HammerBasicCooldown = 2f;
    private float FireBasicCooldown = 1f;
    private float IceBasicCooldown = 1f;
    private float LightningBasicCooldown = 1f;

    // Cooldown true/false for basic abilities
    private bool isAbilityCooldownCutlass = false;
    private bool isAbilityCooldownSpear = false;
    private bool isAbilityCooldownHammer = false;
    private bool isAbilityCooldownFire = false;
    private bool isAbilityCooldownIce = false;
    private bool isAbilityCooldownLightning = false;

    // Current Cooldown for basic abilities
    private float CurrentCutlassBasicCooldown;
    private float CurrentSpearBasicCooldown;
    private float CurrentHammerBasicCooldown;
    private float CurrentFireBasicCooldown;
    private float CurrentIceBasicCooldown;
    private float CurrentLightningBasicCooldown;

    private bool isAttacking = false;
    private string enemyTag = "Enemy";
    public int damage = 10;
    private Dictionary<Collider, HashSet<Collider>> hitEnemies = new Dictionary<Collider, HashSet<Collider>>();

    // Update Function starts here
    void Update()
    {

        animator = GetComponent<Animator>();

        // Cooldown timers for basic attacks
        BasicAttackCooldown(ref CurrentCutlassBasicCooldown, CutlassBasicCooldown, ref isAbilityCooldownCutlass); // Counts Cooldown time for cutlass
        BasicAttackCooldown(ref CurrentSpearBasicCooldown, SpearBasicCooldown, ref isAbilityCooldownSpear); // Counts Cooldown time for spear
        BasicAttackCooldown(ref CurrentHammerBasicCooldown, HammerBasicCooldown, ref isAbilityCooldownHammer); // Counts Cooldown time for hammer
        BasicAttackCooldown(ref CurrentFireBasicCooldown, FireBasicCooldown, ref isAbilityCooldownFire); // Counts Cooldown time for fire
        BasicAttackCooldown(ref CurrentIceBasicCooldown, IceBasicCooldown, ref isAbilityCooldownIce); // Counts Cooldown time for ice
        BasicAttackCooldown(ref CurrentLightningBasicCooldown, LightningBasicCooldown, ref isAbilityCooldownLightning); // Counts Cooldown time for lightning
        
        if (Cutlass == true){
            GameUICutlass.SetActive(true);
            SpellBookImageCutlass.SetActive(true);
            SpellBookSkillsCutlass.SetActive(true);

            // CUTLASS BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                animator.SetTrigger("CutlassBasicAttack"); // Triggers the ability animation
            }

        }
        else {
            GameUICutlass.SetActive(false);
            SpellBookImageCutlass.SetActive(false);
            SpellBookSkillsCutlass.SetActive(false);
        }

        if (Spear == true){
            GameUISpear.SetActive(true);
            SpellBookImageSpear.SetActive(true);
            SpellBookSkillsSpear.SetActive(true);

            // SPEAR BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                animator.SetTrigger("SpearBasicAttack"); // Triggers the ability animation
            }

        }
        else {
            GameUISpear.SetActive(false);
            SpellBookImageSpear.SetActive(false);
            SpellBookSkillsSpear.SetActive(false);
        }

        if (Hammer == true){
            GameUIHammer.SetActive(true);
            SpellBookImageHammer.SetActive(true);
            SpellBookSkillsHammer.SetActive(true);

            // HAMMER BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                animator.SetTrigger("HammerBasicAttack"); // Triggers the ability animation
            }
        }
        else {
            GameUIHammer.SetActive(false);
            SpellBookImageHammer.SetActive(false);
            SpellBookSkillsHammer.SetActive(false);
        }

        if (Fire == true){
            GameUIFire.SetActive(true);
            SpellBookImageFire.SetActive(true);
            SpellBookSkillsFire.SetActive(true);

            // FIRE BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse1)){
                FireBasicAttack();
            }
        }
        else {
            GameUIFire.SetActive(false);
            SpellBookImageFire.SetActive(false);
            SpellBookSkillsFire.SetActive(false);
        }

        if (Ice == true){
            GameUIIce.SetActive(true);
            SpellBookImageIce.SetActive(true);
            SpellBookSkillsIce.SetActive(true);

            // ICE BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse1)){
                IceBasicAttack();
            }
        }
        else {
            GameUIIce.SetActive(false);
            SpellBookImageIce.SetActive(false);
            SpellBookSkillsIce.SetActive(false);
        }

        if (Lightning == true){
            GameUILightning.SetActive(true);
            SpellBookImageLightning.SetActive(true);
            SpellBookSkillsLightning.SetActive(true);

            // LIGHTNING BASIC ATTACK
            if (Input.GetKeyDown(KeyCode.Mouse1)){
                LightningBasicAttack();
            }
        }
        else {
            GameUILightning.SetActive(false);
            SpellBookImageLightning.SetActive(false);
            SpellBookSkillsLightning.SetActive(false);
        }

        // FOR WEAPONS HOLDING
        if (Cutlass == true && Fire == true){
            FireCutlass.SetActive(true);
        }
        else{
            FireCutlass.SetActive(false);
        }

        if (Cutlass == true && Ice == true){
            IceCutlass.SetActive(true);
        }
        else{
            IceCutlass.SetActive(false);           
        }

        if (Cutlass == true && Lightning == true){
            LightningCutlass.SetActive(true);           
        }
        else{
            LightningCutlass.SetActive(false);             
        }

        if (Spear == true && Fire == true){
            FireSpear.SetActive(true);
        }
        else{
            FireSpear.SetActive(false);
        }

        if (Spear == true && Ice == true){
            IceSpear.SetActive(true);
        }
        else{
            IceSpear.SetActive(false);
        }

        if (Spear == true && Lightning == true){
            LightningSpear.SetActive(true);
        }
        else{
            LightningSpear.SetActive(false);
        }

        if (Hammer == true && Fire == true){
            FireHammer.SetActive(true);
        }
        else{
            FireHammer.SetActive(false);
        }

        if (Hammer == true && Ice == true){
            IceHammer.SetActive(true);
        }
        else{
            IceHammer.SetActive(false);
        }

        if (Hammer == true && Lightning == true){
            LightningHammer.SetActive(true);
        }
        else{
            LightningHammer.SetActive(false);
        }

        // Implementation for normal weapons only
        // Normal Cutlass
        if (Cutlass == true && Spear == false && Hammer == false && Fire == false && Ice == false && Lightning == false){
            NormalCutlass.SetActive(true);
        }
        else{
            NormalCutlass.SetActive(false);        
        }

        // Normal Spear
        if (Spear == true && Cutlass == false && Hammer == false && Fire == false && Ice == false && Lightning == false){
            NormalSpear.SetActive(true);
        }
        else{
            NormalSpear.SetActive(false);
        }

        // Normal Hammer
        if (Hammer == true && Spear == false && Cutlass == false && Fire == false && Ice == false && Lightning == false){
            NormalHammer.SetActive(true);
        }
        else{
            NormalHammer.SetActive(false);
        }

        if (isAttacking)
        {
            Collider activeWeaponCollider = null;

            // Determine which weapon collider to use based on the currently selected element
            if (Fire && Cutlass){
                activeWeaponCollider = FCWeaponCollider;
                FCWeaponCollider.enabled = true;
            }
            else if (Ice && Cutlass){
                activeWeaponCollider = ICWeaponCollider;
                ICWeaponCollider.enabled = true;
            }
            else if (Lightning && Cutlass){
                activeWeaponCollider = LCWeaponCollider;
                LCWeaponCollider.enabled = true;
            }
            else if (Fire && Spear){
                activeWeaponCollider = FSWeaponCollider;
                FSWeaponCollider.enabled = true;
            }
            else if (Ice && Spear){
                activeWeaponCollider = ISWeaponCollider;
                ISWeaponCollider.enabled = true;
            }
            else if (Lightning && Spear){
                activeWeaponCollider = LSWeaponCollider;
                LSWeaponCollider.enabled = true;
            }
            else if (Fire && Hammer){
                activeWeaponCollider = FHWeaponCollider;
                FHWeaponCollider.enabled = true;
            }
            else if (Ice && Hammer){
                activeWeaponCollider = IHWeaponCollider;
                IHWeaponCollider.enabled = true;
            }
            else if (Lightning && Hammer){
                activeWeaponCollider = LHWeaponCollider;
                LHWeaponCollider.enabled = true;
            }
            else if (Cutlass){
                activeWeaponCollider = NCWeaponCollider;
                NCWeaponCollider.enabled = true;
            }
            else if (Spear){
                activeWeaponCollider = NSWeaponCollider;
                NSWeaponCollider.enabled = true;
            }
            else if (Hammer){
                activeWeaponCollider = NHWeaponCollider;
                NHWeaponCollider.enabled = true;
            }

            // Check if the weapon collider is not null
            if (activeWeaponCollider != null)
            {
                if (!hitEnemies.ContainsKey(activeWeaponCollider))
                {
                    hitEnemies[activeWeaponCollider] = new HashSet<Collider>();
                }

                Vector3 halfExtents = activeWeaponCollider.bounds.extents;
                Vector3 center = activeWeaponCollider.bounds.center;

                halfExtents.x *= 1.0f; // Adjust the size if needed
                halfExtents.z *= 1.0f; // Adjust the size if needed

                Collider[] hitColliders = Physics.OverlapBox(center, halfExtents, activeWeaponCollider.transform.rotation, LayerMask.GetMask(enemyTag));
                foreach (Collider enemy in hitColliders)
                {
                    if (enemy.CompareTag(enemyTag) && !hitEnemies[activeWeaponCollider].Contains(enemy))
                    {
                        enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                        hitEnemies[activeWeaponCollider].Add(enemy);
                    }
                }
            }
        }
    }

    // BASIC ATTACK ABILITY CALLS
    public void CutlassBasicAttack(){
        if(!isAbilityCooldownCutlass){ // If the ability is not on cooldown
            damage = 5;
            isAttacking = true;
            isAbilityCooldownCutlass = true; // Sets the ability to be on cooldown
            CurrentCutlassBasicCooldown = CutlassBasicCooldown; // Current Cooldown becomes the basic cooldown
        }
    }

    public void CutlassEndAttack()
    {
        isAttacking = false;
        foreach (var enemies in hitEnemies.Values)
        {
            enemies.Clear();
        }
    }

    void SpearBasicAttack(){
        if(!isAbilityCooldownSpear){ // If the ability is not on cooldown
            damage = 5;
            isAttacking = true;
            isAbilityCooldownSpear = true; // Sets the ability to be on cooldown
            CurrentSpearBasicCooldown = SpearBasicCooldown; // Current Cooldown becomes the basic cooldown  
        }
    }

    public void SpearEndAttack()
    {
        isAttacking = false;
        foreach (var enemies in hitEnemies.Values)
        {
            enemies.Clear();
        }
    }

    void HammerBasicAttack(){
        if(!isAbilityCooldownHammer){ // If the ability is not on cooldown
            damage = 10;
            isAttacking = true;
            isAbilityCooldownHammer = true; // Sets the ability to be on cooldown
            CurrentHammerBasicCooldown = HammerBasicCooldown; // Current Cooldown becomes the basic cooldown
        }
    }

    public void HammerEndAttack()
    {
        isAttacking = false;
        foreach (var enemies in hitEnemies.Values)
        {
            enemies.Clear();
        }
    }

    // In progress
    void FireBasicAttack(){
        EndAttack();
        if(!isAbilityCooldownFire){ // If the ability is not on cooldown
            isAbilityCooldownFire = true; // Sets the ability to be on cooldown
            animator.SetTrigger("FireBasicAttack"); // Triggers the ability animation
            CurrentFireBasicCooldown = FireBasicCooldown; // Current Cooldown becomes the basic cooldown

            Debug.Log("Fire Basic Attack"); // Performs the damage of the attack

        }
    }

    // In progress
    void IceBasicAttack(){
        EndAttack();
        if(!isAbilityCooldownIce){ // If the ability is not on cooldown
            isAbilityCooldownIce = true; // Sets the ability to be on cooldown
            animator.SetTrigger("IceBasicAttack"); // Triggers the ability animation
            CurrentIceBasicCooldown = IceBasicCooldown; // Current Cooldown becomes the basic cooldown

            Debug.Log("Ice Basic Attack"); // Performs the damage of the attack

        }
    }

    // In progress
    void LightningBasicAttack(){
        EndAttack();
        if(!isAbilityCooldownLightning){ // If the ability is not on cooldown
            isAbilityCooldownLightning = true; // Sets the ability to be on cooldown
            animator.SetTrigger("LightningBasicAttack"); // Triggers the ability animation
            CurrentLightningBasicCooldown = LightningBasicCooldown; // Current Cooldown becomes the basic cooldown

            Debug.Log("Lightning Basic Attack"); // Performs the damage of the attack

        }
    }

    public void EndAttack()
    {
        isAttacking = false;
        foreach (var enemies in hitEnemies.Values)
        {
            enemies.Clear();
        }
    }

    private void BasicAttackCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown)
    {
        if(isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if(currentCooldown <= 0f)
            {   
                isCooldown = false;
                currentCooldown = 0f;
            }
        }
    }

}
