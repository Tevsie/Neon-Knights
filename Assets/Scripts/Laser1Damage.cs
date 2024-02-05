using UnityEngine;

public class Laser1Damage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is Player 2
        if (other.CompareTag("Player2"))
        {
            // Call the TakeDamage() method from the PlayerHealth component
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Check that playerHealth is not null
            if (playerHealth != null)
            {
                // Decrease Player 2's health
                playerHealth.TakeDamage(1f, "Player2");

                // Log Player 2's health to the console (for debugging)
                Debug.Log("Player 2 hit. Health: " + playerHealth.healthP2);

                // Check if Player 2's health is less than or equal to 0, call the Die() method
                if (playerHealth.healthP2 <= 0)
                {
                    Debug.Log("Player 2 dead");
                }
            }
        }
        // Check if the colliding object is an enemy
        else if (other.CompareTag("EnemyMk2"))
        {
            // Get the PlayerHealth component from the enemy object
            PlayerHealth enemyHealth = other.GetComponent<PlayerHealth>();

            // Check that enemyHealth is not null
            if (enemyHealth != null)
            {
                // Decrease the enemy's health
                enemyHealth.TakeDamage(1f, "EnemyMk2");

                // Log the enemy's health to the console (for debugging)
                Debug.Log("Player 2 hit. Health: " + enemyHealth.healthE);

                // Check if the enemy's health is less than or equal to 0, call the Die() method
                if (enemyHealth.healthE <= 0)
                {
                    Debug.Log("EnemyMk2 is dead (LaserScript)");
                }
            }
        }
        // Check if the colliding object is an EnemyMk1
        else if (other.CompareTag("EnemyMk1"))
        {
            // Destroy the EnemyMk1 object
            Destroy(other.gameObject);
        }
    }
}
