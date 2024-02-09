using UnityEngine;
using System.Collections;

public class LaserForP2 : MonoBehaviour
{
    public GameObject laserCenter1;   // Laser object
    public Transform playerPosition1; // Player object
    public GameObject playerRotation1; // Player rotation object
    public float rotationAngle1 = 90f;  // Rotation angle when activating the Laser object
    public float rotationSpeed1 = 45f;  // Laser object rotation speed
    public string gamepadButton = "Fire2"; // Gamepad button for activation

    private Quaternion initialRotation;  // Initial rotation of the Laser object
    private bool isRotating = false;    // Flag to check if rotation is in progress

    void Start()
    {
        // Save the initial rotation of the Laser object
    }

    void Update()
    {
        if (Input.GetButtonDown(gamepadButton) && !isRotating)  // Check for the specified gamepad button press and no ongoing rotation
        {
            initialRotation = playerRotation1.transform.rotation;
            ActivateLaser1();
        }

        // Check for null references before accessing transform properties
        if (playerPosition1 != null && laserCenter1 != null)
        {
            // Set the position and rotation of the Laser object to match the Player's position and rotation
            laserCenter1.transform.position = playerPosition1.position;
        }
    }

    void ActivateLaser1()
    {
        // Set the flag to indicate that rotation is in progress
        isRotating = true;

        // Activate the Laser object (if it was inactive)
        laserCenter1.SetActive(true);

        // Start the coroutine for gradual rotation of the Laser object
        StartCoroutine(LaserCoroutine1());
    }

    IEnumerator LaserCoroutine1()
    {
        laserCenter1.transform.rotation = initialRotation;

        // Additional rotation around the Z-axis
        laserCenter1.transform.Rotate(Vector3.forward, rotationAngle1 / 2f);

        float currentRotation = 0f;

        while (currentRotation < rotationAngle1)
        {
            // Rotate the Laser object with negative rotation speed
            laserCenter1.transform.Rotate(Vector3.forward, -rotationSpeed1 * Time.deltaTime);

            currentRotation += rotationSpeed1 * Time.deltaTime;

            yield return null;
        }

        // Deactivate the Laser object after rotation and returning to the initial position
        DeactivateLaser1();

        // Reset the flag to indicate that rotation is complete
        isRotating = false;
    }

    void DeactivateLaser1()
    {
        laserCenter1.SetActive(false);
    }
}
