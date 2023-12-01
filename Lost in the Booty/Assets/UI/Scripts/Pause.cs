using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject GameUI;
    public GameObject OptionsUI;
    public GameObject VideoOptionsUI;
    public GameObject AudioOptionsUI;
    public GameObject AbilityUI;
    public GameObject InventoryUI;
    public GameObject WorldMapUI;
    public GameObject StatsUI;

    void Start()
    {
        Time.timeScale = 1f;
        PauseMenu = transform.Find("PauseMenu").gameObject;
        GameUI = transform.Find("GameUI").gameObject;
        OptionsUI = transform.Find("OptionsPage").gameObject;
        VideoOptionsUI = transform.Find("OptionsPage").transform.Find("VideoOptions").gameObject;
        AudioOptionsUI = transform.Find("OptionsPage").transform.Find("AudioOptions").gameObject;
        AbilityUI = transform.Find("AbilityPageUI").gameObject;
        InventoryUI = transform.Find("InventoryUI").gameObject;
        WorldMapUI = transform.Find("MapUI").gameObject;
        StatsUI = transform.Find("StatsPageUI").gameObject;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        GameUI.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        GameUI.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void OptionsMenu()
    {
        OptionsUI.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        OptionsUI.SetActive(false);
    }

    public void VideoOptions()
    {
        VideoOptionsUI.SetActive(true);
        AudioOptionsUI.SetActive(false);
    }

    public void AudioOptions()
    {
        VideoOptionsUI.SetActive(false);
        AudioOptionsUI.SetActive(true);
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = true;
    }

    public void SetWindowed()
    {
        Screen.fullScreen = false;
    }

    public void SetBorderless()
    {
        Screen.fullScreen = false;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.Windowed);
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        Application.Quit();
    }

    void Update () 
    {
        // Pauses in-game time while in menus
        if (PauseMenu.activeSelf || OptionsUI.activeSelf)
        {
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && (AbilityUI.activeSelf   || 
                                                 InventoryUI.activeSelf || 
                                                 WorldMapUI.activeSelf  ||
                                                 StatsUI.activeSelf))
        {
            // Do nothing to close any of those menus that were open
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OptionsUI.activeSelf) { CloseOptionsMenu(); } // Exit options menu
            else if (PauseMenu.activeSelf) { UnpauseGame(); } // Unpause
            else { PauseGame(); } // None open; pause
        }
    }
}