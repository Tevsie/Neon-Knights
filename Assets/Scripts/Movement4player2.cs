using UnityEngine;

public class Movement4player2 : MonoBehaviour
{
    public float moveSpeed = 5f;  // Character movement speed

    void Update()
    {
        // Get input data for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal1");
        float verticalInput = Input.GetAxis("Vertical1");

        // Call the function to move the character
        MovePlayer(horizontalInput, verticalInput);
    }

    void MovePlayer(float horizontal, float vertical)
    {
        // Calculate the movement vector based on input data
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        // Apply movement to the global position of the character
        transform.Translate(movement, Space.World);
    }
}

