using UnityEngine;
using System.Collections;

public class LaserCollider : MonoBehaviour
{
    public SpawnManager spawnManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyMk1"))
        {
            DestroyEnemy(collision.gameObject);
        }
        else if (collision.CompareTag("EnemyMk2"))
        {
            DamageEnemy(collision.gameObject, 1); // Deal 1 damage to EnemyMk2
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
}
