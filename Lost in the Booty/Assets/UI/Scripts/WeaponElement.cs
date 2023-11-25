using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponElement : MonoBehaviour
{

    //Sounds
    public AudioClip swordAttackSound;
    public AudioClip magicAttackSound;

    private AudioSource audioSource;

    // WEAPON/ELEMENT BOOL FOR WHICH THEY CURRENTLY HAVE
    public bool Cutlass;
    public bool Spear;
    public bool Hammer;
    public bool Fire;
    public bool Ice;
    public bool Lightning;

    public Toggle Cutlasstoggle;
    public Toggle Speartoggle;
    public Toggle Hammertoggle;
    public Toggle Firetoggle;
    public Toggle Icetoggle;
    public Toggle Lightningtoggle;

    public GameObject CantSword;
    public GameObject CantSpear;
    public GameObject CantHammer;
    public GameObject CantFire;
    public GameObject CantIce;
    public GameObject CantLightning;

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

    // Stores the Elemental Attack Particles
    // FIRE
    public ParticleSystem FireParticles;
    public ParticleSystem FireexplosionParticles;
    private Collider FireCollider;
    private Vector3 FireinitialPosition;
    private bool Firemoving;
    private float fireTimer;

    // ICE
    public ParticleSystem IceParticles;
    public ParticleSystem IceexplosionParticles;
    private Collider IceCollider;
    private Vector3 IceinitialPosition;
    private bool Icemoving;
    private float iceTimer;

    // LIGHTNING
    public ParticleSystem LightningParticles;
    public ParticleSystem LigthningexplosionParticles;
    private Collider LightningCollider;
    private Vector3 LightninginitialPosition;
    private bool Lightningmoving;
    private float lightningTimer;

    private Transform characterTransform;

    // Enables the particle effects
    public GameObject FireBasicEnable;
    public GameObject IceBasicEnable;
    public GameObject LightningBasicEnable;

    // FOR BASIC ATTACK ANIMATIONS
    Animator animator;
    private ScruffyStats scruffystats;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        scruffystats = GetComponent<ScruffyStats>();

        Cutlasstoggle.onValueChanged.AddListener(delegate { ToggleChanged(Cutlasstoggle, ref Cutlass, CantSpear, CantHammer); });
        Speartoggle.onValueChanged.AddListener(delegate { ToggleChanged(Speartoggle, ref Spear, CantSword, CantHammer); });
        Hammertoggle.onValueChanged.AddListener(delegate { ToggleChanged(Hammertoggle, ref Hammer, CantSpear, CantSword); });
        Firetoggle.onValueChanged.AddListener(delegate { ToggleChanged(Firetoggle, ref Fire, CantIce, CantLightning); });
        Icetoggle.onValueChanged.AddListener(delegate { ToggleChanged(Icetoggle, ref Ice, CantFire, CantLightning); });
        Lightningtoggle.onValueChanged.AddListener(delegate { ToggleChanged(Lightningtoggle, ref Lightning, CantFire, CantIce); });

        // Get the weapon colliders
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

        FireCollider = FireParticles.GetComponent<Collider>();
        IceCollider = IceParticles.GetComponent<Collider>();
        LightningCollider = LightningParticles.GetComponent<Collider>();

        // Sets the weapon colliders to off
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

        FireCollider.enabled = false;
        IceCollider.enabled = false;
        LightningCollider.enabled = false;

        FireBasicEnable.SetActive(false);
        IceBasicEnable.SetActive(false);
        LightningBasicEnable.SetActive(false);

        // Initialize Initial positions for elemental basic attacks
        FireinitialPosition = FireParticles.transform.position;
        IceinitialPosition = IceParticles.transform.position;
        LightninginitialPosition = LightningParticles.transform.position;
        characterTransform = transform;


        if (Cutlass == true){
            GameUICutlass.SetActive(true);
            SpellBookImageCutlass.SetActive(true);
            SpellBookSkillsCutlass.SetActive(true);
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

    void ToggleChanged(Toggle toggle, ref bool weaponElement, GameObject cantElement1, GameObject cantElement2)
    {
        weaponElement = toggle.isOn;

        // Handle corresponding UI elements
        if (!weaponElement)
        {
            cantElement1.SetActive(false);
            cantElement2.SetActive(false);
        }
        else
        {
            cantElement1.SetActive(true);
            cantElement2.SetActive(true);
        }
    }

    // Cooldown times for basic abilities
    private float CutlassBasicCooldown = 1f;
    private float SpearBasicCooldown = 1f;
    private float HammerBasicCooldown = 2f;
    private float FireBasicCooldown = 2f;
    private float IceBasicCooldown = 2f;
    private float LightningBasicCooldown = 2f;

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
    public bool isShockEffect = false;
    private string enemyTag = "Enemy";
    private int damage;
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
                if(!isAbilityCooldownCutlass){
                    animator.SetTrigger("CutlassBasicAttack"); // Triggers the ability animation
                    isAbilityCooldownCutlass = true; // Sets the ability to be on cooldown
                    CurrentCutlassBasicCooldown = CutlassBasicCooldown; // Current Cooldown becomes the basic cooldown
                    //PlayAttackSound(swordAttackSound);
                }
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
                if(!isAbilityCooldownSpear){ // If the ability is not on cooldown
                    animator.SetTrigger("SpearBasicAttack"); // Triggers the ability animation
                    isAbilityCooldownSpear = true; // Sets the ability to be on cooldown
                    CurrentSpearBasicCooldown = SpearBasicCooldown; // Current Cooldown becomes the basic cooldown  
                    //PlayAttackSound(swordAttackSound);
}
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
                if(!isAbilityCooldownHammer){ // If the ability is not on cooldown
                    animator.SetTrigger("HammerBasicAttack"); // Triggers the ability animation
                    isAbilityCooldownHammer = true; // Sets the ability to be on cooldown
                    CurrentHammerBasicCooldown = HammerBasicCooldown; // Current Cooldown becomes the basic cooldown
                    //PlayAttackSound(swordAttackSound);
   }
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
                if(!isAbilityCooldownFire){ // If the ability is not on cooldown
                    characterTransform = transform;
                    animator.SetTrigger("FireBasicAttack"); // Triggers the ability animation
                    isAbilityCooldownFire = true; // Sets the ability to be on cooldown
                    CurrentFireBasicCooldown = FireBasicCooldown; // Current Cooldown becomes the basic cooldown
                    //PlayAttackSound(magicAttackSound);

                }
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
                if(!isAbilityCooldownIce){ // If the ability is not on cooldown
                    characterTransform = transform;
                    animator.SetTrigger("IceBasicAttack"); // Triggers the ability animation
                    isAbilityCooldownIce = true; // Sets the ability to be on cooldown
                    CurrentIceBasicCooldown = IceBasicCooldown; // Current Cooldown becomes the basic cooldown
                    //PlayAttackSound(magicAttackSound);
}
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
                if(!isAbilityCooldownLightning){ // If the ability is not on cooldown
                    characterTransform = transform;
                    animator.SetTrigger("LightningBasicAttack"); // Triggers the ability animation
                    isAbilityCooldownLightning = true; // Sets the ability to be on cooldown
                    CurrentLightningBasicCooldown = LightningBasicCooldown; // Current Cooldown becomes the basic cooldown
                    //PlayAttackSound(magicAttackSound);
}
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
                        if(isShockEffect == true){
                            enemy.GetComponent<EnemyStats>().InflictShock();
                        }
                        enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                        hitEnemies[activeWeaponCollider].Add(enemy);
                    }
                }
            }
        }
    }

    // BASIC ATTACK ABILITY CALLS
    public void CutlassBasicAttack(){
        damage = (int) (scruffystats.damage);
        isAttacking = true;
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
        damage = (int) (scruffystats.damage * 1.4);
        isAttacking = true;
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
        damage = (int) (scruffystats.damage * 1.8);
        isAttacking = true;
    }

    public void HammerEndAttack()
    {
        isAttacking = false;
        foreach (var enemies in hitEnemies.Values)
        {
            enemies.Clear();
        }
    }


    public bool DoubleDotDamage = false;
    public GameObject particleSpawnPoint;

    public float AttackRadius = 0.3f;
    private float FireparticleMoveSpeed = 4f;
    private float IceparticleMoveSpeed = 4f;
    private float LightningparticleMoveSpeed = 4f;
    private Vector3 initialParticleDirection;
    private float attackHeight = 1f; // Adjust this value to control the attack height
    private float distanceFromCharacter = 0.2f;

    private HashSet<Collider> hitFireEnemies = new HashSet<Collider>();
    private HashSet<Collider> hitIceEnemies = new HashSet<Collider>();
    private HashSet<Collider> hitLightningEnemies = new HashSet<Collider>();

    IEnumerator FireBasicAttack()
    {
        FireBasicEnable.SetActive(true);
        damage = (int) (scruffystats.damage);
        FireCollider.enabled = true;

        float startTime = Time.time;
        float journeyLength = 2.0f; // time

        // Store the initial position of particles with a height offset
        Vector3 originalPosition = characterTransform.position + characterTransform.forward * distanceFromCharacter + new Vector3(0, attackHeight, 0);

        // Store the initial direction of the particles
        Vector3 initialParticleDirection = characterTransform.forward;

        while (Time.time - startTime < journeyLength)
        {
            float distanceCovered = (Time.time - startTime) * FireparticleMoveSpeed;
            float journeyFraction = distanceCovered / journeyLength;

            // Calculate the new position based on the initial position and the fixed initial direction
            Vector3 newPosition = originalPosition + initialParticleDirection * distanceCovered;
            FireParticles.transform.position = newPosition;

            Collider[] hitColliders = Physics.OverlapSphere(newPosition, AttackRadius, LayerMask.GetMask(enemyTag));
            foreach (Collider enemy in hitColliders)
            {
                if (enemy.CompareTag(enemyTag) && !hitFireEnemies.Contains(enemy))
                {
                    if(DoubleDotDamage == true){
                        enemy.GetComponent<EnemyStats>().StartCoroutine(enemy.GetComponent<EnemyStats>().TakeDamageOverTime("fire", 2*(damage*1/5), 3f, 0.5f));
                    }
                    else{
                        enemy.GetComponent<EnemyStats>().StartCoroutine(enemy.GetComponent<EnemyStats>().TakeDamageOverTime("fire", damage*1/5, 3f, 0.5f));
                    }
                    hitFireEnemies.Add(enemy);
                }
            }

            yield return null; // Wait for the next frame
        }

        FireEndBasic();
    }

    void FireEndBasic()
    {
        FireParticles.transform.position = FireinitialPosition;
        FireCollider.enabled = false;
        FireBasicEnable.SetActive(false);
        hitFireEnemies.Clear(); // Reset the set of hit enemies
    }
    
    IEnumerator IceBasicAttack()
    {
        IceBasicEnable.SetActive(true);
        int damage = (int) (scruffystats.damage); // Set the damage value for the ice attack

        float startTime = Time.time;
        float journeyLength = 2.0f; // 2 seconds for the ice attack (you can adjust this value)

        // Store the initial position of particles with a height offset
        Vector3 originalPosition = characterTransform.position + characterTransform.forward * distanceFromCharacter + new Vector3(0, attackHeight, 0);

        // Store the initial direction of the particles
        initialParticleDirection = characterTransform.forward;

        while (Time.time - startTime < journeyLength)
        {
            float distanceCovered = (Time.time - startTime) * IceparticleMoveSpeed;
            float journeyFraction = distanceCovered / journeyLength;

            // Calculate the new position based on the initial position and the fixed initial direction
            IceParticles.transform.position = originalPosition + initialParticleDirection * distanceCovered;

            // Check for collisions with enemies using Physics.OverlapSphere
            Collider[] hitColliders = Physics.OverlapSphere(IceParticles.transform.position, AttackRadius, LayerMask.GetMask(enemyTag));
            foreach (Collider enemy in hitColliders)
            {
                if (enemy.CompareTag(enemyTag) && !hitIceEnemies.Contains(enemy))
                {
                    enemy.GetComponent<EnemyStats>().ApplySlow(1);
                    enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                    hitIceEnemies.Add(enemy);
                }
            }

            yield return null; // Wait for the next frame
        }

        IceEndBasic();
    }

    void IceEndBasic()
    {
        IceParticles.transform.position = IceinitialPosition;
        IceBasicEnable.SetActive(false);
        hitIceEnemies.Clear();
    }

    IEnumerator LightningBasicAttack()
    {
        LightningBasicEnable.SetActive(true);
        int damage = (int) (scruffystats.damage); // Set the damage value for the lightning attack

        float startTime = Time.time;
        float journeyLength = 2.0f; // 2 seconds for the lightning attack (you can adjust this value)

        // Store the initial position of particles with a height offset
        Vector3 originalPosition = characterTransform.position + characterTransform.forward * distanceFromCharacter + new Vector3(0, attackHeight, 0);

        // Store the initial direction of the particles
        initialParticleDirection = characterTransform.forward;

        while (Time.time - startTime < journeyLength)
        {
            float distanceCovered = (Time.time - startTime) * LightningparticleMoveSpeed;
            float journeyFraction = distanceCovered / journeyLength;

            // Calculate the new position based on the initial position and the fixed initial direction
            LightningParticles.transform.position = originalPosition + initialParticleDirection * distanceCovered;

            // Check for collisions with enemies using Physics.OverlapSphere
            Collider[] hitColliders = Physics.OverlapSphere(LightningParticles.transform.position, AttackRadius, LayerMask.GetMask(enemyTag));
            foreach (Collider enemy in hitColliders)
            {
                if (enemy.CompareTag(enemyTag) && !hitLightningEnemies.Contains(enemy))
                {
                    enemy.GetComponent<EnemyStats>().InflictShock();
                    enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                    hitLightningEnemies.Add(enemy);
                }
            }

            yield return null; // Wait for the next frame
        }

        LightningEndBasic();
    }

    void LightningEndBasic()
    {
        LightningParticles.transform.position = LightninginitialPosition;
        LightningBasicEnable.SetActive(false);
        hitLightningEnemies.Clear();
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

    private void PlayAttackSound(AudioClip attackSound)
    {
        // Check if the AudioSource and AudioClip are set
        if (audioSource != null && attackSound != null)
        {
            // Play the attack sound
            audioSource.PlayOneShot(attackSound);
        }
    }

}
