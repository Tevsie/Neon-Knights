using UnityEngine;
using System.Collections;

public class LaserForP2 : MonoBehaviour
{
    public GameObject laserCenter1;  
    public Transform playerPosition1; 
    public GameObject playerRotation1; 
    public float rotationAngle1 = 90f;  
    public float rotationSpeed1 = 45f;  
    public AudioClip laserSound1;
    public GameObject extraPrefab1;
    public string gamepadButton = "Fire2";
    public float swordCooldown1 = 3f; // Cooldown

    private Quaternion initialRotation;  
    private bool isRotating = false; 
    private AudioSource audioSource;
    private GameObject extraPrefabInstance;

    void Start()
    {
        // Save the initial rotation of the Laser object
        initialRotation = laserCenter1.transform.rotation;

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
        if (Input.GetButtonDown(gamepadButton) && !isRotating)  // Check for the specified gamepad button press and no ongoing rotation
        {
            initialRotation = playerRotation1.transform.rotation * Quaternion.Euler(0, 0, 90);
            ActivateLaser1();

            extraPrefabInstance = Instantiate(extraPrefab1, playerPosition1.position, Quaternion.identity);

            if (laserSound1 != null)
            {
                audioSource.PlayOneShot(laserSound1);
                StartCoroutine(DestroyExtraPrefab1(extraPrefabInstance, laserSound1.length));  
            }
        }

        // Update the position of the extra prefab to match the player's position
        if (extraPrefabInstance != null && playerPosition1 != null)
        {
            extraPrefabInstance.transform.position = playerPosition1.position;
        }

        laserCenter1.transform.position = playerPosition1.position;

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

        yield return new WaitForSeconds(swordCooldown1);

        // Reset the flag to indicate that rotation is complete
        isRotating = false;
    }

    void DeactivateLaser1()
    {
        laserCenter1.SetActive(false);
    }

    IEnumerator DestroyExtraPrefab1(GameObject extraPrefabInstance, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (extraPrefabInstance != null)
        {
            Destroy(extraPrefabInstance);
        }
    }
}
