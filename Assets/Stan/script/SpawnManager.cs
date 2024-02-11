using UnityEngine;

[System.Serializable]
public class EnemySpawnInfo
{
    public GameObject enemyPrefab; 
    public float spawnRate; 
}

public class SpawnManager : MonoBehaviour
{
    public EnemySpawnInfo[] enemySpawnInfo; 
    public float spawnInterval = 2f; 
    public int maxEnemiesPerSpawnPoint = 5; 
    public int minEnemiesToSpawn = 2; 
    public int maxTotalEnemies = 50; 

    public Transform[] spawnPoints; 
    public Transform parentObject; // Parent GameObject for the spawned enemies

    private int currentEnemies = 0; 

    void Start()
    {
        // Start spawning enemies
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Function to spawn enemies
    void SpawnEnemy()
    {
        // Check if the maximum number of enemies has been reached
        if (currentEnemies < maxTotalEnemies)
        {
            // Loop through each spawn point
            foreach (Transform spawnPoint in spawnPoints)
            {
                // Determine the number of enemies to spawn this interval (minimum to maximum)
                int enemiesToSpawn = Random.Range(minEnemiesToSpawn, maxEnemiesPerSpawnPoint + 1);

                for (int i = 0; i < enemiesToSpawn; i++)
                {
                    // Loop through each enemy spawn info
                    foreach (EnemySpawnInfo info in enemySpawnInfo)
                    {
                        // Calculate the chance to spawn this enemy type in the current interval
                        float spawnChance = info.spawnRate / spawnInterval;

                        // If the random value is less than the spawn chance, spawn the enemy
                        if (Random.value < spawnChance && currentEnemies < maxTotalEnemies)
                        {
                            // Instantiate the selected enemy prefab at the randomized position
                            GameObject enemyInstance = Instantiate(info.enemyPrefab, spawnPoint.position, Quaternion.identity);

                            // Set the parent of the instantiated enemy to the parentObject
                            if (parentObject != null)
                            {
                                enemyInstance.transform.parent = parentObject;
                            }

                            currentEnemies++; // Increment the current number of enemies
                        }
                    }
                }
            }
        }
    }

    // Function to decrease the current number of enemies
    public void DecreaseEnemyCount()
    {
        currentEnemies--;
    }
}