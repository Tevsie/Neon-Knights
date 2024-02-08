using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 5f;  // Initial health
    public float healthP1;             // Player 1 health
    public float healthP2;             // Player 2 health
    public float healthMk2 = 3f;       // EnemyMk2 health

    private MeshBlinkingEffect playerBlinkingEffect;
    private SpriteBlinkingEffect enemyBlinkingEffect;

    void Start()
    {
        // Initialize health values
        healthP1 = startingHealth;
        healthP2 = startingHealth;

        // Get the BlinkingEffect components attached to the player
        playerBlinkingEffect = GetComponent<MeshBlinkingEffect>();
        enemyBlinkingEffect = GetComponent<SpriteBlinkingEffect>();
    }

    // Function to handle taking damage
    public void TakeDamage(float damage, string playerTag)
    {
        // Check the player tag and update health accordingly
        if (playerTag == "Player1")
        {
            healthP1 -= damage;
            Debug.Log("Player 1 Health: " + healthP1);
            // Start blinking effect when player takes damage
            playerBlinkingEffect.StartBlinking();
        }
        else if (playerTag == "Player2")
        {
            healthP2 -= damage;
            Debug.Log("Player 2 Health: " + healthP2);
            // Start blinking effect when player takes damage
            playerBlinkingEffect.StartBlinking();
        }
        else if (playerTag == "EnemyMk2")
        {
            healthMk2 -= damage;
            Debug.Log("EnemyMk2 Health: " + healthMk2);
            // Start blinking effect when enemyMk2 takes damage
            enemyBlinkingEffect.StartBlinking();
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
