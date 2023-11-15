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

    void Start(){
        animator = GetComponent<Animator>();
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

    //Individual Ability Actions Begin Here, these define what each skill does.
    void sword1()
    {
        if (!isAbilitySword1CD)
        {
            animator.SetTrigger("Sword1");
            CurrentSword1CD = Sword1CD;
            isAbilitySword1CD = true;
        }
    }

    void sword1start(){
        SwordP1.SetActive(true);
        ParticleSystem PS = SwordP1.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void sword1end(){
        SwordP1.SetActive(false);
    }

    void sword2()
    {
        if (!isAbilitySword2CD)
        {
            animator.SetTrigger("Sword2");
            CurrentSword2CD = Sword2CD;
            isAbilitySword2CD = true;
        }
    }

    void sword2start(){
        SwordP2.SetActive(true);
        ParticleSystem PS = SwordP2.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void sword2end(){
        SwordP2.SetActive(false);
    }

    void sword3()
    {
        if (!isAbilitySword3CD)
        {
            animator.SetTrigger("Sword3");
            CurrentSword3CD = Sword3CD;
            isAbilitySword3CD = true;
        }
    }

    void sword3start(){
        SwordP3.SetActive(true);
        ParticleSystem PS = SwordP3.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void sword3end(){
        SwordP3.SetActive(false);        
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
    }

    void sword4end(){
        SwordP4.SetActive(false);       
    }

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
    }

    void sword5end(){
        SwordP5.SetActive(false);        
    }

    void spear1()
    {
        if (!isAbilitySpear1CD)
        {
            animator.SetTrigger("Spear1");
            CurrentSpear1CD = Spear1CD;
            isAbilitySpear1CD = true;
        }
    }

    void spear1start(){
        SpearP1.SetActive(true);
        ParticleSystem PS = SpearP1.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void spear1end(){
        SpearP1.SetActive(false);    
    }

    void spear2()
    {
        if (!isAbilitySpear2CD)
        {
            animator.SetTrigger("Spear2");
            CurrentSpear2CD = Spear2CD;
            isAbilitySpear2CD = true;
        }
    }

    void spear2start(){
        SpearP2.SetActive(true);
        ParticleSystem PS = SpearP2.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void spear2end(){
        SpearP2.SetActive(false);    
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

    void spear4()
    {
        if (!isAbilitySpear4CD)
        {
            animator.SetTrigger("Spear4");
            CurrentSpear4CD = Spear4CD;
            isAbilitySpear4CD = true;
        }
    }

    void spear4start(){
        SpearP4.SetActive(true);
        ParticleSystem PS = SpearP4.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void spear4end(){
        SpearP4.SetActive(false);    
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

    void hammer1()
    {
        if (!isAbilityHammer1CD)
        {
            animator.SetTrigger("Hammer1");
            CurrentHammer1CD = Hammer1CD;
            isAbilityHammer1CD = true;
        }
    }

    void hammer1start(){
        HammerP1.SetActive(true);
        ParticleSystem PS = HammerP1.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void hammer1end(){
        HammerP1.SetActive(false);    
    }

    void hammer2()
    {
        if (!isAbilityHammer2CD)
        {
            animator.SetTrigger("Hammer2");
            CurrentHammer2CD = Hammer2CD;
            isAbilityHammer2CD = true;
        }
    }

    void hammer2start(){
        HammerP2.SetActive(true);
        ParticleSystem PS = HammerP2.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void hammer2end(){
        HammerP2.SetActive(false);    
    }

    void hammer3()
    {
        if (!isAbilityHammer3CD)
        {
            animator.SetTrigger("Hammer3");
            CurrentHammer3CD = Hammer3CD;
            isAbilityHammer3CD = true;
        }
    }

    void hammer3start(){
        HammerP3.SetActive(true);
        ParticleSystem PS = HammerP3.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void hammer3end(){
        HammerP3.SetActive(false);    
    }

    void hammer4()
    {
        if (!isAbilityHammer4CD)
        {
            animator.SetTrigger("Hammer4");
            CurrentHammer4CD = Hammer4CD;
            isAbilityHammer4CD = true;
        }
    }

    void hammer4start(){
        HammerP4.SetActive(true);
        ParticleSystem PS = HammerP4.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void hammer4end(){
        HammerP4.SetActive(false);    
    }

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
    }

    void hammer5end(){
        HammerP5.SetActive(false);    
    }

    void fire1()
    {
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

            yield return null; // Wait for the next frame
        }

        fire1end();
    }

    void fire1end()
    {
        FireP1.transform.position = FireinitialPosition;
    }


    void fire2()
    {
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
    }

    void fire2end(){
        FireP2.SetActive(false);  
    }

    void fire3()
    {
        if (!isAbilityFire3CD)
        {
            animator.SetTrigger("Fire3");
            CurrentFire3CD = Fire3CD;
            isAbilityFire3CD = true;
        }
    }

    void fire3start(){
        FireP3.SetActive(true);
        ParticleSystem PS = FireP3.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void fire3end(){
        FireP3.SetActive(false);  
    }

    void fire4()
    {
        if (!isAbilityFire4CD)
        {
            animator.SetTrigger("Fire4");
            CurrentFire4CD = Fire4CD;
            isAbilityFire4CD = true;
        }
    }

    void fire4start(){
        FireP4.SetActive(true);
        ParticleSystem PS = FireP4.GetComponentInChildren<ParticleSystem>();
        PS.Play();
    }

    void fire4end(){
        FireP4.SetActive(false);  
    }

    void fire5()
    {
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
    }

    void fire5end(){
        FireP5.SetActive(false);  
    }

    void ice1()
    {
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
    }

    void ice1end(){
        IceP1.SetActive(false);
    }

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
    }

    void ice2end(){
        IceP2.SetActive(false);
    }

    void ice3()
    {
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
    }

    void ice3end(){
        IceP3.SetActive(false);
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
    }

    void ice4end(){
        IceP4.SetActive(false);
    }

    void ice5()
    {
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
    }

    void ice5end(){
        IceP5.SetActive(false);
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
