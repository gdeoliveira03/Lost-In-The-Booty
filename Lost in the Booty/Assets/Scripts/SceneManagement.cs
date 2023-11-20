using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneName;
    public int buildindex;

    
    public void ChangeScene()
    {
        Scene scene = SceneManager.GetSceneByBuildIndex(buildindex);
        SceneManager.LoadScene(scene.name);
    }
}
