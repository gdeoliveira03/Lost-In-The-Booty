using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public GameObject StatsUI;
    public GameObject PauseMenu;
    public KeyCode keybind = KeyCode.C;

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
            open();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.activeSelf)
        {
            close();
        }
    }
}
