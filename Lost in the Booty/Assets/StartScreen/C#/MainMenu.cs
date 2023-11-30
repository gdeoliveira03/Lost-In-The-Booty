using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Transform player;
    private string playerTag = "Player";
    void Start(){
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    public void KeepPlayingAfterDeath(GameObject deathscreenprefab){
        Time.timeScale = 1f;
        Destroy(deathscreenprefab);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Start Game!");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
