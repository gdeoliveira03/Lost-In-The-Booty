using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject GameUI;
    bool esc = false;

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        GameUI.SetActive(true);
        pausemenu.SetActive(false);
        esc = false;
    }

    public void OptionsMenu(){
        /*SceneManager.LoadScene("OptionsMenu") */
    }

    public void QuitGame(){
        Application.Quit();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) == true && esc == true){
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
