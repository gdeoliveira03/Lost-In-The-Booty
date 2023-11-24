using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("Start Game!");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
