using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillList : MonoBehaviour
{
    [SerializeField]
    private Image ImageComponent;

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

    private Sprite CurrentSkill;
    public int CurrentSkillSlot;

    void Update(){

        if (ImageComponent != null){ // When the Image Is not null it makes the Current Image = Current Skill
            CurrentSkill = ImageComponent.sprite;
        }

        if (CurrentSkill != null){ //Just to make sure nothing happens if the Current Skill is NULL
    
            if (ReferenceEquals(CurrentSkill, Sword1)){ // If the current skill is equal to the image of Sword1
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        sword1();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Sword2)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        sword2();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Sword3)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        sword3();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Sword4)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        sword4();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Sword5)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        sword5();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Spear1)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        spear1();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Spear2)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        spear2();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Spear3)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        spear3();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Spear4)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        spear4();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Spear5)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        spear5();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Hammer1)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        hammer1();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Hammer2)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        hammer2();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Hammer3)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        hammer3();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Hammer4)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        hammer4();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Hammer5)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        hammer5();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Fire1)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        fire1();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Fire2)){ 
            for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        fire2();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Fire3)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        fire3();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Fire4)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        fire4();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Fire5)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        fire5();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Ice1)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        ice1();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Ice2)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        ice2();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Ice3)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        ice3();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Ice4)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        ice4();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Ice5)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        ice5();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Lightning1)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        lightning1();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Lightning2)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        lightning2();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Lightning3)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        lightning3();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Lightning4)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        lightning4();
                    }
                }
            }
            else if (ReferenceEquals(CurrentSkill, Lightning5)){ 
                for (int j = 1; j <= 5 ; j++){
                    if (CurrentSkillSlot == j && Input.GetKeyDown(KeyCode.Alpha1 + j - 1)){
                        lightning5();
                    }
                }
            }
        }
    }

    //Individual Ability Actions Begin Here, these define what each skill does.
    void sword1(){
        Debug.Log("Sword1 Has been activated!");
    }
    void sword2(){
        Debug.Log("Sword2 Has been activated!");
    }
    void sword3(){
        Debug.Log("Sword3 Has been activated!");
    }
    void sword4(){
        Debug.Log("Sword4 Has been activated!");
    }
    void sword5(){
        Debug.Log("Sword5 Has been activated!");
    }
    void spear1(){
        Debug.Log("spear1 Has been activated!");
    }
    void spear2(){
        Debug.Log("spear2 Has been activated!");
    }
    void spear3(){
        Debug.Log("spear3 Has been activated!");
    }
    void spear4(){
        Debug.Log("spear4 Has been activated!");
    }
    void spear5(){
        Debug.Log("spear5 Has been activated!");
    }
    void hammer1(){
        Debug.Log("hammer1 Has been activated!");
    }
    void hammer2(){
        Debug.Log("hammer2 Has been activated!");
    }
    void hammer3(){
        Debug.Log("hammer3 Has been activated!");
    }
    void hammer4(){
        Debug.Log("hammer4 Has been activated!");
    }
    void hammer5(){
        Debug.Log("hammer5 Has been activated!");
    }
    void fire1(){
        Debug.Log("fire1 Has been activated!");
    }
    void fire2(){
        Debug.Log("fire2 Has been activated!");
    }
    void fire3(){
        Debug.Log("fire3 Has been activated!");
    }
    void fire4(){
        Debug.Log("fire4 Has been activated!");
    }
    void fire5(){
        Debug.Log("fire5 Has been activated!");
    }
    void ice1(){
        Debug.Log("ice1 Has been activated!");
    }
    void ice2(){
        Debug.Log("ice2 Has been activated!");
    }
    void ice3(){
        Debug.Log("ice3 Has been activated!");
    }
    void ice4(){
        Debug.Log("ice4 Has been activated!");
    }
    void ice5(){
        Debug.Log("ice5 Has been activated!");
    }
    void lightning1(){
        Debug.Log("lightning1 Has been activated!");
    }
    void lightning2(){
        Debug.Log("lightning2 Has been activated!");
    }
    void lightning3(){
        Debug.Log("lightning3 Has been activated!");
    }
    void lightning4(){
        Debug.Log("lightning4 Has been activated!");
    }
    void lightning5(){
        Debug.Log("lightning5 Has been activated!");
    }


















}
