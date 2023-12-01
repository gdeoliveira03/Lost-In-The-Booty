using UnityEngine;
using UnityEngine.UI;

public class CombatZoneTrigger : MonoBehaviour
{
    public GameObject combatZone;
    public Text combatText;
    public GameObject specificEnemy; // Reference to the specific enemy you want to defeat

    private bool inCombatZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCombatZone = true;
            combatText.text = "COMBAT: DEFEAT THE SPECIFIC ENEMY TO PROGRESS";

            // Ensure the combatZone is activated when entering the trigger
            ActivateCombatZone();
        }
    }

    private void Update()
    {
        if (inCombatZone && specificEnemy != null && !specificEnemy.activeSelf)
        {
            EndCombat();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCombatZone = false;
            combatText.text = ""; // Clear the combat text when leaving the trigger

            // Destroy the trigger zone after combat is complete
            Destroy(gameObject);
        }
    }

    private void ActivateCombatZone()
    {
        // Ensure the combatZone GameObject is active
        if (combatZone != null)
        {
            combatZone.SetActive(true);
        }
        else
        {
            Debug.LogError("CombatZone GameObject is not assigned in the inspector.");
        }
    }

    private void EndCombat()
    {
        inCombatZone = false;
        combatText.text = "COMBAT COMPLETE!"; // Display a message indicating combat completion

        // Additional logic for ending combat, rewards, etc.
    }
}
