using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject GameUI;
    public GameObject OptionsPage;
    public GameObject VideoOptions;
    public GameObject AudioOptions;
    bool esc = false;

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        GameUI.SetActive(true);
        pausemenu.SetActive(false);
        esc = false;
    }


    public void OptionsMenu(){
        OptionsPage.SetActive(true);
    }

    public void CloseOptionsMenu(){
        OptionsPage.SetActive(false);
    }

    public void Videooptions(){
        VideoOptions.SetActive(true);
        AudioOptions.SetActive(false);
    }

    public void Audiooptions(){
        VideoOptions.SetActive(false);
        AudioOptions.SetActive(true);
    }




    public void SetFullScreen(){
        Screen.fullScreen = true;
    }

    public void SetWindowed(){
        Screen.fullScreen = false;
    }

    public void SetBorderless(){
        Screen.fullScreen = false;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.Windowed);
    }





    public void QuitGame(){
        Application.Quit();
    }

    void Update () {
        if (pausemenu.activeSelf || OptionsPage.activeSelf){
            Time.timeScale = 0f;
        }
        if(OptionsPage.activeSelf){
            if (Input.GetKeyDown(KeyCode.Escape) == true && esc == true){
                CloseOptionsMenu();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) == true && esc == true){
            UnpauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) == true){
            Time.timeScale = 0f;
            GameUI.SetActive(false);
            pausemenu.SetActive(true);
            esc = true;
        }
        
    }








}
