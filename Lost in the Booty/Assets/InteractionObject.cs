using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine;

public class DoctorDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Camera mainCamera;  // Assign the main camera in the Inspector
    public Camera dialogueCamera;  // Assign the dialogue camera in the Inspector
    public GameObject tutorialUI;  // Assign the tutorial UI GameObject in the Inspector
    private bool isInRange = false;
    private int currentDialogueIndex = 0;
    private string[] dialogues;

    void Start()
    {
        // Initialize your dialogues here
        dialogues = new string[]
        {
            "Hey I'm Dr. Hendrix!",
            "You must be that pirate that I saw get killed out there!",
            "How are you alive?",
            "Ah I see you were brought back from the dead and you want to get your mortality back",
            "The only way I know to do that is to take revenge on the person who killed you",
            "You don't remember who killed you???",
            "Why it was Davy Jones of course!",
            "Who's Davy Jones? Why, he's the meanest pirates in all the seas!",
            "If you want to take your revenge on him you better be prepared!",
            "It's going to be a very tough fight!",
            "In order to get to him you are going to have to beat his three pirate commanders!",
            "You'll never be able to beat them alone...",
            "I'm a doctor I can help you take your revenge",
            "I'll tag along...",
            "I know where one of the commanders is now...",
            "Let's get started",

            // Add more dialogues as needed
        };

        // Ensure the dialogue panel is initially hidden
        dialoguePanel.SetActive(false);

        // Ensure the main camera is initially enabled, and the dialogue camera is initially disabled
        mainCamera.enabled = true;
        dialogueCamera.enabled = false;
        tutorialUI.SetActive(true);

    }

    void Update()
    {
        // Check for player input when in range
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ShowNextDialogue();
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                EndDialogue();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the main character
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            StartDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is the main character
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            EndDialogue();
        }
    }

    private void StartDialogue()
    {
        // Show the dialogue panel
        dialoguePanel.SetActive(true);

        // Disable the main camera and enable the dialogue camera
        mainCamera.enabled = false;
        dialogueCamera.enabled = true;
        tutorialUI.SetActive(false);


        // Show the first dialogue
        ShowDialogue(dialogues[currentDialogueIndex]);
    }

    private void ShowNextDialogue()
    {
        // Check if there are more dialogues
        if (currentDialogueIndex < dialogues.Length - 1)
        {
            currentDialogueIndex++;
            // Show the next dialogue
            ShowDialogue(dialogues[currentDialogueIndex]);
        }
        else
        {
            // No more dialogues, end the interaction
            EndDialogue();
        }
    }

    private void ShowDialogue(string message)
    {
        // Display the dialogue text
        dialogueText.text = message;
    }

    private void EndDialogue()
    {
        // Hide the dialogue panel
        dialoguePanel.SetActive(false);

        // Disable the dialogue camera and enable the main camera
        mainCamera.enabled = true;
        dialogueCamera.enabled = false;

        // Reset the dialogue index for the next interaction
        currentDialogueIndex = 0;
        SceneManager.LoadScene(8);
    }
}
