using UnityEngine;

public class LaserColliderP1 : MonoBehaviour
{
      private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBoundChecker enemyBoundsChecker = collision.gameObject.GetComponent<EnemyBoundChecker>();
        
        if (enemyBoundsChecker != null && enemyBoundsChecker.IsWithinScreenBounds())
        {
            if (collision.tag == "EnemyMk1" || collision.tag == "EnemyMk2")
            {
                Debug.Log("Collided against " + collision.tag);
                DamageEnemy(collision.gameObject, 1);
            }
            
        }

        else if (collision.tag == "Player2")
        {
            FriendlyFire(collision.gameObject, 1);
        }
    }

    private void DamageEnemy(GameObject enemy, float damage)
    {
        PlayerHealth enemyHealth = enemy.GetComponent<PlayerHealth>();

        if (enemyHealth != null)
        {
            string enemyType = enemy.tag;
            enemyHealth.TakeDamage(damage, enemyType);
        }
    }

    private void FriendlyFire(GameObject player, float damage)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage, "Player2");
        }
    }
}
