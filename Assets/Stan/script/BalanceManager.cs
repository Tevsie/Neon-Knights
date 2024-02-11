using UnityEngine;

public class BalanceManager : MonoBehaviour
{
    // P1 laser modifiers
    public LaserForP1 laserP1Script;
    public int p1RotateSpeed;
    public int p1RotateAngle;
    public float p1Cooldown;

    // // P2 laser modifiers
    // public LaserForP2 laserP2Script;
    // public int playerStartingHealthModifier = 1;
    // public int enemySpawnIntervalModifier = 1;
    // public int laserP2CooldownMod = 1;

    // public PlayerHealth playerHealthScript;
    // public SpawnManager spawnManagerScript;

    void Update()
    {
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
