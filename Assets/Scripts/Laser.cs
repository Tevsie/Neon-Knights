using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public GameObject laserCenter;   // Laser object
    public Transform playerPosition; // Player object
    public GameObject playerRotation; // Player rotation object
    public float rotationAngle = 90f;  // Rotation angle when activating the Laser object
    public float rotationSpeed = 45f;  // Laser object rotation speed

    private Quaternion initialRotation;  // Initial rotation of the Laser object
    private bool isRotating = false;    // Flag to check if rotation is in progress

    void Start()
    {
        // Save the initial rotation of the Laser object
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRotating)  // Check for left mouse button press and no ongoing rotation
        {
            initialRotation = playerRotation.transform.rotation;
            ActivateLaser();
        }

        // Set the position and rotation of the Laser object to match the Player's position and rotation
        laserCenter.transform.position = playerPosition.position;
        //laserCenter.transform.rotation = playerPosition.rotation;
    }

    void ActivateLaser()
    {
        // Set the flag to indicate that rotation is in progress
        isRotating = true;

        // Activate the Laser object (if it was inactive)
        laserCenter.SetActive(true);

        // Start the coroutine for gradual rotation of the Laser object
        StartCoroutine(LaserCoroutine());
    }

    IEnumerator LaserCoroutine()
    {
        laserCenter.transform.rotation = initialRotation;

        // Additional rotation around the Z-axis
        laserCenter.transform.Rotate(Vector3.forward, rotationAngle / 2f);

        float currentRotation = 0f;

        while (currentRotation < rotationAngle)
        {
            // Rotate the Laser object with negative rotation speed
            laserCenter.transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

            currentRotation += rotationSpeed * Time.deltaTime;

            yield return null;
        }

        // Deactivate the Laser object after rotation and returning to the initial position
        DeactivateLaser();

        // Reset the flag to indicate that rotation is complete
        isRotating = false;
    }

    void DeactivateLaser()
    {
        laserCenter.SetActive(false);
    }
}
