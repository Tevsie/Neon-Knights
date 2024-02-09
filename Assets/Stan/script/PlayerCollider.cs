using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerHealth playerHealth; // Reference to the PlayerHealth script

    void Start()
    {
        // Get the PlayerHealth component attached to the player
        playerHealth = GetComponent<PlayerHealth>();
    }

    // This method is automatically called when the player collides with another object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object the player collided with is tagged as an "Enemy"
        if (other.CompareTag("EnemyMk1"))
        {
            playerHealth.TakeDamage(1f, gameObject.tag);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("EnemyMk2"))
        {
            playerHealth.TakeDamage(5f, gameObject.tag);
            Destroy(other.gameObject);
        }
    }
}
