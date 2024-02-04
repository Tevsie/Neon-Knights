using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of enemy movement
    private GameObject[] players; // Array to store player GameObjects

    void Start()
    {
        // Find all GameObjects tagged as "Player" in the scene
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        // If there are no players in the scene, exit the Update method
        if (players.Length == 0)
            return;

        // Find the nearest player
        GameObject nearestPlayer = FindNearestPlayer();

        // If a nearest player is found, move toward it
        if (nearestPlayer != null)
        {
            // Calculate direction towards the player
            Vector3 direction = (nearestPlayer.transform.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    GameObject FindNearestPlayer()
    {
        GameObject nearestPlayer = null;
        float minDistance = Mathf.Infinity;

        // Iterate through all player GameObjects and find the nearest one
        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPlayer = player;
            }
        }

        return nearestPlayer;
    }
}
