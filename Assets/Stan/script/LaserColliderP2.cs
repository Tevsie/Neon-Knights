using UnityEngine;

public class LaserColliderP2 : MonoBehaviour
{
    public SpawnManager spawnManager;

      private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBoundChecker enemyBoundsChecker = collision.gameObject.GetComponent<EnemyBoundChecker>();
        
        if (enemyBoundsChecker != null && enemyBoundsChecker.IsWithinScreenBounds())
        {
            switch (collision.tag)
            {
                case "EnemyMk1":
                    DestroyEnemy(collision.gameObject);
                    break;
                case "EnemyMk2":
                    DamageEnemy(collision.gameObject, 1);
                    break;
                default:
                    break;
            }
        }
        
        else if (collision.tag == "Player1")
        {
            FriendlyFire(collision.gameObject, 1);
        }
    }
    
    private void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);

        if (spawnManager != null)
        {
            spawnManager.DecreaseEnemyCount();
        }
    }

    private void DamageEnemy(GameObject enemy, float damage)
    {
        PlayerHealth enemyHealth = enemy.GetComponent<PlayerHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage, "EnemyMk2");
        }
    }

    private void FriendlyFire(GameObject player, float damage)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage, "Player1");
        }
    }
}
