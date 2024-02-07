using UnityEngine;

public class Rotation4player1 : MonoBehaviour
{
    void Update()
    {
        // Get the current mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure that the z-coordinate is 0 (screen plane)

        // Calculate the direction of the cursor relative to the current object position
        Vector3 lookDirection = mousePosition - transform.position;

        // Calculate the angle between the cursor direction and the right direction of the square
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // Apply a rotation to the square so that its right side faces the cursor
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
    }
}
