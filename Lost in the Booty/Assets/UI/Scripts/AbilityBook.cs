using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBook : MonoBehaviour
{
    public GameObject AbilityUI;

    // Start is called before the first frame update
    public void openBook(){
        Time.timeScale = 0f;
        AbilityUI.SetActive(true);
    }

    public void closeBook(){
        Time.timeScale = 1f;
        AbilityUI.SetActive(false);
    }

    void Update () {
    }
}
