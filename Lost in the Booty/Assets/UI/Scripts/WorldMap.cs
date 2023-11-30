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