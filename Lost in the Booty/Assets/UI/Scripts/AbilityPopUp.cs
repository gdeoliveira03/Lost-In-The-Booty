using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPopUp : MonoBehaviour
{
    public GameObject PopUp;
    public GameObject ChosenAbility;
    public GameObject AbilityBook;

    public void openPopup(){
        ChosenAbility.SetActive(true);
        PopUp.SetActive(true);
        AbilityBook.SetActive(false);
    }

    public void closePopup(){
        ChosenAbility.SetActive(false);
        PopUp.SetActive(false);
        AbilityBook.SetActive(true);
    }


    void Update () {
    }


}
