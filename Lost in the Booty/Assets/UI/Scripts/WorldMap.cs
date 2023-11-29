using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{
    public GameObject WorldMapUI;
    public GameObject PauseMenu;
    public KeyCode keybind = KeyCode.M;

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
            open();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.activeSelf)
        {
            close();
        }
    }
}
