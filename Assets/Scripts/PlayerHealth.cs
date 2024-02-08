using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 5f;  // Initial health
    public float healthP1;             // Player 1 health
    public float healthP2;             // Player 2 health
    public float healthMk2 = 3f;       // EnemyMk2 health

    void Start()
    {
        // Initialize health values
        healthP1 = startingHealth;
        healthP2 = startingHealth;
    }

    // Function to handle taking damage
    public void TakeDamage(float damage, string playerTag)
    {
        // Check the player tag and update health accordingly
        if (playerTag == "Player1")
        {
            healthP1 -= damage;
            Debug.Log("Player 1 Health: " + healthP1);
        }
        else if (playerTag == "Player2")
        {
            healthP2 -= damage;
            Debug.Log("Player 2 Health: " + healthP2);
        }
        else if (playerTag == "EnemyMk2")
        {
            healthMk2 -= damage;
            Debug.Log("EnemyMk2 Health: " + healthMk2);
        }

        // Check for death (you can implement your own logic)
        if (healthP1 <= 0f)
        {
            Die("Player1");
        }

        if (healthP2 <= 0f)
        {
            Die("Player2");
        }

        if (healthMk2 <= 0f)
        {
            Die("EnemyMk2");
        }
    }

    // Function to handle death
    void Die(string playerName)
    {
        // Logic for death
        Debug.Log(playerName + " is dead");
        Destroy(gameObject); // Destroy the player object
    }
}
