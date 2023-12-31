using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject AbilityUI;
    public GameObject InventoryUI;
    public GameObject WorldMapUI;
    public GameObject StatsUI;
    public GameObject PauseMenu;
    public KeyCode keybind = KeyCode.I;

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
        Debug.Log("Opening inventory");
        Time.timeScale = 0f;
        InventoryUI.SetActive(true);
    }

    public void close()
    {
        Time.timeScale = 1f;
        InventoryUI.SetActive(false);
    }

    void Update()
    {
        // Check for keybind input
        if (Input.GetKeyDown(keybind))
        {
            if (!AbilityUI.activeSelf && !WorldMapUI.activeSelf && !StatsUI.activeSelf)
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