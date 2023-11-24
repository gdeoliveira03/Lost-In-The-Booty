using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    private int activeRigIndex = 0;
    void Start()
    {
        if (freeLookCamera == null)
        {
            Debug.LogError("FreeLookCamera not assigned to CameraSwitcher script.");
            return;
        }
    }

    void Update()
    {
        // Check for the "V" key press
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Toggle between the different rigs
            ToggleRigs();
        }
    }

    void ToggleRigs()
    {
        // Switch between different settings for the CinemachineFreeLook component
        if (freeLookCamera.m_Orbits.Length >= 3)
        {
            // Assume you have at least three rigs (top, middle, bottom)
            if (freeLookCamera.m_Orbits[0].m_Height == 0f) // Check the height of the top rig
            {
                // Switch to the middle rig
                freeLookCamera.m_Orbits[0].m_Height = 14f;
                freeLookCamera.m_Orbits[1].m_Height = 8f;
                freeLookCamera.m_Orbits[2].m_Height = 0f;
            }
            else if (freeLookCamera.m_Orbits[1].m_Height == 0f) // Check the height of the middle rig
            {
                // Switch to the bottom rig
                freeLookCamera.m_Orbits[0].m_Height = 5f;
                freeLookCamera.m_Orbits[1].m_Height = 14f;
                freeLookCamera.m_Orbits[2].m_Height = 0f;
            }
            else
            {
                // Switch to the top rig
                freeLookCamera.m_Orbits[0].m_Height = 8f;
                freeLookCamera.m_Orbits[1].m_Height = 0f;
                freeLookCamera.m_Orbits[2].m_Height = 20f;
            }
        }
    }
    }
