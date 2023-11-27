using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour

{
    private bool isRunning;
    public AudioSource footstepsSound, sprintSound, autoSound, magicSound;

    void Update()
    {

        if(Input.GetMouseButtonDown(0)) 
        {
            if(autoSound.enabled == false) 
            {
                Invoke("handleAutoAudioOn", .5f);
            }
                
        }


        if(Input.GetMouseButtonDown(1)) 
        {
            if(magicSound.enabled == false) 
            {
                handleMagicAudioOn();
            }
                
        }
            

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = true;
                sprintSound.enabled = false;
            }
        }
        else
        {
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }
    }

    void handleAutoAudioOn()
    {
        autoSound.enabled = true;
        Invoke("handleAutoAudioOff", 1f);
    }

    void handleAutoAudioOff()
    {
        autoSound.enabled = false;
    }

    void handleMagicAudioOn()
    {
        magicSound.enabled = true;
        Invoke("handleMagicAudioOff", 1f);
    }

    void handleMagicAudioOff()
    {
        magicSound.enabled = false;
    }
}

