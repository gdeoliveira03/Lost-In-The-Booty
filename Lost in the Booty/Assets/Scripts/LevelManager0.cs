using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager0 : MonoBehaviour
{

    //public string sceneName;
    public int buildindex;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeScene()
    {

        //Scene scene = SceneManager.GetSceneByBuildIndex(buildindex);
        SceneManager.LoadScene(buildindex);
    }


}
