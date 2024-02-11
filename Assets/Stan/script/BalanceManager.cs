using UnityEngine;

public class BalanceManager : MonoBehaviour
{
    [Header("Accessing...")]
    public PlayerHealth healthScript;
    public GameObject laserP1;
    public GameObject laserP2;

    [Header("Player 1 Balance")]
    public LaserForP1 laserP1Script;
    public Movement4player1 movementP1Script;
    public float p1LaserLength;
    public int p1RotateSpeed;
    public int p1RotateAngle;
    public float p1Cooldown;
    public float p1MovementSpeed; 

    [Header("Player 2 Balance")]
    public LaserForP2 laserP2Script;
    public Movement4player2 movementP2Script;
    public float p2LaserLength;
    public int p2RotateSpeed;
    public int p2RotateAngle;
    public float p2Cooldown;
    public float p2MovementSpeed;


    // public PlayerHealth playerHealthScript;
    // public SpawnManager spawnManagerScript;

    void Update()
    {
         // Check if the objectToScale reference is assigned
        if (laserP1 != null)
        {
            Vector3 newScale = laserP1.transform.localScale;
            newScale.x = p1LaserLength;
            laserP1.transform.localScale = newScale;
        }

         if (laserP2 != null)
        {
            Vector3 newScale = laserP2.transform.localScale;
            newScale.x = p2LaserLength;
            laserP2.transform.localScale = newScale;
        }



        // laserP1Script.rotationSpeed += laserP1RotateSpeedMod;
        // laserP1Script.rotationAngle += laserP1RotateAngleMod;
        // laserP1Script.swordCooldown += laserP2CooldownMod;

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
}
