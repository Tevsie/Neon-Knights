using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float healthP1;             
    private float healthP2;             
    public float healthMk2;       

    private MeshBlinkingEffect playerBlinkingEffect;
    private MeshBlinkingEffect enemyBlinkingEffect;

    private SpawnManager spawnManager; 
    private RespawnManager respawnManager;
    public BalanceManager balanceManager;

    private bool isRespawningP1 = false; 
    private bool isRespawningP2 = false; 

    void Start()
    {
        // Initialize health values
        healthP1 = balanceManager.p1Health;
        healthP2 = balanceManager.p2Health;
    
        playerBlinkingEffect = GetComponent<MeshBlinkingEffect>();
        enemyBlinkingEffect = GetComponent<MeshBlinkingEffect>();

        spawnManager = FindObjectOfType<SpawnManager>();
        respawnManager = FindObjectOfType<RespawnManager>();
    }

    // Function to handle taking damage
    public void TakeDamage(float damage, string playerTag)
    {
        // Check if the player is respawning
        if (isRespawningP1 || isRespawningP2)
            return;

        if (playerTag == "Player1")
        {
            healthP1 -= damage;
            Debug.Log("Player 1 Health: " + healthP1);
            // Start blinking effect when player takes damage
            playerBlinkingEffect.StartBlinking();
            // Check for death of players
            if (healthP1 <= 0f)
            {
                Die("Player1");
            }
        }
        else if (playerTag == "Player2")
        {
            healthP2 -= damage;
            Debug.Log("Player 2 Health: " + healthP2);
            // Start blinking effect when player takes damage
            playerBlinkingEffect.StartBlinking();
            // Check for death of players
            if (healthP2 <= 0f)
            {
                Die("Player2");
            }
        }
        else if (playerTag == "EnemyMk2")
        {
            healthMk2 -= damage;
            Debug.Log("EnemyMk2 Health: " + healthMk2);
            // Start blinking effect when enemyMk2 takes damage
            enemyBlinkingEffect.StartBlinking();
            // Check for death
            if (healthMk2 <= 0f)
            {
                Die("EnemyMk2");
            }
        }
    }

    // Function to handle death or respawn
    void Die(string playerName)
    {
        // Logic for death
        Debug.Log(playerName + " is dead");

        // If the enemy dies, decrease the enemy count
        if (playerName == "EnemyMk2")
        {
            // Destroy the EnemyMk2 GameObject
            Destroy(gameObject);
            // Decrease the enemy count
            spawnManager.DecreaseEnemyCount();
        }

        // Start respawn coroutine for players
        if (playerName == "Player1")
        {
            StartCoroutine(respawnManager.RespawnPlayer(gameObject, healthP1));
        }

        if (playerName == "Player2")
        {
            StartCoroutine(respawnManager.RespawnPlayer(gameObject, healthP2));
        }
    }

    // Function to reset player health
    public void ResetHealth(float health)
    {
        if (gameObject.CompareTag("Player1"))
        {
            healthP1 = health;
        }
        else if (gameObject.CompareTag("Player2"))
        {
            healthP2 = health;
        }
    }
}
