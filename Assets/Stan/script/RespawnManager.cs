using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    public float respawnTime; // Respawn time in seconds
    private Vector3 respawnPosition = new Vector3(1000, 1000, 1000); // Position to move player during respawn

    private bool isRespawningPlayer1 = false;
    private bool isRespawningPlayer2 = false;

    public ParticleSystem P1DeathPS;
    public ParticleSystem P2DeathPS;
    public GameObject endingGameObject; // GameObject to activate at the end

    private bool resolvingRespawnPlayer1 = false;
    private bool resolvingRespawnPlayer2 = false;

    // Coroutine for respawning Player 1
    public void RespawnPlayer1(GameObject playerObject, float startingHealth)
    {
        if (!isRespawningPlayer1 && !resolvingRespawnPlayer1)
        {
            StartCoroutine(RespawnCoroutinePlayer1(playerObject, startingHealth));
        }
    }

    // Coroutine for respawning Player 2
    public void RespawnPlayer2(GameObject playerObject, float startingHealth)
    {
        if (!isRespawningPlayer2 && !resolvingRespawnPlayer2)
        {
            StartCoroutine(RespawnCoroutinePlayer2(playerObject, startingHealth));
        }
    }

    private IEnumerator RespawnCoroutinePlayer1(GameObject playerObject, float startingHealth)
    {
        resolvingRespawnPlayer1 = true;
        Debug.Log("Respawn coroutine started for " + playerObject.name);

        isRespawningPlayer1 = true;
        Instantiate(P1DeathPS, playerObject.transform.position, Quaternion.identity);

        // Check if both players are respawning
        if (isRespawningPlayer2)
        {
            EndGame();
        }

        // Store the player's current position
        Vector3 originalPosition = playerObject.transform.position;

        playerObject.transform.position = respawnPosition;

        Debug.Log("Player " + playerObject.name + " moved for respawn.");

        yield return new WaitForSeconds(respawnTime);

        Debug.Log("Respawn time completed for " + playerObject.name);

        // Move the player back to their original position
        playerObject.transform.position = originalPosition;

        // Reset player health
        PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.ResetHealth();
            Debug.Log("Player " + playerObject.name + " respawned with starting health: " + startingHealth);
        }
        else
        {
            Debug.LogError("PlayerHealth component not found on " + playerObject.name + ". Respawn failed.");
        }

        isRespawningPlayer1 = false;
        resolvingRespawnPlayer1 = false;

        yield return new WaitForSeconds(1f);
        Debug.Log("Respawn coroutine completed for " + playerObject.name);
    }

    private IEnumerator RespawnCoroutinePlayer2(GameObject playerObject, float startingHealth)
    {
        resolvingRespawnPlayer2 = true;
        Debug.Log("Respawn coroutine started for " + playerObject.name);

        isRespawningPlayer2 = true;
        Instantiate(P2DeathPS, playerObject.transform.position, Quaternion.identity);

        // Check if both players are respawning
        if (isRespawningPlayer1)
        {
            EndGame();
        }

        // Store the player's current position
        Vector3 originalPosition = playerObject.transform.position;

        playerObject.transform.position = respawnPosition;

        Debug.Log("Player " + playerObject.name + " moved for respawn.");

        yield return new WaitForSeconds(respawnTime);

        Debug.Log("Respawn time completed for " + playerObject.name);

        // Move the player back to their original position
        playerObject.transform.position = originalPosition;

        // Reset player health
        PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.ResetHealth();
            Debug.Log("Player " + playerObject.name + " respawned with starting health: " + startingHealth);
        }
        else
        {
            Debug.LogError("PlayerHealth component not found on " + playerObject.name + ". Respawn failed.");
        }

        isRespawningPlayer2 = false;
        resolvingRespawnPlayer2 = false;

        yield return new WaitForSeconds(1f);
        Debug.Log("Respawn coroutine completed for " + playerObject.name);
    }

    // Method to end the game
    private void EndGame()
    {
        Debug.Log("Both players are respawning. Ending the game.");

        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");

        // Deactivate both players
        if (player1 != null)
            player1.SetActive(false);
        if (player2 != null)
            player2.SetActive(false);

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
}
