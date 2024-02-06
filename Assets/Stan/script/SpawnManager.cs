using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of possible enemy prefabs to spawn
    public float spawnInterval = 2f; // Interval between spawns
    public int maxEnemies = 10; // Maximum number of enemies allowed

    public Transform[] spawnPoints; // Array of spawn points representing different zones
    public Transform parentObject; // Parent GameObject for the spawned enemies

    private int currentEnemies = 0; // Current number of enemies

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning enemies
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Function to spawn enemies
    void SpawnEnemy()
    {
        // Check if the maximum number of enemies has been reached
        if (currentEnemies < maxEnemies)
        {
            // Determine the number of enemies to spawn this interval (2 to 5)
            int enemiesToSpawn = Random.Range(2, 6);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                // Randomly select a spawn point from the array
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Randomly select an enemy prefab from the array
                GameObject selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                // Instantiate the selected enemy prefab at the randomized position
                GameObject enemyInstance = Instantiate(selectedEnemyPrefab, spawnPoint.position, Quaternion.identity);

                // Set the parent of the instantiated enemy to the parentObject
                if (parentObject != null)
                {
                    enemyInstance.transform.parent = parentObject;
                }

                currentEnemies++; // Increment the current number of enemies
            }
        }
    }

    // Function to decrease the current number of enemies
    public void DecreaseEnemyCount()
    {
        currentEnemies--;
    }
}
