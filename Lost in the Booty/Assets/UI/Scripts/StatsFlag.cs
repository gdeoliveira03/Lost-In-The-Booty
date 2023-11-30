using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public GameObject AbilityUI;
    public GameObject InventoryUI;
    public GameObject WorldMapUI;
    public GameObject StatsUI;
    public GameObject PauseMenu;
    public KeyCode keybind = KeyCode.C;

    void Start()
    {
        Transform parentTransform = transform.parent.transform.parent;
        PauseMenu = parentTransform.Find("PauseMenu").gameObject;
        AbilityUI = parentTransform.Find("AbilityPageUI").gameObject;
        InventoryUI = parentTransform.Find("InventoryUI").gameObject;
        WorldMapUI = parentTransform.Find("MapUI").gameObject;
        StatsUI = parentTransform.Find("StatsPageUI").gameObject;
    }

    // Start is called before the first frame update
    public void open()
    {
        Time.timeScale = 0f;
        StatsUI.SetActive(true);
    }

    public void close()
    {
        Time.timeScale = 1f;
        StatsUI.SetActive(false);
    }

    void Update()
    {
        // Check for keybind input
        if (Input.GetKeyDown(keybind))
        {
            if (!InventoryUI.activeSelf && !WorldMapUI.activeSelf && !AbilityUI.activeSelf)
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