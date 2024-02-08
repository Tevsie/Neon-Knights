using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    public float respawnTime = 10f; // Respawn time in seconds
    private Vector3 respawnPosition = new Vector3(1000, 1000, 1000); // Position to move player during respawn

    private bool isRespawningPlayer1 = false;
    private bool isRespawningPlayer2 = false;

    public GameObject endingGameObject; // GameObject to activate at the end

    // Coroutine for player respawn
    public IEnumerator RespawnPlayer(GameObject playerObject, float startingHealth)
    {
        Debug.Log("Respawn coroutine started for " + playerObject.name);

        if (playerObject.CompareTag("Player1"))
        {
            isRespawningPlayer1 = true;
        }
        else if (playerObject.CompareTag("Player2"))
        {
            isRespawningPlayer2 = true;
        }

        // Check if both players are respawning
        if (isRespawningPlayer1 && isRespawningPlayer2)
        {
            // Both players are respawning, deactivate both players
            GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
            GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
            if (player1 != null)
                player1.SetActive(false);
            if (player2 != null)
                player2.SetActive(false);

            Debug.Log("Both players are respawning. Deactivating both players.");

            // Activate the ending GameObject
            if (endingGameObject != null)
            {
                endingGameObject.SetActive(true);
                Debug.Log("Ending GameObject activated.");
            }
            else
            {
                Debug.LogError("Ending GameObject not assigned.");
            }
        }

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
