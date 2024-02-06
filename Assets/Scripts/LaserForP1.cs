using UnityEngine;
using System.Collections;

public class LaserForP1 : MonoBehaviour
{
    public GameObject laserCenter;       // Laser object
    public Transform playerPosition;    // Player object
    public GameObject playerRotation;   // Player rotation object
    public float rotationAngle = 90f;   // Rotation angle when activating the Laser object
    public float rotationSpeed = 45f;   // Laser object rotation speed
    public AudioClip laserSound;        // Sound effect for the laser
    public GameObject extraPrefab;      // Extra prefab to instantiate

    private Quaternion initialRotation;  // Initial rotation of the Laser object
    private bool isRotating = false;     // Flag to check if rotation is in progress
    private AudioSource audioSource;     // Reference to the AudioSource component
    private GameObject extraPrefabInstance; // Instance of the extra prefab

    void Start()
    {
        // Save the initial rotation of the Laser object
        initialRotation = laserCenter.transform.rotation;

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If no AudioSource is found, add one to this GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRotating)  // Check for left mouse button press and no ongoing rotation
        {
            initialRotation = playerRotation.transform.rotation;
            ActivateLaser();

            // Instantiate the extra prefab
            extraPrefabInstance = Instantiate(extraPrefab, playerPosition.position, Quaternion.identity);

            // Play the laser sound effect
            if (laserSound != null)
            {
                audioSource.PlayOneShot(laserSound);
                StartCoroutine(DestroyExtraPrefab(extraPrefabInstance, laserSound.length));
            }
        }

        if (extraPrefabInstance != null)
        {
            // Update the position of the extra prefab to match the player's position
            extraPrefabInstance.transform.position = playerPosition.position;
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

    IEnumerator DestroyExtraPrefab(GameObject extraPrefabInstance, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (extraPrefabInstance != null)
        {
            Destroy(extraPrefabInstance);
        }
    }
}
