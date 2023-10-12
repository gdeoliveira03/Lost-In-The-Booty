using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static bool isGamePaused = false;

    [SerializeField] GameObject PauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused){
                ResumeGame();
            }
            else
            {
                PauseGame();
            } 
        }
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    } 

    public void OptionsMenu(){
        /*SceneManager.LoadScene("OptionsMenu") */
    }

    public void QuitGame(){
        Application.Quit();

        Debug.Log("Quit!");
    }

}
