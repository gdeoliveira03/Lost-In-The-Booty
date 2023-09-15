using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject spawnPoint; // The point where you want to spawn the character.
    public GameObject characterPrefab;

    void Start()
    {
        // Raycast to find the ground position beneath the spawn point.
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint.transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            // Set the character's position to the hit point, adding a small offset to prevent clipping.
            Vector3 spawnPosition = hit.point + Vector3.up * 0.1f;
            
            // Debug the raycast hit point.
            Debug.DrawRay(spawnPoint.transform.position, Vector3.down * hit.distance, Color.green, 5.0f);

            // Instantiate the character prefab at the spawn point's position and rotation.
            Instantiate(characterPrefab, spawnPosition, spawnPoint.transform.rotation);
        }
        else
        {
            // Debug that the raycast did not hit the ground.
            Debug.DrawRay(spawnPoint.transform.position, Vector3.down * 10.0f, Color.red, 5.0f);

            // Default to the spawn point's position if no ground is found (adjust as needed).
            Instantiate(characterPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

}
