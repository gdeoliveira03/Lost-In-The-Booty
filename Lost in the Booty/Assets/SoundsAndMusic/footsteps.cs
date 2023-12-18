using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    private bool isRunning;
    public AudioSource footstepsSound,
        sprintSound,
        autoSound,
        magicSound;

    void Update()
    {
        if (footstepsSound == null || sprintSound == null)
            return;
        if (
            Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.D)
        )
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

    public void handleAutoAudioOn()
    {
        autoSound.enabled = true;
        Invoke("handleAutoAudioOff", 1f);
    }

    public void handleAutoAudioOff()
    {
        autoSound.enabled = false;
    }

    public void handleMagicAudioOn()
    {
        magicSound.enabled = true;
        Invoke("handleMagicAudioOff", 1f);
    }

    public void handleMagicAudioOff()
    {
        magicSound.enabled = false;
    }
}
