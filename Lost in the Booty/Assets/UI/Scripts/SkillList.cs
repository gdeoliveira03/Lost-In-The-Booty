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

    // Cooldown times for abilities
    private float Sword1CD = 1f;
    private float Sword2CD = 1f;
    private float Sword3CD = 1f;
    private float Sword4CD = 1f;
    private float Sword5CD = 1f;

    private float Spear1CD = 1f;
    private float Spear2CD = 1f;
    private float Spear3CD = 1f;
    private float Spear4CD = 1f;
    private float Spear5CD = 1f;

    private float Hammer1CD = 1f;
    private float Hammer2CD = 1f;
    private float Hammer3CD = 1f;
    private float Hammer4CD = 1f;
    private float Hammer5CD = 1f;

    private float Fire1CD = 1f;
    private float Fire2CD = 1f;
    private float Fire3CD = 1f;
    private float Fire4CD = 1f;
    private float Fire5CD = 1f;
    
    private float Ice1CD = 1f;
    private float Ice2CD = 1f;
    private float Ice3CD = 1f;
    private float Ice4CD = 1f;
    private float Ice5CD = 1f;

    private float Lightning1CD = 1f;
    private float Lightning2CD = 1f;
    private float Lightning3CD = 1f;
    private float Lightning4CD = 1f;
    private float Lightning5CD = 1f;

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
            // Your activation code for Sword1 here
            animator.SetTrigger("Sword1");

            Debug.Log("Sword1 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSword1CD = Sword1CD;
            isAbilitySword1CD = true;
        }
    }

    void sword2()
    {
        if (!isAbilitySword2CD)
        {
            // Your activation code for Sword2 here
            animator.SetTrigger("Sword2");

            Debug.Log("Sword2 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSword2CD = Sword2CD;
            isAbilitySword2CD = true;
        }
    }

    void sword3()
    {
        if (!isAbilitySword3CD)
        {
            // Your activation code for Sword3 here
            animator.SetTrigger("Sword3");

            Debug.Log("Sword3 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSword3CD = Sword3CD;
            isAbilitySword3CD = true;
        }
    }

    void sword4()
    {
        if (!isAbilitySword4CD)
        {
            // Your activation code for Sword4 here
            animator.SetTrigger("Sword4");

            Debug.Log("Sword4 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSword4CD = Sword4CD;
            isAbilitySword4CD = true;
        }
    }

    void sword5()
    {
        if (!isAbilitySword5CD)
        {
            // Your activation code for Sword5 here

            Debug.Log("Sword5 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSword5CD = Sword5CD;
            isAbilitySword5CD = true;
        }
    }

    void spear1()
    {
        if (!isAbilitySpear1CD)
        {
            // Your activation code for Spear1 here
            animator.SetTrigger("Spear1");

            Debug.Log("Spear1 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSpear1CD = Spear1CD;
            isAbilitySpear1CD = true;
        }
    }

    void spear2()
    {
        if (!isAbilitySpear2CD)
        {
            // Your activation code for Spear2 here
            animator.SetTrigger("Spear2");

            Debug.Log("Spear2 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSpear2CD = Spear2CD;
            isAbilitySpear2CD = true;
        }
    }

    void spear3()
    {
        if (!isAbilitySpear3CD)
        {
            // Your activation code for Spear3 here
            animator.SetTrigger("Spear3");

            Debug.Log("Spear3 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSpear3CD = Spear3CD;
            isAbilitySpear3CD = true;
        }
    }

    void spear4()
    {
        if (!isAbilitySpear4CD)
        {
            // Your activation code for Spear4 here
            animator.SetTrigger("Spear4");

            Debug.Log("Spear4 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSpear4CD = Spear4CD;
            isAbilitySpear4CD = true;
        }
    }

    void spear5()
    {
        if (!isAbilitySpear5CD)
        {
            // Your activation code for Spear5 here
            animator.SetTrigger("Spear5");

            Debug.Log("Spear5 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentSpear5CD = Spear5CD;
            isAbilitySpear5CD = true;
        }
    }

    void hammer1()
    {
        if (!isAbilityHammer1CD)
        {
            // Your activation code for Hammer1 here
            animator.SetTrigger("Hammer1");

            Debug.Log("Hammer1 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentHammer1CD = Hammer1CD;
            isAbilityHammer1CD = true;
        }
    }

    void hammer2()
    {
        if (!isAbilityHammer2CD)
        {
            // Your activation code for Hammer2 here
            animator.SetTrigger("Hammer2");

            Debug.Log("Hammer2 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentHammer2CD = Hammer2CD;
            isAbilityHammer2CD = true;
        }
    }

    void hammer3()
    {
        if (!isAbilityHammer3CD)
        {
            // Your activation code for Hammer3 here
            animator.SetTrigger("Hammer3");

            Debug.Log("Hammer3 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentHammer3CD = Hammer3CD;
            isAbilityHammer3CD = true;
        }
    }

    void hammer4()
    {
        if (!isAbilityHammer4CD)
        {
            // Your activation code for Hammer4 here
            animator.SetTrigger("Hammer4");

            Debug.Log("Hammer4 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentHammer4CD = Hammer4CD;
            isAbilityHammer4CD = true;
        }
    }

    void hammer5()
    {
        if (!isAbilityHammer5CD)
        {
            // Your activation code for Hammer5 here
            animator.SetTrigger("Hammer5");

            Debug.Log("Hammer5 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentHammer5CD = Hammer5CD;
            isAbilityHammer5CD = true;
        }
    }

    void fire1()
    {
        if (!isAbilityFire1CD)
        {
            // Your activation code for Fire1 here
            animator.SetTrigger("Fire1");

            Debug.Log("Fire1 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentFire1CD = Fire1CD;
            isAbilityFire1CD = true;
        }
    }

    void fire2()
    {
        if (!isAbilityFire2CD)
        {
            // Your activation code for Fire2 here
            animator.SetTrigger("Fire2");

            Debug.Log("Fire2 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentFire2CD = Fire2CD;
            isAbilityFire2CD = true;
        }
    }

    void fire3()
    {
        if (!isAbilityFire3CD)
        {
            // Your activation code for Fire3 here
            animator.SetTrigger("Fire3");

            Debug.Log("Fire3 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentFire3CD = Fire3CD;
            isAbilityFire3CD = true;
        }
    }

    void fire4()
    {
        if (!isAbilityFire4CD)
        {
            // Your activation code for Fire4 here
            animator.SetTrigger("Fire4");

            Debug.Log("Fire4 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentFire4CD = Fire4CD;
            isAbilityFire4CD = true;
        }
    }

    void fire5()
    {
        if (!isAbilityFire5CD)
        {
            // Your activation code for Fire5 here
            animator.SetTrigger("Fire5");

            Debug.Log("Fire5 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentFire5CD = Fire5CD;
            isAbilityFire5CD = true;
        }
    }

    void ice1()
    {
        if (!isAbilityIce1CD)
        {
            // Your activation code for Ice1 here
            animator.SetTrigger("Ice1");

            Debug.Log("Ice1 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentIce1CD = Ice1CD;
            isAbilityIce1CD = true;
        }
    }

    void ice2()
    {
        if (!isAbilityIce2CD)
        {
            // Your activation code for Ice2 here
            animator.SetTrigger("Ice2");

            Debug.Log("Ice2 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentIce2CD = Ice2CD;
            isAbilityIce2CD = true;
        }
    }

    void ice3()
    {
        if (!isAbilityIce3CD)
        {
            // Your activation code for Ice3 here
            animator.SetTrigger("Ice3");

            Debug.Log("Ice3 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentIce3CD = Ice3CD;
            isAbilityIce3CD = true;
        }
    }

    void ice4()
    {
        if (!isAbilityIce4CD)
        {
            // Your activation code for Ice4 here
            animator.SetTrigger("Ice4");

            Debug.Log("Ice4 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentIce4CD = Ice4CD;
            isAbilityIce4CD = true;
        }
    }

    void ice5()
    {
        if (!isAbilityIce5CD)
        {
            // Your activation code for Ice5 here
            animator.SetTrigger("Ice5");

            Debug.Log("Ice5 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentIce5CD = Ice5CD;
            isAbilityIce5CD = true;
        }
    }

    void lightning1()
    {
        if (!isAbilityLightning1CD)
        {
            // Your activation code for Lightning1 here
            animator.SetTrigger("Lightning1");

            Debug.Log("Lightning1 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentLightning1CD = Lightning1CD;
            isAbilityLightning1CD = true;
        }
    }

    void lightning2()
    {
        if (!isAbilityLightning2CD)
        {
            // Your activation code for Lightning2 here
            animator.SetTrigger("Lightning2");

            Debug.Log("Lightning2 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentLightning2CD = Lightning2CD;
            isAbilityLightning2CD = true;
        }
    }

    void lightning3()
    {
        if (!isAbilityLightning3CD)
        {
            // Your activation code for Lightning3 here

            Debug.Log("Lightning3 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentLightning3CD = Lightning3CD;
            isAbilityLightning3CD = true;
        }
    }

    void lightning4()
    {
        if (!isAbilityLightning4CD)
        {
            // Your activation code for Lightning4 here
            animator.SetTrigger("Lightning4");

            Debug.Log("Lightning4 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentLightning4CD = Lightning4CD;
            isAbilityLightning4CD = true;
        }
    }

    void lightning5()
    {
        if (!isAbilityLightning5CD)
        {
            // Your activation code for Lightning5 here
            animator.SetTrigger("Lightning5");

            Debug.Log("Lightning5 Has been activated!");

            // Set the cooldown and update the cooldown flag
            CurrentLightning5CD = Lightning5CD;
            isAbilityLightning5CD = true;
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
