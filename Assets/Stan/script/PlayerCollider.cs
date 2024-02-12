using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerHealth playerHealth; 

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyMk1"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(1f, "EnemyMk1");
            playerHealth.TakeDamage(1f, gameObject.tag);
        }

        if (other.CompareTag("EnemyMk2"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(1f, "EnemyMk2");
            playerHealth.TakeDamage(5f, gameObject.tag);
        }
    }
}
