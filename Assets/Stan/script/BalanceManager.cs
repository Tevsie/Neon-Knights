using UnityEngine;

public class BalanceManager : MonoBehaviour
{
    [Header("Accessing...")]
    public PlayerHealth healthScript;
    // public SpawnManager spawnManager;

    [Header("Player 1 Balance")]
    public GameObject laserP1;
    public LaserForP1 laserP1Script;
    public Movement4player1 movementP1Script;
    public float p1LaserLength;
    public int p1RotateSpeed;
    public int p1RotateAngle;
    public float p1Cooldown;
    public float p1MovementSpeed; 

    [Header("Player 2 Balance")]
    public GameObject laserP2;
    public LaserForP2 laserP2Script;
    public Movement4player2 movementP2Script;
    public float p2LaserLength;
    public int p2RotateSpeed;
    public int p2RotateAngle;
    public float p2Cooldown;
    public float p2MovementSpeed;

    [Header("Enemy Balance")]
    public GameObject enemyMk1;
    public GameObject enemyMk2;
    public float enemyMk1Speed;
    public float enemyMk2Speed;

    void Start()
    {
        // Initialize enemy's speed before the game begins
        if (enemyMk1 != null)
        {
            // Access EnemyMovement component attached to EnemyMK1 and modify speed
            EnemyMovement enemyMk1Movement = enemyMk1.GetComponent<EnemyMovement>();
            if (enemyMk1Movement != null)
            {
                enemyMk1Movement.speed = enemyMk1Speed; 
            }
        }

        if (enemyMk2 != null)
        {
            // Access EnemyMovement component attached to EnemyMK2 and modify speed
            EnemyMovement enemyMk2Movement = enemyMk2.GetComponent<EnemyMovement>();
            if (enemyMk2Movement != null)
            {
                enemyMk2Movement.speed = enemyMk2Speed; // Modify the speed directly
            }
        }
    }

    void Update()
    {
        // Laser P1 Length Modifiers
        if (laserP1 != null)
        {
            Vector3 newScale = laserP1.transform.localScale;
            newScale.x = p1LaserLength;
            laserP1.transform.localScale = newScale;
        }

        // Laser P2 Length Modifiers
         if (laserP2 != null)
        {
            Vector3 newScale = laserP2.transform.localScale;
            newScale.x = p2LaserLength;
            laserP2.transform.localScale = newScale;
        }

    //     // Modify player starting health
    //     if (playerHealthScript != null)
    //     {
    //         playerHealthScript.startingHealth *= playerStartingHealthModifier;
    //     }

    //     // Modify enemy spawn interval
    //     if (spawnManagerScript != null)
    //     {
    //         spawnManagerScript.spawnInterval *= enemySpawnIntervalModifier;
    //     }
    // }
    }

    // void SetEnemySpeed(GameObject enemy, float speed)
    // {
    //     if (enemy != null)
    //     {
    //         EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
    //         if (enemyMovement != null)
    //         {
    //             enemyMovement.SetSpeed(speed);
    //         }
    //     }
    // }
}
