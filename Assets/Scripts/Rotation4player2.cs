using UnityEngine;

public class Rotation4player2 : MonoBehaviour
{
    public float rotationSpeed = 1000f; // Object rotation speed

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal2");
        float verticalInput = Input.GetAxis("Vertical2");

        RotateWithGamepadStick(horizontalInput, verticalInput);
    }

    void RotateWithGamepadStick(float horizontal, float vertical)
    {
        Vector3 stickDirection = new Vector3(horizontal, vertical, 0f);

        if (stickDirection != Vector3.zero)
        {
            // Calculate the rotation angle based on input data considering the Y axis
            float angle = Mathf.Atan2(stickDirection.x, stickDirection.y) * Mathf.Rad2Deg;

            // Create a quaternion for rotating the object around the Z axis
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, -angle);

            // Rotate the object towards the specified angle without using Slerp
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
