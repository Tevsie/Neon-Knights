using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed; 
    public Vector3 targetPoint; // Point outside the game scene where enemies will move if no players are present

    private GameObject[] player1Objects;
    private GameObject[] player2Objects;

    void Start()
    {
        UpdatePlayerArrays();
    }

    void Update()
    {
        UpdatePlayerArrays();

        GameObject nearestPlayer = FindNearestPlayer();

        if (nearestPlayer != null)
        {
            // Calculate direction towards the player in world space
            Vector3 direction = (nearestPlayer.transform.position - transform.position).normalized;

            // Convert the direction to local space
            Vector3 localDirection = transform.InverseTransformDirection(direction);

            // Ignore the Z component to move only along the X and Y axes
            localDirection.z = 0f;

            // Move the enemy towards the player
            transform.Translate(localDirection * speed * Time.deltaTime);
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
}
