using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    public float respawnTime = 10f; // Respawn time in seconds
    private Vector3 respawnPosition = new Vector3(1000, 1000, 1000); // Position to move player during respawn

    // Coroutine for player respawn
    public IEnumerator RespawnPlayer(GameObject playerObject, float startingHealth)
    {
        Debug.Log("Respawn coroutine started for " + playerObject.name);

        // Store the player's current position
        Vector3 originalPosition = playerObject.transform.position;

        // Move the player out of the game scene
        playerObject.transform.position = respawnPosition;

        Debug.Log("Player " + playerObject.name + " moved for respawn.");

        // Wait for the respawn time
        yield return new WaitForSeconds(respawnTime);

        Debug.Log("Respawn time completed for " + playerObject.name);

        // Move the player back to their original position
        playerObject.transform.position = originalPosition;

        // Reset player health
        PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.ResetHealth(startingHealth);
            Debug.Log("Player " + playerObject.name + " respawned with starting health: " + startingHealth);
        }
        else
        {
            Debug.LogError("PlayerHealth component not found on " + playerObject.name + ". Respawn failed.");
        }

        Debug.Log("Respawn coroutine completed for " + playerObject.name);
    }
}
