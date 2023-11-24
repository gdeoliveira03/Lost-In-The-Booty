using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private bool tutorialStarted = false;

    private void Update()
    {
        if (!tutorialStarted)
        {
            // Start the tutorial
            StartCoroutine(ShowTutorial("Use WASD keys to move the character.", 8f));
            tutorialStarted = true;
        }
        // Add additional conditions to progress to the next steps if needed
    }

    IEnumerator ShowTutorial(string message, float duration)
    {
        // Display the tutorial message
        DisplayTutorial(message);

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Clear the tutorial text after the duration
        tutorialText.text = "";

        // Move to the next tutorial step after a delay
        yield return new WaitForSeconds(1f); // Adjust the delay as needed

        if (message.Contains("WASD keys"))
        {
            StartCoroutine(ShowTutorial("Use Q and E to rotate the camera.", 8f));
        }
        else if (message.Contains("Use Q and E to rotate the camera"))
        {
            StartCoroutine(ShowTutorial("Press Space to jump.", 8f));
        }
        else if (message.Contains("Press Space to jump"))
        {
            StartCoroutine(ShowTutorial("Use Left Mouse Button to attack with your weapon.", 8f));
        }
        else if (message.Contains("Left Mouse Button to attack with your weapon"))
        {
            StartCoroutine(ShowTutorial("Use Right Mouse Button to attack with magic.", 8f));
        }
        else if (message.Contains("Right Mouse Button to attack with magic"))
        {
            StartCoroutine(ShowTutorial("Click on the spell book to select spells. Assign a spell to your hotkey by selecting the spell and setting it.", 8f));
        }
        else if (message.Contains("Click on the spell book to select spells"))
        {
            StartCoroutine(ShowTutorial("To use a spell, press the number on your keyboard that corresponds to the spell's hotkey number.", 8f));
        }
        // Add more conditions for additional steps if needed
    }

    void DisplayTutorial(string message)
    {
        // Display the tutorial message
        tutorialText.text = message;
    }
}
