using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{
    public GameObject AbilityUI;
    public GameObject InventoryUI;
    public GameObject WorldMapUI;
    public GameObject StatsUI;
    public GameObject PauseMenu;
    public KeyCode keybind = KeyCode.M;

    void Start()
    {
        PauseMenu = transform.Find("PauseMenu").gameObject;
        AbilityUI = transform.Find("AbilityPageUI").gameObject;
        InventoryUI = transform.Find("InventoryPageUI").gameObject;
        WorldMapUI = transform.Find("MapUI").gameObject;
        StatsUI = transform.Find("StatsPageUI").gameObject;
    }

    // Start is called before the first frame update
    public void open()
    {
        Time.timeScale = 0f;
        WorldMapUI.SetActive(true);
    }

    public void close()
    {
        Time.timeScale = 1f;
        WorldMapUI.SetActive(false);
    }

    void Update()
    {
        // Check for keybind input
        if (Input.GetKeyDown(keybind))
        {
            if (!InventoryUI.activeSelf && !AbilityUI.activeSelf && !StatsUI.activeSelf)
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