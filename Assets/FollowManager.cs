using UnityEngine;

public class FollowPlayers : MonoBehaviour
{
    public Transform player1; // Reference to the first player's Transform
    public Transform player2; // Reference to the second player's Transform

    public GameObject prefabToFollow1; // Reference to the first prefab to be followed
    public GameObject prefabToFollow2; // Reference to the second prefab to be followed

    public Vector3 offset1 = new Vector3(0f, 1f, 0f); // Offset for the first prefab to follow
    public Vector3 offset2 = new Vector3(0f, 1f, 0f); // Offset for the second prefab to follow

    void Update()
    {
        if (player1 != null && prefabToFollow1 != null)
        {
            // Set the position of the first prefab to follow the first player's position with offset
            prefabToFollow1.transform.position = player1.transform.position + offset1;
        }

        if (player2 != null && prefabToFollow2 != null)
        {
            // Set the position of the second prefab to follow the second player's position with offset
            prefabToFollow2.transform.position = player2.transform.position + offset2;
        }
    }
}
