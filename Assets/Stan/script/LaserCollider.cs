using UnityEngine;

public class LaserCollider : MonoBehaviour
{
    public SpawnManager spawnManager; // Reference to the SpawnManager script

    // This method is called when a collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider belongs to an enemy prefab
        if (collision.CompareTag("Enemy"))
        {
            // Destroy the enemy prefab
            Destroy(collision.gameObject);

            // Notify the SpawnManager that an enemy has been destroyed
            if (spawnManager != null)
            {
                spawnManager.DecreaseEnemyCount();
            }
        }
    }
}
