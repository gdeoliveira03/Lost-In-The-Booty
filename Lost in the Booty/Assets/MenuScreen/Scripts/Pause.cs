using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausemenu;
    bool esc = false;

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
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
            Time.timeScale = 1f;
            pausemenu.SetActive(false);
            esc = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) == true){
            Time.timeScale = 0f;
            pausemenu.SetActive(true);
            esc = true;
        }
        
    }

}
