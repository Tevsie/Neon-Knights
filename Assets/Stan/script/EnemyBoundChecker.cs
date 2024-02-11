using UnityEngine;

public class EnemyBoundChecker : MonoBehaviour
{
    private Camera mainCamera;
    public float screenBoundMargin = 0.1f; // Margin to expand the screen bounds

    private bool withinScreenBounds = false;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure there is a camera tagged as 'MainCamera' in the scene.");
        }
    }

    void Update()
    {
        if (mainCamera == null)
            return;

        // Calculate screen bounds with margin
        float minX = 0 - screenBoundMargin;
        float maxX = 1 + screenBoundMargin;
        float minY = 0 - screenBoundMargin;
        float maxY = 1 + screenBoundMargin;

        // Check if the enemy is within the expanded screen bounds
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        withinScreenBounds = screenPoint.x >= minX && screenPoint.x <= maxX &&
                             screenPoint.y >= minY && screenPoint.y <= maxY;
    }

    public bool IsWithinScreenBounds()
    {
        return withinScreenBounds;
    }
}
