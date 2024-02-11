using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters;

public class LaserForP1 : MonoBehaviour
{
    public GameObject laserCenter;      
    public Transform playerPosition;    
    public GameObject playerRotation;   
    public float rotationAngle = 90f;    
    public float rotationSpeed = 45f;   
    public AudioClip laserSound;        
    public GameObject extraPrefab;      // Muzzle flare prefab
    public float swordCooldown = 3f;    

    private Quaternion initialRotation;  
    private bool isRotating = false;     
    private AudioSource audioSource;     
    private GameObject extraPrefabInstance; // Instance of the extra prefab

    public FadeOutScript fadeOutScript;
    public FadeInScript fadeInScript;
    public EyeFaderScript eyeFaderScript;

    void Start()
    {
        StartCoroutine(eyeFaderScript.FadeInEyes());
        // Save the initial rotation of the Laser object
        initialRotation = laserCenter.transform.rotation;


        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRotating)  // Check for left mouse button press and no ongoing rotation
        {
        initialRotation = playerRotation.transform.rotation * Quaternion.Euler(0, 0, 90);

        ActivateLaser();

            // Instantiate the extra prefab
        extraPrefabInstance = Instantiate(extraPrefab, playerPosition.position, Quaternion.identity);

            if (laserSound != null)
            {
                audioSource.PlayOneShot(laserSound);
                StartCoroutine(DestroyExtraPrefab(extraPrefabInstance, laserSound.length));
            }
        }

        if (extraPrefabInstance != null && playerPosition != null)
        {
            // Update the position of the extra prefab to match the player's position
            extraPrefabInstance.transform.position = playerPosition.position;
        }

        // Set the position and rotation of the Laser object to match the Player's position and rotation
        laserCenter.transform.position = playerPosition.position;
    }

    void ActivateLaser()
    {
        isRotating = true;
        laserCenter.SetActive(true);
        StartCoroutine(LaserCoroutine());
    }

    IEnumerator LaserCoroutine()
    {
        Debug.Log("Blocking sunglasses");
        fadeInScript.StartFadingIn();
        StartCoroutine(eyeFaderScript.FadeOutEyes());

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

        Debug.Log("Reveal coolness");
        fadeOutScript.StartFadingOut();
        yield return new WaitForSeconds(swordCooldown / (4/3)  );

        StartCoroutine(eyeFaderScript.FadeInEyes());
        yield return new WaitForSeconds(swordCooldown / 4 );

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