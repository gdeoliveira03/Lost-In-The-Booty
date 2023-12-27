using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Transform player;
    private string playerTag = "Player";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    public void KeepPlayingAfterDeath(GameObject deathscreenprefab)
    {
        Time.timeScale = 1f;
        Destroy(deathscreenprefab);
    }

    public void NewSaveButton()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            int savedSceneIndex = PlayerPrefs.GetInt("SavedScene");
            PlayerPrefs.DeleteKey("SavedScene");
        }

        SceneManager.LoadScene(1);
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
            SceneManager.LoadScene(1);
        }
        GameManager.Instance.scruffyInventory.InitializeStats(
            PlayerPrefs.GetInt("SavedSkulls", 0),
            PlayerPrefs.GetInt("SavedCoins", 0)
        );

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
