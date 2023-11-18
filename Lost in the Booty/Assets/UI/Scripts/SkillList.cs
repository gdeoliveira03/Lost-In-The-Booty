using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillList : MonoBehaviour
{
    [SerializeField]
    public Image[] ImageComponents;
    private Sprite[] CurrentSkill;

    public Sprite Sword1;
    public Sprite Sword2;
    public Sprite Sword3;
    public Sprite Sword4;
    public Sprite Sword5;

    public Sprite Spear1;
    public Sprite Spear2;
    public Sprite Spear3;
    public Sprite Spear4;
    public Sprite Spear5;

    public Sprite Hammer1;
    public Sprite Hammer2;
    public Sprite Hammer3;
    public Sprite Hammer4;
    public Sprite Hammer5;

    public Sprite Fire1;
    public Sprite Fire2;
    public Sprite Fire3;
    public Sprite Fire4;
    public Sprite Fire5;

    public Sprite Ice1;
    public Sprite Ice2;
    public Sprite Ice3;
    public Sprite Ice4;
    public Sprite Ice5;

    public Sprite Lightning1;
    public Sprite Lightning2;
    public Sprite Lightning3;
    public Sprite Lightning4;
    public Sprite Lightning5;

    public GameObject SwordP1;
    public GameObject SwordP2;
    public GameObject SwordP3;
    public GameObject SwordP4;
    public GameObject SwordP5;

    public GameObject SpearP1;
    public GameObject SpearP2;
    public GameObject SpearP3;
    public GameObject SpearP4;
    public GameObject SpearP5;

    public GameObject HammerP1;
    public GameObject HammerP2;
    public GameObject HammerP3;
    public GameObject HammerP4;
    public GameObject HammerP5;

    public GameObject FireP1;
    public GameObject FireP2;
    public GameObject FireP3;
    public GameObject FireP4;
    public GameObject FireP5;

    public GameObject IceP1;
    public GameObject IceP2;
    public GameObject IceP3;
    public GameObject IceP4;
    public GameObject IceP5;
    
    public GameObject LightningP1;
    public GameObject LightningP2;
    public GameObject LightningP3;
    public GameObject LightningP4;
    public GameObject LightningP5;

    // Cooldown times for abilities
    private float Sword1CD = 3f;
    private float Sword2CD = 3f;
    private float Sword3CD = 3f;
    private float Sword4CD = 3f;
    private float Sword5CD = 3f;

    private float Spear1CD = 3f;
    private float Spear2CD = 3f;
    private float Spear3CD = 3f;
    private float Spear4CD = 3f;
    private float Spear5CD = 3f;

    private float Hammer1CD = 3f;
    private float Hammer2CD = 3f;
    private float Hammer3CD = 3f;
    private float Hammer4CD = 3f;
    private float Hammer5CD = 3f;

    private float Fire1CD = 3f;
    private float Fire2CD = 3f;
    private float Fire3CD = 3f;
    private float Fire4CD = 3f;
    private float Fire5CD = 3f;
    
    private float Ice1CD = 3f;
    private float Ice2CD = 3f;
    private float Ice3CD = 3f;
    private float Ice4CD = 3f;
    private float Ice5CD = 3f;

    private float Lightning1CD = 3f;
    private float Lightning2CD = 3f;
    private float Lightning3CD = 3f;
    private float Lightning4CD = 3f;
    private float Lightning5CD = 3f;

    // Cooldown true/false for basic abilities
    private bool isAbilitySword1CD = false;
    private bool isAbilitySword2CD = false;
    private bool isAbilitySword3CD = false;
    private bool isAbilitySword4CD = false;
    private bool isAbilitySword5CD = false;

    private bool isAbilitySpear1CD = false;
    private bool isAbilitySpear2CD = false;
    private bool isAbilitySpear3CD = false;
    private bool isAbilitySpear4CD = false;
    private bool isAbilitySpear5CD = false;

    private bool isAbilityHammer1CD = false;
    private bool isAbilityHammer2CD = false;
    private bool isAbilityHammer3CD = false;
    private bool isAbilityHammer4CD = false;
    private bool isAbilityHammer5CD = false;

    private bool isAbilityFire1CD = false;
    private bool isAbilityFire2CD = false;
    private bool isAbilityFire3CD = false;
    private bool isAbilityFire4CD = false;
    private bool isAbilityFire5CD = false;

    private bool isAbilityIce1CD = false;
    private bool isAbilityIce2CD = false;
    private bool isAbilityIce3CD = false;
    private bool isAbilityIce4CD = false;
    private bool isAbilityIce5CD = false;

    private bool isAbilityLightning1CD = false;
    private bool isAbilityLightning2CD = false;
    private bool isAbilityLightning3CD = false;
    private bool isAbilityLightning4CD = false;
    private bool isAbilityLightning5CD = false;

    // Current Cooldown for basic abilities
    private float CurrentSword1CD;
    private float CurrentSword2CD;
    private float CurrentSword3CD;
    private float CurrentSword4CD;
    private float CurrentSword5CD;

    private float CurrentSpear1CD;
    private float CurrentSpear2CD;
    private float CurrentSpear3CD;
    private float CurrentSpear4CD;
    private float CurrentSpear5CD;

    private float CurrentHammer1CD;
    private float CurrentHammer2CD;
    private float CurrentHammer3CD;
    private float CurrentHammer4CD;
    private float CurrentHammer5CD;

    private float CurrentFire1CD;
    private float CurrentFire2CD;
    private float CurrentFire3CD;
    private float CurrentFire4CD;
    private float CurrentFire5CD;

    private float CurrentIce1CD;
    private float CurrentIce2CD;
    private float CurrentIce3CD;
    private float CurrentIce4CD;
    private float CurrentIce5CD;

    private float CurrentLightning1CD;
    private float CurrentLightning2CD;
    private float CurrentLightning3CD;
    private float CurrentLightning4CD;
    private float CurrentLightning5CD;

    private Animator animator;
    private ScruffyStats scruffystats;
    private int damage;
    private PlayerStateMachine MovementScript;

    void Start(){
        animator = GetComponent<Animator>();
        scruffystats = GetComponent<ScruffyStats>();
        MovementScript = GetComponent<PlayerStateMachine>();
        CurrentSkill = new Sprite[5];
    }

    void Update(){

        BasicAttackCooldown(ref CurrentSword1CD, Sword1CD, ref isAbilitySword1CD);
        BasicAttackCooldown(ref CurrentSword2CD, Sword2CD, ref isAbilitySword2CD);
        BasicAttackCooldown(ref CurrentSword3CD, Sword3CD, ref isAbilitySword3CD);
        BasicAttackCooldown(ref CurrentSword4CD, Sword4CD, ref isAbilitySword4CD);
        BasicAttackCooldown(ref CurrentSword5CD, Sword5CD, ref isAbilitySword5CD);

        BasicAttackCooldown(ref CurrentSpear1CD, Spear1CD, ref isAbilitySpear1CD);
        BasicAttackCooldown(ref CurrentSpear2CD, Spear2CD, ref isAbilitySpear2CD);
        BasicAttackCooldown(ref CurrentSpear3CD, Spear3CD, ref isAbilitySpear3CD);
        BasicAttackCooldown(ref CurrentSpear4CD, Spear4CD, ref isAbilitySpear4CD);
        BasicAttackCooldown(ref CurrentSpear5CD, Spear5CD, ref isAbilitySpear5CD);

        BasicAttackCooldown(ref CurrentHammer1CD, Hammer1CD, ref isAbilityHammer1CD);
        BasicAttackCooldown(ref CurrentHammer2CD, Hammer2CD, ref isAbilityHammer2CD);
        BasicAttackCooldown(ref CurrentHammer3CD, Hammer3CD, ref isAbilityHammer3CD);
        BasicAttackCooldown(ref CurrentHammer4CD, Hammer4CD, ref isAbilityHammer4CD);
        BasicAttackCooldown(ref CurrentHammer5CD, Hammer5CD, ref isAbilityHammer5CD);

        BasicAttackCooldown(ref CurrentFire1CD, Fire1CD, ref isAbilityFire1CD);
        BasicAttackCooldown(ref CurrentFire2CD, Fire2CD, ref isAbilityFire2CD);
        BasicAttackCooldown(ref CurrentFire3CD, Fire3CD, ref isAbilityFire3CD);
        BasicAttackCooldown(ref CurrentFire4CD, Fire4CD, ref isAbilityFire4CD);
        BasicAttackCooldown(ref CurrentFire5CD, Fire5CD, ref isAbilityFire5CD);

        BasicAttackCooldown(ref CurrentIce1CD, Ice1CD, ref isAbilityIce1CD);
        BasicAttackCooldown(ref CurrentIce2CD, Ice2CD, ref isAbilityIce2CD);
        BasicAttackCooldown(ref CurrentIce3CD, Ice3CD, ref isAbilityIce3CD);
        BasicAttackCooldown(ref CurrentIce4CD, Ice4CD, ref isAbilityIce4CD);
        BasicAttackCooldown(ref CurrentIce5CD, Ice5CD, ref isAbilityIce5CD);

        BasicAttackCooldown(ref CurrentLightning1CD, Lightning1CD, ref isAbilityLightning1CD);
        BasicAttackCooldown(ref CurrentLightning2CD, Lightning2CD, ref isAbilityLightning2CD);
        BasicAttackCooldown(ref CurrentLightning3CD, Lightning3CD, ref isAbilityLightning3CD);
        BasicAttackCooldown(ref CurrentLightning4CD, Lightning4CD, ref isAbilityLightning4CD);
        BasicAttackCooldown(ref CurrentLightning5CD, Lightning5CD, ref isAbilityLightning5CD);

        
        if (ImageComponents[0].sprite != null){
            CurrentSkill[0] = ImageComponents[0].sprite;
        }
        if (ImageComponents[1].sprite != null){
            CurrentSkill[1] = ImageComponents[1].sprite;
        }
        if (ImageComponents[2].sprite != null){
            CurrentSkill[2] = ImageComponents[2].sprite;
        }
        if (ImageComponents[3].sprite != null){
            CurrentSkill[3] = ImageComponents[3].sprite;
        }
        if (ImageComponents[4].sprite != null){
            CurrentSkill[4] = ImageComponents[4].sprite;
        }

        if (CurrentSkill[0] != null){ //Just to make sure nothing happens if the Current Skill is NULL
            if (Input.GetKeyDown(KeyCode.Alpha1 + 0))
            {
                if (ReferenceEquals(CurrentSkill[0], Sword1)) sword1();
                else if (ReferenceEquals(CurrentSkill[0], Sword2)) sword2();
                else if (ReferenceEquals(CurrentSkill[0], Sword3)) sword3();
                else if (ReferenceEquals(CurrentSkill[0], Sword4)) sword4();
                else if (ReferenceEquals(CurrentSkill[0], Sword5)) sword5();
                else if (ReferenceEquals(CurrentSkill[0], Spear1)) spear1();
                else if (ReferenceEquals(CurrentSkill[0], Spear2)) spear2();
                else if (ReferenceEquals(CurrentSkill[0], Spear3)) spear3();
                else if (ReferenceEquals(CurrentSkill[0], Spear4)) spear4();
                else if (ReferenceEquals(CurrentSkill[0], Spear5)) spear5();
                else if (ReferenceEquals(CurrentSkill[0], Hammer1)) hammer1();
                else if (ReferenceEquals(CurrentSkill[0], Hammer2)) hammer2();
                else if (ReferenceEquals(CurrentSkill[0], Hammer3)) hammer3();
                else if (ReferenceEquals(CurrentSkill[0], Hammer4)) hammer4();
                else if (ReferenceEquals(CurrentSkill[0], Hammer5)) hammer5();
                else if (ReferenceEquals(CurrentSkill[0], Fire1)) fire1();
                else if (ReferenceEquals(CurrentSkill[0], Fire2)) fire2();
                else if (ReferenceEquals(CurrentSkill[0], Fire3)) fire3();
                else if (ReferenceEquals(CurrentSkill[0], Fire4)) fire4();
                else if (ReferenceEquals(CurrentSkill[0], Fire5)) fire5();
                else if (ReferenceEquals(CurrentSkill[0], Ice1)) ice1();
                else if (ReferenceEquals(CurrentSkill[0], Ice2)) ice2();
                else if (ReferenceEquals(CurrentSkill[0], Ice3)) ice3();
                else if (ReferenceEquals(CurrentSkill[0], Ice4)) ice4();
                else if (ReferenceEquals(CurrentSkill[0], Ice5)) ice5();
                else if (ReferenceEquals(CurrentSkill[0], Lightning1)) lightning1();
                else if (ReferenceEquals(CurrentSkill[0], Lightning2)) lightning2();
                else if (ReferenceEquals(CurrentSkill[0], Lightning3)) lightning3();
                else if (ReferenceEquals(CurrentSkill[0], Lightning4)) lightning4();
                else if (ReferenceEquals(CurrentSkill[0], Lightning5)) lightning5();
            }
        }
        if (CurrentSkill[1] != null){ //Just to make sure nothing happens if the Current Skill is NULL
            if (Input.GetKeyDown(KeyCode.Alpha1 + 1))
            {
                if (ReferenceEquals(CurrentSkill[1], Sword1)) sword1();
                else if (ReferenceEquals(CurrentSkill[1], Sword2)) sword2();
                else if (ReferenceEquals(CurrentSkill[1], Sword3)) sword3();
                else if (ReferenceEquals(CurrentSkill[1], Sword4)) sword4();
                else if (ReferenceEquals(CurrentSkill[1], Sword5)) sword5();
                else if (ReferenceEquals(CurrentSkill[1], Spear1)) spear1();
                else if (ReferenceEquals(CurrentSkill[1], Spear2)) spear2();
                else if (ReferenceEquals(CurrentSkill[1], Spear3)) spear3();
                else if (ReferenceEquals(CurrentSkill[1], Spear4)) spear4();
                else if (ReferenceEquals(CurrentSkill[1], Spear5)) spear5();
                else if (ReferenceEquals(CurrentSkill[1], Hammer1)) hammer1();
                else if (ReferenceEquals(CurrentSkill[1], Hammer2)) hammer2();
                else if (ReferenceEquals(CurrentSkill[1], Hammer3)) hammer3();
                else if (ReferenceEquals(CurrentSkill[1], Hammer4)) hammer4();
                else if (ReferenceEquals(CurrentSkill[1], Hammer5)) hammer5();
                else if (ReferenceEquals(CurrentSkill[1], Fire1)) fire1();
                else if (ReferenceEquals(CurrentSkill[1], Fire2)) fire2();
                else if (ReferenceEquals(CurrentSkill[1], Fire3)) fire3();
                else if (ReferenceEquals(CurrentSkill[1], Fire4)) fire4();
                else if (ReferenceEquals(CurrentSkill[1], Fire5)) fire5();
                else if (ReferenceEquals(CurrentSkill[1], Ice1)) ice1();
                else if (ReferenceEquals(CurrentSkill[1], Ice2)) ice2();
                else if (ReferenceEquals(CurrentSkill[1], Ice3)) ice3();
                else if (ReferenceEquals(CurrentSkill[1], Ice4)) ice4();
                else if (ReferenceEquals(CurrentSkill[1], Ice5)) ice5();
                else if (ReferenceEquals(CurrentSkill[1], Lightning1)) lightning1();
                else if (ReferenceEquals(CurrentSkill[1], Lightning2)) lightning2();
                else if (ReferenceEquals(CurrentSkill[1], Lightning3)) lightning3();
                else if (ReferenceEquals(CurrentSkill[1], Lightning4)) lightning4();
                else if (ReferenceEquals(CurrentSkill[1], Lightning5)) lightning5();
            }
        }
        if (CurrentSkill[2] != null){ //Just to make sure nothing happens if the Current Skill is NULL
            if (Input.GetKeyDown(KeyCode.Alpha1 + 2))
            {
                if (ReferenceEquals(CurrentSkill[2], Sword1)) sword1();
                else if (ReferenceEquals(CurrentSkill[2], Sword2)) sword2();
                else if (ReferenceEquals(CurrentSkill[2], Sword3)) sword3();
                else if (ReferenceEquals(CurrentSkill[2], Sword4)) sword4();
                else if (ReferenceEquals(CurrentSkill[2], Sword5)) sword5();
                else if (ReferenceEquals(CurrentSkill[2], Spear1)) spear1();
                else if (ReferenceEquals(CurrentSkill[2], Spear2)) spear2();
                else if (ReferenceEquals(CurrentSkill[2], Spear3)) spear3();
                else if (ReferenceEquals(CurrentSkill[2], Spear4)) spear4();
                else if (ReferenceEquals(CurrentSkill[2], Spear5)) spear5();
                else if (ReferenceEquals(CurrentSkill[2], Hammer1)) hammer1();
                else if (ReferenceEquals(CurrentSkill[2], Hammer2)) hammer2();
                else if (ReferenceEquals(CurrentSkill[2], Hammer3)) hammer3();
                else if (ReferenceEquals(CurrentSkill[2], Hammer4)) hammer4();
                else if (ReferenceEquals(CurrentSkill[2], Hammer5)) hammer5();
                else if (ReferenceEquals(CurrentSkill[2], Fire1)) fire1();
                else if (ReferenceEquals(CurrentSkill[2], Fire2)) fire2();
                else if (ReferenceEquals(CurrentSkill[2], Fire3)) fire3();
                else if (ReferenceEquals(CurrentSkill[2], Fire4)) fire4();
                else if (ReferenceEquals(CurrentSkill[2], Fire5)) fire5();
                else if (ReferenceEquals(CurrentSkill[2], Ice1)) ice1();
                else if (ReferenceEquals(CurrentSkill[2], Ice2)) ice2();
                else if (ReferenceEquals(CurrentSkill[2], Ice3)) ice3();
                else if (ReferenceEquals(CurrentSkill[2], Ice4)) ice4();
                else if (ReferenceEquals(CurrentSkill[2], Ice5)) ice5();
                else if (ReferenceEquals(CurrentSkill[2], Lightning1)) lightning1();
                else if (ReferenceEquals(CurrentSkill[2], Lightning2)) lightning2();
                else if (ReferenceEquals(CurrentSkill[2], Lightning3)) lightning3();
                else if (ReferenceEquals(CurrentSkill[2], Lightning4)) lightning4();
                else if (ReferenceEquals(CurrentSkill[2], Lightning5)) lightning5();
            }
        }
        if (CurrentSkill[3] != null){ //Just to make sure nothing happens if the Current Skill is NULL
            if (Input.GetKeyDown(KeyCode.Alpha1 + 3))
            {
                if (ReferenceEquals(CurrentSkill[3], Sword1)) sword1();
                else if (ReferenceEquals(CurrentSkill[3], Sword2)) sword2();
                else if (ReferenceEquals(CurrentSkill[3], Sword3)) sword3();
                else if (ReferenceEquals(CurrentSkill[3], Sword4)) sword4();
                else if (ReferenceEquals(CurrentSkill[3], Sword5)) sword5();
                else if (ReferenceEquals(CurrentSkill[3], Spear1)) spear1();
                else if (ReferenceEquals(CurrentSkill[3], Spear2)) spear2();
                else if (ReferenceEquals(CurrentSkill[3], Spear3)) spear3();
                else if (ReferenceEquals(CurrentSkill[3], Spear4)) spear4();
                else if (ReferenceEquals(CurrentSkill[3], Spear5)) spear5();
                else if (ReferenceEquals(CurrentSkill[3], Hammer1)) hammer1();
                else if (ReferenceEquals(CurrentSkill[3], Hammer2)) hammer2();
                else if (ReferenceEquals(CurrentSkill[3], Hammer3)) hammer3();
                else if (ReferenceEquals(CurrentSkill[3], Hammer4)) hammer4();
                else if (ReferenceEquals(CurrentSkill[3], Hammer5)) hammer5();
                else if (ReferenceEquals(CurrentSkill[3], Fire1)) fire1();
                else if (ReferenceEquals(CurrentSkill[3], Fire2)) fire2();
                else if (ReferenceEquals(CurrentSkill[3], Fire3)) fire3();
                else if (ReferenceEquals(CurrentSkill[3], Fire4)) fire4();
                else if (ReferenceEquals(CurrentSkill[3], Fire5)) fire5();
                else if (ReferenceEquals(CurrentSkill[3], Ice1)) ice1();
                else if (ReferenceEquals(CurrentSkill[3], Ice2)) ice2();
                else if (ReferenceEquals(CurrentSkill[3], Ice3)) ice3();
                else if (ReferenceEquals(CurrentSkill[3], Ice4)) ice4();
                else if (ReferenceEquals(CurrentSkill[3], Ice5)) ice5();
                else if (ReferenceEquals(CurrentSkill[3], Lightning1)) lightning1();
                else if (ReferenceEquals(CurrentSkill[3], Lightning2)) lightning2();
                else if (ReferenceEquals(CurrentSkill[3], Lightning3)) lightning3();
                else if (ReferenceEquals(CurrentSkill[3], Lightning4)) lightning4();
                else if (ReferenceEquals(CurrentSkill[3], Lightning5)) lightning5();
            }
        }
        if (CurrentSkill[4] != null){ //Just to make sure nothing happens if the Current Skill is NULL
            if (Input.GetKeyDown(KeyCode.Alpha1 + 4))
            {
                if (ReferenceEquals(CurrentSkill[4], Sword1)) sword1();
                else if (ReferenceEquals(CurrentSkill[4], Sword2)) sword2();
                else if (ReferenceEquals(CurrentSkill[4], Sword3)) sword3();
                else if (ReferenceEquals(CurrentSkill[4], Sword4)) sword4();
                else if (ReferenceEquals(CurrentSkill[4], Sword5)) sword5();
                else if (ReferenceEquals(CurrentSkill[4], Spear1)) spear1();
                else if (ReferenceEquals(CurrentSkill[4], Spear2)) spear2();
                else if (ReferenceEquals(CurrentSkill[4], Spear3)) spear3();
                else if (ReferenceEquals(CurrentSkill[4], Spear4)) spear4();
                else if (ReferenceEquals(CurrentSkill[4], Spear5)) spear5();
                else if (ReferenceEquals(CurrentSkill[4], Hammer1)) hammer1();
                else if (ReferenceEquals(CurrentSkill[4], Hammer2)) hammer2();
                else if (ReferenceEquals(CurrentSkill[4], Hammer3)) hammer3();
                else if (ReferenceEquals(CurrentSkill[4], Hammer4)) hammer4();
                else if (ReferenceEquals(CurrentSkill[4], Hammer5)) hammer5();
                else if (ReferenceEquals(CurrentSkill[4], Fire1)) fire1();
                else if (ReferenceEquals(CurrentSkill[4], Fire2)) fire2();
                else if (ReferenceEquals(CurrentSkill[4], Fire3)) fire3();
                else if (ReferenceEquals(CurrentSkill[4], Fire4)) fire4();
                else if (ReferenceEquals(CurrentSkill[4], Fire5)) fire5();
                else if (ReferenceEquals(CurrentSkill[4], Ice1)) ice1();
                else if (ReferenceEquals(CurrentSkill[4], Ice2)) ice2();
                else if (ReferenceEquals(CurrentSkill[4], Ice3)) ice3();
                else if (ReferenceEquals(CurrentSkill[4], Ice4)) ice4();
                else if (ReferenceEquals(CurrentSkill[4], Ice5)) ice5();
                else if (ReferenceEquals(CurrentSkill[4], Lightning1)) lightning1();
                else if (ReferenceEquals(CurrentSkill[4], Lightning2)) lightning2();
                else if (ReferenceEquals(CurrentSkill[4], Lightning3)) lightning3();
                else if (ReferenceEquals(CurrentSkill[4], Lightning4)) lightning4();
                else if (ReferenceEquals(CurrentSkill[4], Lightning5)) lightning5();
            }
        }
            
        
    }
    

    //SWORD 1 STARTS HERE

    private BoxCollider sword1_1col;
    private BoxCollider sword1_2col;
    private BoxCollider sword1_3col;
    private int swdamage1_1;
    private int swdamage1_2;
    private int swdamage1_3;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesSword1 = new Dictionary<BoxCollider, HashSet<Collider>>();

    //Individual Ability Actions Begin Here, these define what each skill does.
    void sword1()
    {
        swdamage1_1 = (int) (scruffystats.damage);
        swdamage1_2 = (int) (scruffystats.damage);
        swdamage1_3 = (int) (scruffystats.damage);

        // Gets the colliders for the first, second and third hit.
        BoxCollider[] sw1colliders = SwordP1.GetComponentsInChildren<BoxCollider>();
        sword1_1col = sw1colliders[0]; // First Slash
        sword1_3col = sw1colliders[1]; //Third Slash
        ParticleSystem Slash1 = SwordP1.GetComponentInChildren<ParticleSystem>();
        ParticleSystem[] Slash2 = Slash1.GetComponentsInChildren<ParticleSystem>();
        sword1_2col = Slash2[4].GetComponent<BoxCollider>(); // Second Slash

        //Keeps colliders disactivated
        sword1_1col.enabled = false;
        sword1_2col.enabled = false;
        sword1_3col.enabled = false;

        if (!hitEnemiesSword1.ContainsKey(sword1_1col))
        {
            hitEnemiesSword1.Add(sword1_1col, new HashSet<Collider>()); 
        }
        if (!hitEnemiesSword1.ContainsKey(sword1_2col))
        {
            hitEnemiesSword1.Add(sword1_2col, new HashSet<Collider>());
        }
        if (!hitEnemiesSword1.ContainsKey(sword1_3col))
        {
            hitEnemiesSword1.Add(sword1_3col, new HashSet<Collider>());
        }

        //Cooldown check
        if (!isAbilitySword1CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Sword1");
            CurrentSword1CD = Sword1CD;
            isAbilitySword1CD = true;

        }
    }

    void sword1start(){ //Calls the start of the ability
        SwordP1.SetActive(true);
        ParticleSystem PS = SwordP1.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("sword1_firsthit", 0.0f);
        Invoke("sword1_secondhit", 0.4f);
        Invoke("sword1_thirdhit", 0.9f);
        Invoke("sword1end", 1.2f); //Calls the end of the ability
    }

    void sword1_firsthit(){
        sword1_1col.enabled = true;
        CheckEnemiesInBoxColliderSword1(sword1_1col, swdamage1_1);
    }

    void sword1_secondhit(){
        sword1_2col.enabled = true;
        CheckEnemiesInBoxColliderSword1(sword1_2col, swdamage1_2);
    }

    void sword1_thirdhit(){
        sword1_3col.enabled = true;    
        CheckEnemiesInBoxColliderSword1(sword1_3col, swdamage1_3);
    }

    void sword1end(){
        SwordP1.SetActive(false);
        MovementScript.enabled = true;
        sword1_1col.enabled = false;
        sword1_2col.enabled = false;
        sword1_3col.enabled = false;

        foreach (var collider in hitEnemiesSword1.Keys)
        {
            hitEnemiesSword1[collider].Clear();
        }
    }

    void CheckEnemiesInBoxColliderSword1(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesSword1[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesSword1[collider].Add(enemy);
            }
        }
    }




    // SWORD 2 STARTS HERE

    private BoxCollider sword2_1col;
    private BoxCollider sword2_2col;
    private BoxCollider sword2_3col;
    private int swdamage2_1;
    private int swdamage2_2;
    private int swdamage2_3;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesSword2 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void sword2()
    {
        swdamage2_1 = (int) (scruffystats.damage * 0.6);
        swdamage2_2 = (int) (scruffystats.damage * 0.6);
        swdamage2_3 = (int) (scruffystats.damage * 1.6);

        BoxCollider[] sw2colliders = SwordP2.GetComponentsInChildren<BoxCollider>();
        sword2_1col = sw2colliders[0]; // First Slash
        sword2_2col = sw2colliders[1]; // Second Slash
        Transform Slash1 =  SwordP2.transform.Find("Slash1");
        Transform Slash2 = Slash1.Find("Slash3Collider");
        sword2_3col = Slash2.GetComponent<BoxCollider>(); // Third Slash

        //Keeps colliders disactivated
        sword2_1col.enabled = false;
        sword2_2col.enabled = false;
        sword2_3col.enabled = false;

        if (!hitEnemiesSword2.ContainsKey(sword2_1col))
        {
            hitEnemiesSword2.Add(sword2_1col, new HashSet<Collider>()); 
        }
        if (!hitEnemiesSword2.ContainsKey(sword2_2col))
        {
            hitEnemiesSword2.Add(sword2_2col, new HashSet<Collider>());
        }
        if (!hitEnemiesSword2.ContainsKey(sword2_3col))
        {
            hitEnemiesSword2.Add(sword2_3col, new HashSet<Collider>());
        }

        if (!isAbilitySword2CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Sword2");
            CurrentSword2CD = Sword2CD;
            isAbilitySword2CD = true;
        }
    }

    void sword2start(){
        SwordP2.SetActive(true);
        ParticleSystem PS = SwordP2.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("sword2_firsthit", 0.0f);
        Invoke("sword2_secondhit", 0.6f);
        Invoke("sword2_thirdhit", 1.6f);
        Invoke("sword2end", 2.2f); //Calls the end of the ability
    }

    void sword2_firsthit(){
        sword2_1col.enabled = true;
        CheckEnemiesInBoxColliderSword2(sword2_1col, swdamage2_1);
    }

    void sword2_secondhit(){
        sword2_2col.enabled = true;
        CheckEnemiesInBoxColliderSword2(sword2_2col, swdamage2_2);
    }

    void sword2_thirdhit(){
        sword2_3col.enabled = true;    
        CheckEnemiesInBoxColliderSword2(sword2_3col, swdamage2_3);
    }

    void sword2end(){
        SwordP2.SetActive(false);
        MovementScript.enabled = true;
        sword2_1col.enabled = false;
        sword2_2col.enabled = false;
        sword2_3col.enabled = false;

        foreach (var collider in hitEnemiesSword2.Keys)
        {
            hitEnemiesSword2[collider].Clear();
        }
    }

    void CheckEnemiesInBoxColliderSword2(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesSword2[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesSword2[collider].Add(enemy);
            }
        }
    }






    private BoxCollider sword3col;
    private int swdamage3;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesSword3 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void sword3()
    {
        swdamage3 = (int) (scruffystats.damage * 1.8);

        sword3col = SwordP3.GetComponentInChildren<BoxCollider>();
        sword3col.enabled = false;

        if (!hitEnemiesSword3.ContainsKey(sword3col))
        {
            hitEnemiesSword3.Add(sword3col, new HashSet<Collider>()); 
        }

        if (!isAbilitySword3CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Sword3");
            CurrentSword3CD = Sword3CD;
            isAbilitySword3CD = true;
        }
    }

    void sword3start(){
        SwordP3.SetActive(true);
        ParticleSystem PS = SwordP3.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("sword3hit", 0f);
        Invoke("sword3end", 0.8f); //Calls the end of the ability
    }

    void sword3hit(){
        sword3col.enabled = true;
        CheckEnemiesInBoxColliderSword3(sword3col, swdamage3);
    }

    void sword3end(){
        SwordP3.SetActive(false);  
        MovementScript.enabled = true; 
        sword3col.enabled = false;

        foreach (var collider in hitEnemiesSword3.Keys)
        {
            hitEnemiesSword3[collider].Clear();
        }     
    }

    void CheckEnemiesInBoxColliderSword3(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesSword3[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesSword3[collider].Add(enemy);
            }
        }
    }



    void sword4()
    {
        if (!isAbilitySword4CD)
        {
            animator.SetTrigger("Sword4");
            CurrentSword4CD = Sword4CD;
            isAbilitySword4CD = true;
        }
    }

    void sword4start(){
        SwordP4.SetActive(true);
        ParticleSystem PS = SwordP4.GetComponentInChildren<ParticleSystem>();
        PS.Play();

        int Sword4heal = (int) (scruffystats.MaxHealth * 1/3);

        scruffystats.FlatHeal(Sword4heal);
        Invoke("sword4end", 5.0f);
    }

    void sword4end(){
        SwordP4.SetActive(false);       
    }



    double DmgBoostValue;
    double TakenDmgBoostValue;

    void sword5()
    {
        if (!isAbilitySword5CD)
        {
            animator.SetTrigger("Sword5");
            CurrentSword5CD = Sword5CD;
            isAbilitySword5CD = true;
        }
    }

    void sword5start(){
        SwordP5.SetActive(true);
        ParticleSystem PS = SwordP5.GetComponentInChildren<ParticleSystem>();
        PS.Play();

        DmgBoostValue = 1.5;
        TakenDmgBoostValue = 1.5;

        scruffystats.DamageBoost(DmgBoostValue);
        scruffystats.TakenDamageBoost(TakenDmgBoostValue);  

        Invoke("sword5end", 5.0f);
    }

    void sword5end(){
        SwordP5.SetActive(false);  
        scruffystats.DamageBoostEnd(DmgBoostValue);
        scruffystats.TakenDamageBoostEnd(TakenDmgBoostValue);     
    }





    // SPEAR 1 STARS HERE

    private BoxCollider spear1_1col;
    private BoxCollider spear1_2col;
    private BoxCollider spear1_3col;
    private BoxCollider spear1_4col;
    private BoxCollider spear1_5col;
    private BoxCollider spear1_6col;
    private int spdamage1_1;
    private int spdamage1_2;
    private int spdamage1_3;
    private int spdamage1_4;
    private int spdamage1_5;
    private int spdamage1_6;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesSpear1 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void spear1()
    {
        spdamage1_1 = (int) (scruffystats.damage * 0.5);
        spdamage1_2 = (int) (scruffystats.damage * 0.5);
        spdamage1_3 = (int) (scruffystats.damage * 0.5);
        spdamage1_4 = (int) (scruffystats.damage * 0.5);
        spdamage1_5 = (int) (scruffystats.damage * 0.5);
        spdamage1_6 = (int) (scruffystats.damage * 0.5);

        Transform Slash1 =  SpearP1.transform.Find("Star hit");
        Transform Slash2 = Slash1.Find("SpearColliders");
        BoxCollider[] spearattacks = Slash2.GetComponents<BoxCollider>(); // Third Slash

        spear1_1col = spearattacks[0];
        spear1_2col = spearattacks[1];
        spear1_3col = spearattacks[2];
        spear1_4col = spearattacks[3];
        spear1_5col = spearattacks[4];
        spear1_6col = spearattacks[5];
        
        //Keeps colliders disactivated
        spear1_1col.enabled = false;
        spear1_2col.enabled = false;
        spear1_3col.enabled = false;
        spear1_4col.enabled = false;
        spear1_5col.enabled = false;
        spear1_6col.enabled = false;

        if (!hitEnemiesSpear1.ContainsKey(spear1_1col))
        {
            hitEnemiesSpear1.Add(spear1_1col, new HashSet<Collider>()); 
        }
        if (!hitEnemiesSpear1.ContainsKey(spear1_2col))
        {
            hitEnemiesSpear1.Add(spear1_2col, new HashSet<Collider>());
        }
        if (!hitEnemiesSpear1.ContainsKey(spear1_3col))
        {
            hitEnemiesSpear1.Add(spear1_3col, new HashSet<Collider>());
        }
        if (!hitEnemiesSpear1.ContainsKey(spear1_4col))
        {
            hitEnemiesSpear1.Add(spear1_4col, new HashSet<Collider>()); 
        }
        if (!hitEnemiesSpear1.ContainsKey(spear1_5col))
        {
            hitEnemiesSpear1.Add(spear1_5col, new HashSet<Collider>());
        }
        if (!hitEnemiesSpear1.ContainsKey(spear1_6col))
        {
            hitEnemiesSpear1.Add(spear1_6col, new HashSet<Collider>());
        }

        if (!isAbilitySpear1CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Spear1");
            CurrentSpear1CD = Spear1CD;
            isAbilitySpear1CD = true;
        }
    }

    void spear1start(){
        SpearP1.SetActive(true);
        ParticleSystem PS = SpearP1.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("spear1_firsthit", 0.0f);
        Invoke("spear1_secondhit", 0.2f);
        Invoke("spear1_thirdhit", 0.4f);
        Invoke("spear1_fourthhit", 0.6f);
        Invoke("spear1_fifthhit", 0.8f);
        Invoke("spear1_sixthhit", 1f);
        Invoke("spear1end", 1.5f); 
    }

    void spear1_firsthit(){
        spear1_1col.enabled = true;
        CheckEnemiesInBoxColliderSpear1(spear1_1col, spdamage1_1);
    }

    void spear1_secondhit(){
        spear1_2col.enabled = true;
        CheckEnemiesInBoxColliderSpear1(spear1_2col, spdamage1_2);
    }

    void spear1_thirdhit(){
        spear1_3col.enabled = true;    
        CheckEnemiesInBoxColliderSpear1(spear1_3col, spdamage1_3);
    }

    void spear1_fourthhit(){
        spear1_4col.enabled = true;    
        CheckEnemiesInBoxColliderSpear1(spear1_4col, spdamage1_4);
    }
    void spear1_fifthhit(){
        spear1_5col.enabled = true;    
        CheckEnemiesInBoxColliderSpear1(spear1_5col, spdamage1_5);
    }
    void spear1_sixthhit(){
        spear1_6col.enabled = true;    
        CheckEnemiesInBoxColliderSpear1(spear1_6col, spdamage1_6);
    }

    void spear1end(){
        SpearP1.SetActive(false);
        MovementScript.enabled = true;
        spear1_1col.enabled = false;
        spear1_2col.enabled = false;
        spear1_3col.enabled = false;
        spear1_4col.enabled = false;
        spear1_5col.enabled = false;
        spear1_6col.enabled = false;

        foreach (var collider in hitEnemiesSpear1.Keys)
        {
            hitEnemiesSpear1[collider].Clear();
        }
    }

    void CheckEnemiesInBoxColliderSpear1(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesSpear1[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesSpear1[collider].Add(enemy);
            }
        }
    }
 






    // SPEAR 2


    private BoxCollider spear2col;
    private int spdamage2;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesSpear2 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void spear2()
    {
        spdamage2 = (int) (scruffystats.damage * 2.6);

        Transform Slash1 =  SpearP2.transform.Find("Magic circle");
        Transform Slash2 = Slash1.Find("Collider");
        spear2col = Slash2.GetComponent<BoxCollider>();
        
        spear2col.enabled = false;

        if (!hitEnemiesSpear2.ContainsKey(spear2col))
        {
            hitEnemiesSpear2.Add(spear2col, new HashSet<Collider>()); 
        }

        if (!isAbilitySpear2CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Spear2");
            CurrentSpear2CD = Spear2CD;
            isAbilitySpear2CD = true;
        }
    }

    void spear2start(){
        SpearP2.SetActive(true);
        ParticleSystem PS = SpearP2.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("spear2hit", 1.5f);
        Invoke("spear2end", 2.5f); 
    }

    void spear2hit(){
        spear2col.enabled = true;
        CheckEnemiesInBoxColliderSpear2(spear2col, spdamage2);
    }

    void spear2end(){
        SpearP2.SetActive(false);   
        MovementScript.enabled = true; 
        spear2col.enabled = false;

        foreach (var collider in hitEnemiesSpear2.Keys)
        {
            hitEnemiesSpear2[collider].Clear();
        }
    }

    void CheckEnemiesInBoxColliderSpear2(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesSpear2[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesSpear2[collider].Add(enemy);
            }
        }
    }
    







    void spear3()
    {
        if (!isAbilitySpear3CD)
        {
            animator.SetTrigger("Spear3");
            CurrentSpear3CD = Spear3CD;
            isAbilitySpear3CD = true;
        }
    }

    void spear3start(){
        SpearP3.SetActive(true);
        ParticleSystem PS = SpearP3.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void spear3end(){
        SpearP3.SetActive(false);    
    }
    




    private BoxCollider spear4col;
    private int spdamage4;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesSpear4 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void spear4()
    {
        spdamage4 = (int) (scruffystats.damage * 2);

        Transform Slash1 =  SpearP4.transform.Find("Slash1");
        Transform Slash2 = Slash1.Find("Collider");
        spear4col = Slash2.GetComponent<BoxCollider>();
        
        spear4col.enabled = false;

        if (!hitEnemiesSpear4.ContainsKey(spear4col))
        {
            hitEnemiesSpear4.Add(spear4col, new HashSet<Collider>()); 
        }

        if (!isAbilitySpear4CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Spear4");
            CurrentSpear4CD = Spear4CD;
            isAbilitySpear4CD = true;
        }
    }

    void spear4start(){
        SpearP4.SetActive(true);
        ParticleSystem PS = SpearP4.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("spear4hit", 0f);
        Invoke("spear4end", 0.6f); 
    }

    void spear4hit(){
        spear4col.enabled = true;
        CheckEnemiesInBoxColliderSpear4(spear4col, spdamage4);
    }

    void spear4end(){
        SpearP4.SetActive(false); 
        MovementScript.enabled = true;   
        spear4col.enabled = false;

        foreach (var collider in hitEnemiesSpear4.Keys)
        {
            hitEnemiesSpear4[collider].Clear();
        }
    }

    void CheckEnemiesInBoxColliderSpear4(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesSpear4[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesSpear4[collider].Add(enemy);
            }
        }
    }











    void spear5()
    {
        if (!isAbilitySpear5CD)
        {
            animator.SetTrigger("Spear5");
            CurrentSpear5CD = Spear5CD;
            isAbilitySpear5CD = true;
        }
    }

    void spear5start(){
        SpearP5.SetActive(true);
        ParticleSystem PS = SpearP5.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void spear5end(){
        SpearP5.SetActive(false);    
    }
    







    private BoxCollider hammer1_1col;
    private BoxCollider hammer1_2col;
    private int hadamage1_1;
    private int hadamage1_2;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesHammer1 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void hammer1()
    {
        hadamage1_1 = (int) (scruffystats.damage * 2);
        hadamage1_2 = (int) (scruffystats.damage * 1.6);

        Transform Slam1 =  HammerP1.transform.Find("Stones hit");
        Transform Slam2 = Slam1.Find("Collider");
        BoxCollider[] Slam3 = Slam2.GetComponents<BoxCollider>();

        hammer1_1col = Slam3[0];
        hammer1_2col = Slam3[1];
        
        hammer1_1col.enabled = false;
        hammer1_2col.enabled = false;

        if (!hitEnemiesHammer1.ContainsKey(hammer1_1col))
        {
            hitEnemiesHammer1.Add(hammer1_1col, new HashSet<Collider>()); 
        }
        if (!hitEnemiesHammer1.ContainsKey(hammer1_2col))
        {
            hitEnemiesHammer1.Add(hammer1_2col, new HashSet<Collider>()); 
        }

        if (!isAbilityHammer1CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Hammer1");
            CurrentHammer1CD = Hammer1CD;
            isAbilityHammer1CD = true;
        }
    }

    void hammer1start(){
        HammerP1.SetActive(true);
        ParticleSystem PS = HammerP1.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("hammer1_1hit", 0f);
        Invoke("hammer1_2hit", 1f);
        Invoke("hammer1end", 2f); 
    }

    void hammer1_1hit(){
        hammer1_1col.enabled = true;
        CheckEnemiesInBoxColliderHammer1(hammer1_1col, hadamage1_1);
    }
    void hammer1_2hit(){
        hammer1_2col.enabled = true;
        CheckEnemiesInBoxColliderHammer1(hammer1_2col, hadamage1_2);
    }


    void hammer1end(){
        HammerP1.SetActive(false); 
        MovementScript.enabled = true;
        hammer1_1col.enabled = false;
        hammer1_2col.enabled = false;

        foreach (var collider in hitEnemiesHammer1.Keys)
        {
            hitEnemiesHammer1[collider].Clear();
        }   
    }

    void CheckEnemiesInBoxColliderHammer1(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesHammer1[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesHammer1[collider].Add(enemy);
            }
        }
    }
    







    private BoxCollider hammer2_1col;
    private BoxCollider hammer2_2col;
    private BoxCollider hammer2_3col;
    private int hadamage2_1;
    private int hadamage2_2;
    private int hadamage2_3;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesHammer2 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void hammer2()
    {
        hadamage2_1 = (int) (scruffystats.damage * 1.2);
        hadamage2_2 = (int) (scruffystats.damage * 1.2);
        hadamage2_3 = (int) (scruffystats.damage * 1.2);

        Transform Slam1 =  HammerP2.transform.Find("Stones hit");
        Transform Slam2 = Slam1.Find("Collider");
        BoxCollider[] Slam3 = Slam2.GetComponents<BoxCollider>();

        hammer2_1col = Slam3[0];
        hammer2_2col = Slam3[1];
        hammer2_3col = Slam3[2];
        
        hammer2_1col.enabled = false;
        hammer2_2col.enabled = false;
        hammer2_3col.enabled = false;

        if (!hitEnemiesHammer2.ContainsKey(hammer2_1col))
        {
            hitEnemiesHammer2.Add(hammer2_1col, new HashSet<Collider>()); 
        }
        if (!hitEnemiesHammer2.ContainsKey(hammer2_2col))
        {
            hitEnemiesHammer2.Add(hammer2_2col, new HashSet<Collider>()); 
        }
        if (!hitEnemiesHammer2.ContainsKey(hammer2_3col))
        {
            hitEnemiesHammer2.Add(hammer2_3col, new HashSet<Collider>()); 
        }

        if (!isAbilityHammer2CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Hammer2");
            CurrentHammer2CD = Hammer2CD;
            isAbilityHammer2CD = true;
        }
    }

    void hammer2start(){
        HammerP2.SetActive(true);
        ParticleSystem PS = HammerP2.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("hammer2_1hit", 0f);
        Invoke("hammer2_2hit", 0.3f);
        Invoke("hammer2_3hit", 0.6f);
        Invoke("hammer2end", 1.2f); 
    }

    void hammer2_1hit(){
        hammer2_1col.enabled = true;
        CheckEnemiesInBoxColliderHammer2(hammer2_1col, hadamage2_1);
    }
    void hammer2_2hit(){
        hammer2_2col.enabled = true;
        CheckEnemiesInBoxColliderHammer2(hammer2_2col, hadamage2_2);
    }
    void hammer2_3hit(){
        hammer2_3col.enabled = true;
        CheckEnemiesInBoxColliderHammer2(hammer2_3col, hadamage2_3);
    }

    void hammer2end(){
        HammerP2.SetActive(false); 
        MovementScript.enabled = true;
        hammer2_1col.enabled = false;
        hammer2_2col.enabled = false;
        hammer2_3col.enabled = false;

        foreach (var collider in hitEnemiesHammer2.Keys)
        {
            hitEnemiesHammer2[collider].Clear();
        }   
    }

    
    void CheckEnemiesInBoxColliderHammer2(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesHammer2[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesHammer2[collider].Add(enemy);
            }
        }
    }
    









    private BoxCollider hammer3col;
    private int hadamage3;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesHammer3 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void hammer3()
    {
        hadamage3 = (int) (scruffystats.damage * 2);

        Transform Slam1 =  HammerP3.transform.Find("Stones hit");
        Transform Slam2 = Slam1.Find("Collider");
        hammer3col = Slam2.GetComponent<BoxCollider>();
        
        hammer3col.enabled = false;

        if (!hitEnemiesHammer3.ContainsKey(hammer3col))
        {
            hitEnemiesHammer3.Add(hammer3col, new HashSet<Collider>()); 
        }

        if (!isAbilityHammer3CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Hammer3");
            CurrentHammer3CD = Hammer3CD;
            isAbilityHammer3CD = true;
        }
    }

    void hammer3start(){
        HammerP3.SetActive(true);
        ParticleSystem PS = HammerP3.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("hammer3hit", 0f);
        Invoke("hammer3end", 0.8f); 
    }

    void hammer3hit(){
        hammer3col.enabled = true;
        CheckEnemiesInBoxColliderHammer3(hammer3col, hadamage3);
    }

    void hammer3end(){
        HammerP3.SetActive(false); 
        MovementScript.enabled = true;
        hammer3col.enabled = false;

        foreach (var collider in hitEnemiesHammer3.Keys)
        {
            hitEnemiesHammer3[collider].Clear();
        }   
    }

    void CheckEnemiesInBoxColliderHammer3(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesHammer3[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesHammer3[collider].Add(enemy);
            }
        }
    }
    









    private BoxCollider hammer4col;
    private int hadamage4;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesHammer4 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void hammer4()
    {
        hadamage4 = (int) (scruffystats.damage);

        Transform Slam1 =  HammerP4.transform.Find("StunCircle");
        Transform Slam2 = Slam1.Find("Collider");
        hammer4col = Slam2.GetComponent<BoxCollider>();
        
        hammer4col.enabled = false;

        if (!hitEnemiesHammer4.ContainsKey(hammer4col))
        {
            hitEnemiesHammer4.Add(hammer4col, new HashSet<Collider>()); 
        }

        if (!isAbilityHammer4CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Hammer4");
            CurrentHammer4CD = Hammer4CD;
            isAbilityHammer4CD = true;
        }
    }

    void hammer4start(){
        HammerP4.SetActive(true);
        ParticleSystem PS = HammerP4.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("hammer4hit", 0f);
        Invoke("hammer4end", 0.8f); 
    }

    void hammer4hit(){
        hammer4col.enabled = true;
        CheckEnemiesInBoxColliderHammer4(hammer4col, hadamage4);
    }

    void hammer4end(){
        HammerP4.SetActive(false); 
        MovementScript.enabled = true;
        hammer4col.enabled = false;

        foreach (var collider in hitEnemiesHammer4.Keys)
        {
            hitEnemiesHammer4[collider].Clear();
        }   
    }

    void CheckEnemiesInBoxColliderHammer4(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesHammer4[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                enemy.GetComponent<EnemyStats>().Stun();
                hitEnemiesHammer4[collider].Add(enemy);
            }
        }
    }
    







    int ArmorBoostValue;
    void hammer5()
    {
        if (!isAbilityHammer5CD)
        {
            animator.SetTrigger("Hammer5");
            CurrentHammer5CD = Hammer5CD;
            isAbilityHammer5CD = true;
        }
    }

    void hammer5start(){
        HammerP5.SetActive(true);
        ParticleSystem PS = HammerP5.GetComponentInChildren<ParticleSystem>();
        PS.Play();

        ArmorBoostValue = 5;
        scruffystats.IncreaseArmor(ArmorBoostValue);

        Invoke("hammer5end", 5.0f);
    }

    void hammer5end(){
        HammerP5.SetActive(false); 
        scruffystats.IncreaseArmorEnd(ArmorBoostValue);   
    }
    





    private BoxCollider fire1col;
    private int fidamage1;
    private int fidamage1_2;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesFire1 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void fire1()
    {
        fidamage1 = (int) (scruffystats.damage * 2);
        fidamage1_2 = (int) (scruffystats.damage * 1/5);

        Transform Fire1 =  FireP1.transform.Find("FireElement");
        Transform Fire2 = Fire1.Find("Collider");
        fire1col = Fire2.GetComponent<BoxCollider>();
        
        fire1col.enabled = false;

        if (!hitEnemiesFire1.ContainsKey(fire1col))
        {
            hitEnemiesFire1.Add(fire1col, new HashSet<Collider>()); 
        }
        if (!isAbilityFire1CD)
        {
            animator.SetTrigger("Fire1");
            CurrentFire1CD = Fire1CD;
            isAbilityFire1CD = true;
        }
    }

    private float FireparticleMoveSpeed = 2f;
    private Vector3 initialParticleDirection;
    private float attackHeight = 1f;
    private float distanceFromCharacter = 0.2f;
    public Transform characterTransform;
    private Vector3 FireinitialPosition;

    void fire1start()
    {
        FireP1.SetActive(true);

        // Store the initial position of particles with a height offset
        Vector3 originalPosition = characterTransform.position + characterTransform.forward * distanceFromCharacter + new Vector3(0, attackHeight, 0);

        // Store the initial direction of the particles
        Vector3 initialParticleDirection = characterTransform.forward;

        StartCoroutine(MoveParticle(originalPosition, initialParticleDirection));
    }

    IEnumerator MoveParticle(Vector3 originalPosition, Vector3 initialParticleDirection)
    {
        ParticleSystem PS = FireP1.GetComponentInChildren<ParticleSystem>();
        PS.Play();

        float startTime = Time.time;
        float journeyLength = 3.0f; // time

        while (Time.time - startTime < journeyLength)
        {
            float distanceCovered = (Time.time - startTime) * FireparticleMoveSpeed;
            float journeyFraction = distanceCovered / journeyLength;

            // Calculate the new position based on the initial position and the fixed initial direction
            Vector3 newPosition = originalPosition + initialParticleDirection * distanceCovered;
            FireP1.transform.position = newPosition;

            if (Time.time - startTime >= 2.0f)
            {
                fire1col.enabled = true;
                CheckEnemiesInBoxColliderFire1(fire1col, fidamage1);
            }

            yield return null;
        }


        fire1end();
    }

    void fire1end()
    {
        fire1col.enabled = false;

        foreach (var collider in hitEnemiesFire1.Keys)
        {
            hitEnemiesFire1[collider].Clear();
        }  

        FireP1.transform.position = FireinitialPosition;
    }

    void CheckEnemiesInBoxColliderFire1(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesFire1[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                if(DoubleDotDamage == true){
                    enemy.GetComponent<EnemyStats>().StartCoroutine(enemy.GetComponent<EnemyStats>().TakeDamageOverTime("fire", 2*fidamage1_2, 5f, 0.5f));
                }
                else{
                    enemy.GetComponent<EnemyStats>().StartCoroutine(enemy.GetComponent<EnemyStats>().TakeDamageOverTime("fire", fidamage1_2, 5f, 0.5f));
                }

                hitEnemiesFire1[collider].Add(enemy);
            }
        }
    }
    
    








    private BoxCollider fire2col;
    private int fidamage2;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesFire2 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void fire2()
    {
        fidamage2 = (int) (scruffystats.damage * 1/5);
        Transform Fire1 =  FireP2.transform.Find("FireCircle");
        Transform Fire2 = Fire1.Find("Collider");
        fire2col = Fire2.GetComponent<BoxCollider>();
        
        fire2col.enabled = false;

        if (!hitEnemiesFire2.ContainsKey(fire2col))
        {
            hitEnemiesFire2.Add(fire2col, new HashSet<Collider>()); 
        }

        if (!isAbilityFire2CD)
        {
            animator.SetTrigger("Fire2");
            CurrentFire2CD = Fire2CD;
            isAbilityFire2CD = true;
        }
    }

    void fire2start(){
        FireP2.SetActive(true);
        ParticleSystem PS = FireP2.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("fire2hit", 0f);
        Invoke("fire2end", 5f); 
    }

    void fire2hit(){
        fire2col.enabled = true;
        CheckEnemiesInBoxColliderFire2(fire2col, fidamage2);
    }

    void fire2end(){
        FireP2.SetActive(false); 
        MovementScript.enabled = true;
        fire2col.enabled = false;

        foreach (var collider in hitEnemiesFire2.Keys)
        {
            hitEnemiesFire2[collider].Clear();
        }   
    }

    void CheckEnemiesInBoxColliderFire2(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesFire2[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                if(DoubleDotDamage == true){
                    enemy.GetComponent<EnemyStats>().StartCoroutine(enemy.GetComponent<EnemyStats>().TakeDamageOverTime("fire", 2*damage, 5f, 0.5f));
                }
                else{
                    enemy.GetComponent<EnemyStats>().StartCoroutine(enemy.GetComponent<EnemyStats>().TakeDamageOverTime("fire", damage, 5f, 0.5f));
                }


                hitEnemiesFire2[collider].Add(enemy);
            }
        }
    }
    








    private BoxCollider fire3col;
    private int fidamage3;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesFire3 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void fire3()
    {
        fidamage3 = (int) (scruffystats.damage);
        Transform Fire1 =  FireP3.transform.Find("FireBeam");
        Transform Fire3 = Fire1.Find("Collider");
        fire3col = Fire3.GetComponent<BoxCollider>();
        
        fire3col.enabled = false;

        if (!hitEnemiesFire3.ContainsKey(fire3col))
        {
            hitEnemiesFire3.Add(fire3col, new HashSet<Collider>()); 
        }

        if (!isAbilityFire3CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Fire3");
            CurrentFire3CD = Fire3CD;
            isAbilityFire3CD = true;
        }
    }

    void fire3start(){
        FireP3.SetActive(true);
        ParticleSystem PS = FireP3.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("fire3hit", 0f);
        Invoke("fire3end", 1.7f); 
    }

    void fire3hit(){
        fire3col.enabled = true;
        CheckEnemiesInBoxColliderFire3(fire3col, fidamage3);
    }

    void fire3end(){
        FireP3.SetActive(false); 
        MovementScript.enabled = true;
        fire3col.enabled = false;

        foreach (var collider in hitEnemiesFire3.Keys)
        {
            hitEnemiesFire3[collider].Clear();
        }   
    }

    void CheckEnemiesInBoxColliderFire3(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesFire3[collider].Contains(enemy))
            {
                if(DoubleDotDamage == true){
                    enemy.GetComponent<EnemyStats>().StartCoroutine(enemy.GetComponent<EnemyStats>().TakeDamageOverTime("fire", 2*(damage*3/4), 3f, 0.5f));
                }
                else{
                    enemy.GetComponent<EnemyStats>().StartCoroutine(enemy.GetComponent<EnemyStats>().TakeDamageOverTime("fire", damage*3/4, 3f, 0.5f));
                }

                hitEnemiesFire3[collider].Add(enemy);
            }
        }
    }
    









    private BoxCollider fire4col;
    private int fidamage4;
    private int fidamage4_1;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesFire4 = new Dictionary<BoxCollider, HashSet<Collider>>();
    Transform FireExplosion;

    void fire4()
    {
        fidamage4 = (int) (scruffystats.damage * 4);
        fidamage4_1 = (int) (scruffystats.MaxHealth * 1/5);
        FireExplosion = FireP4.transform.Find("FireExplosion");
        Transform Fire1 =  FireP4.transform.Find("FireCircle");
        Transform Fire2 = Fire1.Find("Collider");
        fire4col = Fire2.GetComponent<BoxCollider>();
        
        fire4col.enabled = false;

        if (!hitEnemiesFire4.ContainsKey(fire4col))
        {
            hitEnemiesFire4.Add(fire4col, new HashSet<Collider>()); 
        }

        if (!isAbilityFire4CD)
        {
            MovementScript.enabled = false;
            animator.SetTrigger("Fire4");
            CurrentFire4CD = Fire4CD;
            isAbilityFire4CD = true;
        }
    }

    void fire4start(){
        FireP4.SetActive(true);
        ParticleSystem PS = FireP4.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("fire4hit", 0f);
        scruffystats.TakeDamage(fidamage4_1);
        Invoke("fire4end", 1f); 
    }

    void fire4hit(){
        fire4col.enabled = true;
        CheckEnemiesInBoxColliderFire4(fire4col, fidamage4);
    }

    void fire4end(){
        FireP4.SetActive(false); 
        MovementScript.enabled = true;
        fire4col.enabled = false;

        foreach (var collider in hitEnemiesFire4.Keys)
        {
            hitEnemiesFire4[collider].Clear();
        }   
    }

    void CheckEnemiesInBoxColliderFire4(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesFire4[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesFire4[collider].Add(enemy);
            }
        }
    }








    private bool DoubleDotDamage = false;
    WeaponElement weaponElementScript;

    void fire5()
    {
        weaponElementScript = GetComponent<WeaponElement>();

        if (!isAbilityFire5CD)
        {
            animator.SetTrigger("Fire5");
            CurrentFire5CD = Fire5CD;
            isAbilityFire5CD = true;
        }
    }

    void fire5start(){
        FireP5.SetActive(true);
        ParticleSystem PS = FireP5.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        weaponElementScript. DoubleDotDamage = true;
        DoubleDotDamage = true;
        StartCoroutine(scruffystats.TakeDamageOverTimeX("fire", 1, 7f, 1f));
        Invoke("fire5end", 7f); 
    }

    void fire5end(){
        FireP5.SetActive(false);  
        DoubleDotDamage = false;
        weaponElementScript. DoubleDotDamage = false;
    }
    









    private BoxCollider ice1_1col;
    private BoxCollider ice1_2col;
    private BoxCollider ice1_3col;
    private int icdamage1_1;
    private int icdamage1_2;
    private int icdamage1_3;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesIce1 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void ice1()
    {
        icdamage1_1 = (int) (scruffystats.damage * 1.6);
        icdamage1_2 = (int) (scruffystats.damage * 1.6);
        icdamage1_3 = (int) (scruffystats.damage * 1.6);

        Transform Slam1 =  IceP1.transform.Find("IceBeam");
        Transform Slam2 = Slam1.Find("Collider");
        BoxCollider[] Slam3 = Slam2.GetComponents<BoxCollider>();

        ice1_1col = Slam3[0];
        ice1_2col = Slam3[1];
        ice1_3col = Slam3[2];
        
        ice1_1col.enabled = false;
        ice1_2col.enabled = false;
        ice1_3col.enabled = false;

        if (!hitEnemiesIce1.ContainsKey(ice1_1col))
        {
            hitEnemiesIce1.Add(ice1_1col, new HashSet<Collider>()); 
        }
        if (!hitEnemiesIce1.ContainsKey(ice1_2col))
        {
            hitEnemiesIce1.Add(ice1_2col, new HashSet<Collider>()); 
        }
        if (!hitEnemiesIce1.ContainsKey(ice1_3col))
        {
            hitEnemiesIce1.Add(ice1_3col, new HashSet<Collider>()); 
        }

        if (!isAbilityIce1CD)
        {
            animator.SetTrigger("Ice1");
            CurrentIce1CD = Ice1CD;
            isAbilityIce1CD = true;
        }
    }

    void ice1start(){
        IceP1.SetActive(true);
        ParticleSystem PS = IceP1.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("ice1_1hit", 0f);
        Invoke("ice1_2hit", 1f);
        Invoke("ice1_3hit", 2f);
        Invoke("ice1end", 3f); 
    }

    void ice1_1hit(){
        ice1_1col.enabled = true;
        CheckEnemiesInBoxColliderIce1(ice1_1col, icdamage1_1);
    }
    void ice1_2hit(){
        ice1_2col.enabled = true;
        CheckEnemiesInBoxColliderIce1(ice1_2col, icdamage1_2);
    }
    void ice1_3hit(){
        ice1_3col.enabled = true;
        CheckEnemiesInBoxColliderIce1(ice1_3col, icdamage1_3);
    }

    void ice1end(){
        IceP1.SetActive(false); 
        ice1_1col.enabled = false;
        ice1_2col.enabled = false;
        ice1_3col.enabled = false;

        foreach (var collider in hitEnemiesIce1.Keys)
        {
            hitEnemiesIce1[collider].Clear();
        }   
    }

    
    void CheckEnemiesInBoxColliderIce1(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesIce1[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesIce1[collider].Add(enemy);
            }
        }
    }
    








    int HealthShieldValue;
    void ice2()
    {
        if (!isAbilityIce2CD)
        {
            animator.SetTrigger("Ice2");
            CurrentIce2CD = Ice2CD;
            isAbilityIce2CD = true;
        }
    }

    void ice2start(){
        IceP2.SetActive(true);
        ParticleSystem PS = IceP2.GetComponentInChildren<ParticleSystem>();
        PS.Play();

        HealthShieldValue = scruffystats.MaxHealth * 1/2;
        scruffystats.TempMaxHPIncrease(HealthShieldValue);

        Invoke("ice2end", 8.0f);
    }

    void ice2end(){
        IceP2.SetActive(false);
        scruffystats.TempMaxHPDecrease(HealthShieldValue);   
    }
    







    private BoxCollider ice3col;
    private int icdamage3;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesIce3 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void ice3()
    {
        icdamage3 = (int) (scruffystats.damage * 3/4);
        Transform ice1x =  IceP3.transform.Find("SlowCircle");
        Transform ice2x = ice1x.Find("Collider");
        ice3col = ice2x.GetComponent<BoxCollider>();
        
        ice3col.enabled = false;

        if (!hitEnemiesIce3.ContainsKey(ice3col))
        {
            hitEnemiesIce3.Add(ice3col, new HashSet<Collider>()); 
        }

        if (!isAbilityIce3CD)
        {
            animator.SetTrigger("Ice3");
            CurrentIce3CD = Ice3CD;
            isAbilityIce3CD = true;
        }
    }

    void ice3start(){
        IceP3.SetActive(true);
        ParticleSystem PS = IceP3.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("ice3hit", 0f);
        Invoke("ice3end", 4.5f); 
    }

    void ice3hit(){
        ice3col.enabled = true;
        CheckEnemiesInBoxColliderIce3(ice3col, icdamage3);
    }

    void ice3end(){
        IceP3.SetActive(false); 
        ice3col.enabled = false;

        foreach (var collider in hitEnemiesIce3.Keys)
        {
            hitEnemiesIce3[collider].Clear();
        }   
    }

    void CheckEnemiesInBoxColliderIce3(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesIce3[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().StartCoroutine(enemy.GetComponent<EnemyStats>().TakeDamageOverTime("ice", damage, 4f, 1f));
                hitEnemiesIce3[collider].Add(enemy);
            }
        }
    }
    










    void ice4()
    {
        if (!isAbilityIce4CD)
        {
            animator.SetTrigger("Ice4");
            CurrentIce4CD = Ice4CD;
            isAbilityIce4CD = true;
        }
    }

    void ice4start(){
        IceP4.SetActive(true);
        ParticleSystem PS = IceP4.GetComponentInChildren<ParticleSystem>();
        PS.Play();

        int HealOvertime = (int) (scruffystats.MaxHealth * 1/8);
        float duration = 5f;
        float tickspeed = 1f;

        scruffystats.HealOverTimeX(HealOvertime, duration, tickspeed);

        Invoke("ice4end", 5.0f);

    }

    void ice4end(){
        IceP4.SetActive(false);
    }
    









    private BoxCollider ice5col;
    private int icdamage5;
    private Dictionary<BoxCollider, HashSet<Collider>> hitEnemiesIce5 = new Dictionary<BoxCollider, HashSet<Collider>>();

    void ice5()
    {
        icdamage5 = (int) (scruffystats.damage);
        Transform ice1x =  IceP5.transform.Find("Sparks");
        Transform ice2x = ice1x.Find("Collider");
        ice5col = ice2x.GetComponent<BoxCollider>();
        
        ice5col.enabled = false;

        if (!hitEnemiesIce5.ContainsKey(ice5col))
        {
            hitEnemiesIce5.Add(ice5col, new HashSet<Collider>()); 
        }

        if (!isAbilityIce5CD)
        {
            animator.SetTrigger("Ice5");
            CurrentIce5CD = Ice5CD;
            isAbilityIce5CD = true;
        }
    }

    void ice5start(){
        IceP5.SetActive(true);
        ParticleSystem PS = IceP5.GetComponentInChildren<ParticleSystem>();
        PS.Play();
        Invoke("ice5hit", 0f);
        Invoke("ice5end", 4.5f); 
    }

    void ice5hit(){
        ice5col.enabled = true;
        CheckEnemiesInBoxColliderIce5(ice5col, icdamage5);
    }

    void ice5end(){
        IceP5.SetActive(false); 
        ice5col.enabled = false;

        foreach (var collider in hitEnemiesIce5.Keys)
        {
            hitEnemiesIce5[collider].Clear();
        }   
    }

    void CheckEnemiesInBoxColliderIce5(BoxCollider collider, int damage)
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, collider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider enemy in hitColliders)
        {
            if (enemy.CompareTag("Enemy") && !hitEnemiesIce5[collider].Contains(enemy))
            {
                enemy.GetComponent<EnemyStats>().TakeDamage(damage);
                hitEnemiesIce5[collider].Add(enemy);
            }
        }
    }
    


    









    void lightning1()
    {
        if (!isAbilityLightning1CD)
        {
            animator.SetTrigger("Lightning1");
            CurrentLightning1CD = Lightning1CD;
            isAbilityLightning1CD = true;
        }
    }

    void lightning1start(){
        LightningP1.SetActive(true);
        ParticleSystem PS = LightningP1.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void lightning1end(){
        LightningP1.SetActive(false);  
    }
    









    void lightning2()
    {
        if (!isAbilityLightning2CD)
        {
            animator.SetTrigger("Lightning2");
            CurrentLightning2CD = Lightning2CD;
            isAbilityLightning2CD = true;
        }
    }

    void lightning2start(){
        LightningP2.SetActive(true);
        ParticleSystem PS = LightningP2.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void lightning2end(){
        LightningP2.SetActive(false);  
    }










    void lightning3()
    {
        if (!isAbilityLightning3CD)
        {
            animator.SetTrigger("Lightning3");
            CurrentLightning3CD = Lightning3CD;
            isAbilityLightning3CD = true;
        }
    }

    void lightning3start(){
        LightningP3.SetActive(true);
        ParticleSystem PS = LightningP3.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void lightning3end(){
        LightningP3.SetActive(false);  
    }
    









    void lightning4()
    {
        if (!isAbilityLightning4CD)
        {
            animator.SetTrigger("Lightning4");
            CurrentLightning4CD = Lightning4CD;
            isAbilityLightning4CD = true;
        }
    }

    void lightning4start(){
        LightningP4.SetActive(true);
        ParticleSystem PS = LightningP4.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void lightning4end(){
        LightningP4.SetActive(false);  
    }
    









    void lightning5()
    {
        if (!isAbilityLightning5CD)
        {
            animator.SetTrigger("Lightning5");
            CurrentLightning5CD = Lightning5CD;
            isAbilityLightning5CD = true;
        }
    }

    void lightning5start(){
        LightningP5.SetActive(true);
        ParticleSystem PS = LightningP5.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void lightning5end(){
        LightningP5.SetActive(false);  
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
