using UnityEngine;

public class Laser2Damage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is Player 1
        if (other.CompareTag("Player1"))
        {
            // Call the Die() method from the PlayerHealth component
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Check that playerHealth is not null
            if (playerHealth != null)
            {
                // Decrease Player 1's health
                playerHealth.healthP1--;

                // Log Player 1's health to the console (for debugging)
                Debug.Log("Player 1 hit. Health: " + playerHealth.healthP1);

                // Check if Player 1's health is less than or equal to 0, call the Die() method
                if (playerHealth.healthP1 <= 0)
                {
                    Debug.Log("Player 1 dead");
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
                Debug.Log("Enemy hit. Health: " + enemyHealth.healthMk2);

                // Check if the enemy's health is less than or equal to 0, call the Die() method
                if (enemyHealth.healthMk2 <= 0)
                {
                    Debug.Log("Enemy is dead (LaserScript)");
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
