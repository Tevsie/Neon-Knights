using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of enemy movement
    public float minimumDistance = 2f; // Minimum distance to maintain between enemies
    public Vector3 targetPoint; // Point outside the game scene where enemies will move if no players are present

    private GameObject[] player1Objects; // Array to store player1 GameObjects
    private GameObject[] player2Objects; // Array to store player2 GameObjects

    void Start()
    {
        // Find all GameObjects tagged as "Player1" and "Player2" in the scene
        UpdatePlayerArrays();
    }

    void Update()
    {
        // Update the player arrays if necessary
        UpdatePlayerArrays();

        // Find the nearest player
        GameObject nearestPlayer = FindNearestPlayer();

        // If a nearest player is found, move toward it
        if (nearestPlayer != null)
        {
            // Calculate direction towards the player
            Vector3 direction = (nearestPlayer.transform.position - transform.position).normalized;

            // Ignore the Z component to move only along the X and Y axes
            direction.z = 0f;

            // Check if there's an obstacle in the way
            if (!IsObstacleInWay(direction))
            {
                // Move the enemy towards the player
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
        else
        {
            // Move towards the target point outside the game scene
            Vector3 directionToTarget = (targetPoint - transform.position).normalized;
            transform.Translate(directionToTarget * speed * Time.deltaTime);
        }

        // Ensure that the enemy's Z position is always 0
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    void UpdatePlayerArrays()
    {
        // Find all GameObjects tagged as "Player1" and "Player2" in the scene
        player1Objects = GameObject.FindGameObjectsWithTag("Player1");
        player2Objects = GameObject.FindGameObjectsWithTag("Player2");
    }

    GameObject FindNearestPlayer()
    {
        GameObject nearestPlayer = null;
        float minDistance = Mathf.Infinity;

        // Iterate through all player1 GameObjects and find the nearest one
        foreach (GameObject player in player1Objects)
        {
            if (player != null)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPlayer = player;
                }
            }
        }

        // Iterate through all player2 GameObjects and find the nearest one
        foreach (GameObject player in player2Objects)
        {
            if (player != null)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPlayer = player;
                }
            }
        }

        return nearestPlayer;
    }

    bool IsObstacleInWay(Vector3 direction)
    {
        RaycastHit2D hit;
        // Cast a ray to check for obstacles in the specified direction
        hit = Physics2D.Raycast(transform.position, direction, minimumDistance);
        if (hit.collider != null)
        {
            // If an obstacle is found, return true
            if (hit.collider.CompareTag("Enemy"))
            {
                return true;
            }
        }
        return false;
    }
}
