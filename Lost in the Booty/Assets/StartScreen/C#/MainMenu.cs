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

    public void NewSaveButton(){
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            int savedSceneIndex = PlayerPrefs.GetInt("SavedScene");
            PlayerPrefs.DeleteKey("SavedScene");
        }
        if(GameManager.Instance.scruffyInventory.Cutlass != null &&
        GameManager.Instance.scruffyInventory.Spear != null &&
        GameManager.Instance.scruffyInventory.Hammer != null &&
        GameManager.Instance.scruffyInventory.Fire != null &&
        GameManager.Instance.scruffyInventory.Ice != null &&
        GameManager.Instance.scruffyInventory.Lightning != null &&
        GameManager.Instance.scruffyInventory.Coins != null &&
        GameManager.Instance.scruffyInventory.Skulls != null 
        ){
            GameManager.Instance.scruffyInventory.Cutlass = false;
            GameManager.Instance.scruffyInventory.Spear = false;
            GameManager.Instance.scruffyInventory.Hammer = false;
            GameManager.Instance.scruffyInventory.Fire = false;
            GameManager.Instance.scruffyInventory.Ice = false;
            GameManager.Instance.scruffyInventory.Lightning = false;
            GameManager.Instance.scruffyInventory.Coins = 0;
            GameManager.Instance.scruffyInventory.Skulls = 0;
        }
        SceneManager.LoadScene(0);
    }

    public void StartButton()
    {
        int savedSceneIndex = PlayerPrefs.GetInt("SavedScene", 0);
        if (savedSceneIndex != 0)
        {
            // Load the saved scene
            SceneManager.LoadScene(savedSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        GameManager.Instance.scruffyInventory.Coins = PlayerPrefs.GetInt("SavedCoins", 0);
        GameManager.Instance.scruffyInventory.Skulls = PlayerPrefs.GetInt("SavedSkulls", 0);

        Debug.Log("Start Game!");
    }

    // Update is called once per frame
    public void Quit()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("SavedCoins", GameManager.Instance.scruffyInventory.Coins);
        PlayerPrefs.SetInt("SavedSkulls", GameManager.Instance.scruffyInventory.Skulls);    
        PlayerPrefs.Save();
        Application.Quit();
        Debug.Log("Quit!");
    }
}
