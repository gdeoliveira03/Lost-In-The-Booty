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

    // FOR BASIC ATTACK ANIMATIONS
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        
        
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

    void Update()
    {

        animator = GetComponent<Animator>();

        
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

    }




    // BASIC ATTACK ABILITY CALLS
    void CutlassBasicAttack(){

        animator.SetTrigger("CutlassBasicAttack");
        Debug.Log("Sword Basic Attack");

    }
    void SpearBasicAttack(){
        animator.SetTrigger("SpearBasicAttack");
        Debug.Log("Spear Basic Attack");

    }
    void HammerBasicAttack(){
        animator.SetTrigger("HammerBasicAttack");
        Debug.Log("Hammer Basic Attack");

    }
    void FireBasicAttack(){
        animator.SetTrigger("FireBasicAttack");
        Debug.Log("Fire Basic Attack");

    }
    void IceBasicAttack(){
        animator.SetTrigger("IceBasicAttack");
        Debug.Log("Ice Basic Attack");

    }
    void LightningBasicAttack(){
        animator.SetTrigger("LightningBasicAttack");
        Debug.Log("Lightning Basic Attack");

    }

}
