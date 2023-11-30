using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBook : MonoBehaviour
{
    public GameObject AbilityUI;
    public GameObject InventoryUI;
    public GameObject WorldMapUI;
    public GameObject StatsUI;
    public GameObject PauseMenu;
    public KeyCode keybind = KeyCode.B;

    void Start()
    {
        PauseMenu = transform.Find("PauseMenu").gameObject;
        AbilityUI = transform.Find("AbilityPageUI").gameObject;
        InventoryUI = transform.Find("InventoryPageUI").gameObject;
        WorldMapUI = transform.Find("MapUI").gameObject;
        StatsUI = transform.Find("StatsPageUI").gameObject;
    }

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
            if (!InventoryUI.activeSelf && !WorldMapUI.activeSelf && !StatsUI.activeSelf)
            {
                open();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.activeSelf)
        {
            close();
        }
    }
}
