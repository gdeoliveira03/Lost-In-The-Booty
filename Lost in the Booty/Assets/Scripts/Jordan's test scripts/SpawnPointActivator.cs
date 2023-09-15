using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointActivator : MonoBehaviour
{
    public GameObject spawnPoint; // Reference to the Spawn Point GameObject.

    // This method can be called to activate the Spawn Point GameObject.
    public void ActivateSpawnPoint()
    {
        if (spawnPoint != null)
        {
            spawnPoint.SetActive(true); // Activate the Spawn Point GameObject.
        }
    }
}
