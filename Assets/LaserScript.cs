using System.Collections;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public float laserDuration = 2.0f; // Set the duration in seconds

    void Start()
    {
        DisableLaser();
    }

    void Update()
    {
        // Change here the input
        if (Input.GetButton("Fire1"))
        {
            EnableLaser();
            StartCoroutine(DeactivateLaserAfterDelay());
        }
    }

    private void EnableLaser()
    {
        lineRenderer.enabled = true;
    }

    private void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

    private IEnumerator DeactivateLaserAfterDelay()
    {
        yield return new WaitForSeconds(laserDuration);
        DisableLaser();
    }
}

