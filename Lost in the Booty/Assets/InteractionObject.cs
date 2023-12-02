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
    public GameObject scruffy;
    public GameObject doctor;
    public bool isScruffy;
    public Camera mainCamera;  // Assign the main camera in the Inspector
    public Camera dialogueCamera;  // Assign the dialogue camera in the Inspector
    public GameObject tutorialUI;  // Assign the tutorial UI GameObject in the Inspector
    //public PlayerStateMachine playerStateMachine;  // Reference to the PlayerStateMachine component
    public int conversationNumber;
    private bool isInRange = false;
    private int currentDialogueIndex = 0;
    private string[] dialogues;


    void Start()
    {
        //playerStateMachine = doctor.GetComponent<PlayerStateMachine>();

        string[] dialogue1 = new string[]
        {
            "We're here!",
            "This is my home village",
            "That's strange I don't see any of those evil pirates around...",
            "Let's ask around to see where they went",
            // Add more dialogues as needed
        };

        string[] dialogue0 = new string[]
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
        //Scruffy Start Dialogue
        string[] dialogue2 = new string[]
    {
            "Where am I?\n\nPress 'F' to advance dialogue",
            "Also...",
            "Who am I?",
            "And why am I a skeleton???",
            "I guess I should explore this island...",
        // Add more dialogues as needed
    };
    //VolcanicIsland
     string[] dialogue3 = new string[]
    {
            "I've heard rumors about this place...\n\nPress 'F' to advance dialogue",
            "There are many stories about people coming to this island and never coming back...",
            "Supposedly, there is an entrance to the volcano just ahead...",
            "I figure this is as good a place as any to find information on Davy Jones or his commanders...",
            "You go on ahead...I will catch up to you",
        // Add more dialogues as needed
    };
        string[] dialogue4 = new string[]
    {
            "We're here...\n\nPress 'F' to advance dialogue",
            "This island supposedly has a dungeon that is rich with treasures...",
            "Seems to me that this is a great place to find one of Davy Jones' commanders",
            "Let's go check it out!",
        // Add more dialogues as needed
    };

        string[] dialogue5 = new string[]
   {
            "This is Davy Jones' Island...\n\nPress 'F' to advance dialogue",
            "Maybe it's too soon to be here...",
            "We could always come back when you feel you are better prepared for the task...",
            "It wouldn't hurt to gain some experience first...",
            "But if you feel like you are ready...",
            "Let's do this!",
       // Add more dialogues as needed
   };
        string[] dialogue6 = new string[]
       {
            "This place is scary...'\n\n'Press 'F' to advance dialogue",
            "So this is the inside of the dungeon...",
           // Add more dialogues as needed
       };
        string[] dialogue7 = new string[]
{
            "We're here...\n\nPress 'F' to advance dialogue",
            "Sorry Scruffy, I don't really know much about this island...",
            "It's crawling with enemies, there must be something valuable here...",
            "I figure there might be something here worth exploring...",
            "Let's go check it out!",
    // Add more dialogues as needed
};

        string[] dialogue8 = new string[]
{
            "A skeleton! n\nPress 'F' to advance dialogue",
            "Hot damn! The dead walk amongst us...",
            "I've seen stranger...Don't ask....",
            "So you want to know where those dirty pirates went off to?",
            "There's a dungeon at the rear of the island, check there!",
    // Add more dialogues as needed
};

        string[] dialogue9 = new string[]
{
            "My dog would love to get his paws on you n\nPress 'F' to advance dialogue",
            "Ah! You're after those pirates...",
            "I think they went into that dungeon across the island",
            "Good luck!"
    // Add more dialogues as needed
};

        string[] dialogue10 = new string[]
{
            "Welcome to horseshoe crab island... n\nPress 'F' to advance dialogue",
            "The villagers say that there is a dungeon here that is frequented by Pirates...",
            "It should be somewhere on this island...",
            "Let's go check it out!"
    // Add more dialogues as needed
};

        string[] dialogue11 = new string[]
{
            "You made it!... n\nPress 'F' to advance dialogue",
            "The dungeon should be somewhere around here...",
            "Check the area behind me to me right...",
            "Take a look...I'll meet you inside!",
    // Add more dialogues as needed
};

        string[] dialogue12 = new string[]
{
            "Scruffy... n\nPress 'F' to advance dialogue",
            "You want to know why I killed you...",
            "The unfortunate truth is....!",
            "I got lost in the booty....",
            "And I did not want to share my treasure with the likes of you!",
            "I won't apologize for what I did...",
            "Let's get this over with!",
    // Add more dialogues as needed
};
        string[] dialogue99 = new string[]
{
            "Hello There!",
            "Talk to someone else!"
    // Add more dialogues as needed
};


        // Initialize your dialogues here
        switch (conversationNumber)
        {
            case 0:
                dialogues = dialogue0;
                break;
            case 1:
                dialogues = dialogue1; // Corrected the assignment here
                break;
            case 2: 
                dialogues = dialogue2;
                break;
            case 3:
                dialogues = dialogue3;
                break;
            case 4:
                dialogues = dialogue4; // Corrected the assignment here
                break;
            case 5:
                dialogues = dialogue5;
                break;
            case 6:
                dialogues = dialogue6;
                break;
            case 7:
                dialogues = dialogue7;
                break;
            case 8:
                dialogues = dialogue8;
                break;
            case 9:
                dialogues = dialogue9;
                break;
            case 10:
                dialogues = dialogue10;
                break;
            case 11:
                dialogues = dialogue11;
                break;

            case 12:
                dialogues = dialogue12;
                break;
            case 99:
                dialogues = dialogue99;
                break;
        }

        // Ensure the dialogue panel is initially hidden
        dialoguePanel.SetActive(false);

        // Ensure the main camera is initially enabled, and the dialogue camera is initially disabled
        mainCamera.enabled = true;
        dialogueCamera.enabled = false;
        tutorialUI.SetActive(true);
        //scruffy.SetActive(false);

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
        if (other.CompareTag("Player"))
        {
            isInRange = true;

            // Hide scruffy only when isScruffy is false
            if (!isScruffy)
                scruffy.SetActive(false);

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
        if(!isScruffy)
        scruffy.SetActive(false);

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
        scruffy.SetActive(true);

        // Hide the dialogue panel
        dialoguePanel.SetActive(false);

        // Disable the dialogue camera and enable the main camera
        mainCamera.enabled = true;
        dialogueCamera.enabled = false;
        scruffy.SetActive(true);

        // Reset the dialogue index for the next interaction
        currentDialogueIndex = 0;
        /* 
        PlayerStateMachine doctorStateMachine = doctor.GetComponent<PlayerStateMachine>();
        if (doctorStateMachine != null)
        {
            doctorStateMachine.enabled = true;
        }
        */
         
        if(conversationNumber == 0)
        SceneManager.LoadScene(8);

        //if(conversationNumber == 1)
        //doctor.SetActive(false);
        scruffy.SetActive(true);
        Destroy(gameObject);
        tutorialUI.SetActive(true);

        scruffy.SetActive(true);

        scruffy.SetActive(true);



    }
}
