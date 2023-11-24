using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;
    public Slider progressBar; // Reference to your UI Slider

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Load a scene asynchronously by build index
    public void LoadSceneAsync(int buildIndex)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(buildIndex));
    }

    IEnumerator LoadSceneAsyncCoroutine(int buildIndex)
    {
        // Ensure the progress bar is not null
        if (progressBar == null)
        {
            Debug.LogError("Progress bar not assigned in LoadingManager.");
            yield break;
        }

        // Set the slider value to 0 at the beginning
        progressBar.value = 0f;

        // Load the loading screen scene
        yield return SceneManager.LoadSceneAsync(10);

        // Load the target scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

        // Allow the loading screen to be displayed while the target scene is loading
        while (!asyncLoad.isDone)
        {
            // Update the progress bar based on the loading progress
            progressBar.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            yield return null;
        }
    }
}
