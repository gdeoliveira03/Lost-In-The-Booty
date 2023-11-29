using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBook : MonoBehaviour
{
    public GameObject AbilityUI;
    public GameObject PauseMenu;
    public KeyCode keybind = KeyCode.B;

    // Start is called before the first frame update
    public void open(){
        Time.timeScale = 0f;
        AbilityUI.SetActive(true);
    }

    public void close(){
        Time.timeScale = 1f;
        AbilityUI.SetActive(false);
    }

    void Update () 
    {
        // Check for keybind input and if not open
        if (Input.GetKeyDown(keybind))
        {
            open();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.activeSelf)
        {
            close();
        }
    }
}
