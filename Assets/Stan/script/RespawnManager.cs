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

    private bool resolvingRespawn = false;

    // Coroutine for player respawn

    public void RespawnPlayer(GameObject playerObject, float startingHealth)
    {
        if (!resolvingRespawn)
        {
            StartCoroutine(RespawnCoroutine(playerObject, startingHealth));
        }
    }

    public IEnumerator RespawnCoroutine(GameObject playerObject, float startingHealth)
    {
        resolvingRespawn = true;
        
        Debug.Log("Respawn coroutine started for " + playerObject.name);

        if (playerObject.CompareTag("Player1"))
        {
            isRespawningPlayer1 = true;
            Instantiate(P1DeathPS, playerObject.transform.position, Quaternion.identity);
        }
        else if (playerObject.CompareTag("Player2"))
        {
            isRespawningPlayer2 = true;
            Instantiate(P2DeathPS, playerObject.transform.position, Quaternion.identity);
        }

        // Check if both players are respawning
        if (isRespawningPlayer1 && isRespawningPlayer2)
        {
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

          if (playerObject.CompareTag("Player1"))
        {
            isRespawningPlayer1 = false;
        }
        else if (playerObject.CompareTag("Player2"))
        {
            isRespawningPlayer2 = false;
        }

        yield return new WaitForSeconds(1f);
        resolvingRespawn = false;    
        Debug.Log("Respawn coroutine completed for " + playerObject.name);
    }
}
