using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    private bool tutorialStarted = false;

    private enum TutorialStep
    {
        Move,
        RotateCamera,
        Jump,
        ClickOnFlag,
        SelectWeaponAndElement,
        Attack,
        Magic,
        SelectSpell,
        UseSpell,
        Save,
        ExploreIsland
    }

    private TutorialStep currentStep = TutorialStep.Move;

    private void Update()
    {
        if (!tutorialStarted)
        {
            StartTutorial();
            tutorialStarted = true;
        }

        // Check for user input to advance tutorial
        if (Input.GetKeyDown(KeyCode.F))
        {
            AdvanceTutorial();
        }
    }

    private void StartTutorial()
    {
        StartCoroutine(ShowTutorial("Use WASD keys to move the character. Press 'F' for the next tutorial.", 300f));
    }

    IEnumerator ShowTutorial(string message, float duration)
    {
        DisplayTutorial(message);

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        if (currentStep != TutorialStep.ExploreIsland)
        {
            tutorialText.text = "Press 'F' for the next tutorial.";
        }
    }

    void DisplayTutorial(string message)
    {
        tutorialText.text = message;
    }

    void AdvanceTutorial()
    {
        switch (currentStep)
        {
            case TutorialStep.Move:
                currentStep = TutorialStep.RotateCamera;
                StartCoroutine(ShowTutorial("Use Q and E to rotate the camera. Press 'F' for the next tutorial.", 300f));
                break;
            case TutorialStep.RotateCamera:
                currentStep = TutorialStep.Jump;
                StartCoroutine(ShowTutorial("Press Space to jump. Press 'F' for the next tutorial.", 300f));
                break;
            case TutorialStep.Jump:
                currentStep = TutorialStep.ClickOnFlag;
                StartCoroutine(ShowTutorial("Click on the flag to view stats. Press 'F' for the next tutorial.", 300f));
                break;
            case TutorialStep.ClickOnFlag:
                currentStep = TutorialStep.SelectWeaponAndElement;
                StartCoroutine(ShowTutorial("Select your weapon and element in the Status Menu. Press 'F' for the next tutorial.", 300f));
                break;
            case TutorialStep.SelectWeaponAndElement:
                currentStep = TutorialStep.Attack;
                StartCoroutine(ShowTutorial("Use Left Mouse Button to attack with your weapon. Press 'F' for the next tutorial.", 300f));
                break;
            case TutorialStep.Attack:
                currentStep = TutorialStep.Magic;
                StartCoroutine(ShowTutorial("Use Right Mouse Button to attack with magic. Press 'F' for the next tutorial.", 300f));
                break;
            case TutorialStep.Magic:
                currentStep = TutorialStep.SelectSpell;
                StartCoroutine(ShowTutorial("Click on the spell book to select spells. Press 'F' for the next tutorial.", 300f));
                break;
            case TutorialStep.SelectSpell:
                currentStep = TutorialStep.UseSpell;
                StartCoroutine(ShowTutorial("To use a spell, press the number on your keyboard that corresponds to the spell's hotkey number. Press 'F' for the next tutorial.", 300f));
                break;
            case TutorialStep.UseSpell:
                currentStep = TutorialStep.ExploreIsland;
                StartCoroutine(ShowTutorial("Explore the island and find out what happened to you", 50f));
                Invoke("endtutorial", 10f);
                break;
            case TutorialStep.ExploreIsland:
                // This could be the end of your tutorials or continue to the next step
                break;
            default:
                break;
        }
    }


    void endtutorial(){
        Destroy(gameObject);
    }
}
