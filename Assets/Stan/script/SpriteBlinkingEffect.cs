using UnityEngine;
using System.Collections;

public class SpriteBlinkingEffect : MonoBehaviour
{
    public float blinkDuration = 0.5f; // Duration for blinking
    public float blinkInterval = 0.1f; // Interval between each blink

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    void Start()
    {
        // Get the SpriteRenderer component of the current GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartBlinking()
    {
        StartCoroutine(BlinkCoroutine());
    }

    IEnumerator BlinkCoroutine()
    {
        int blinkIterations = Mathf.FloorToInt(blinkDuration / blinkInterval);

        for (int i = 0; i < blinkIterations; i++)
        {
            // Toggle visibility for the SpriteRenderer
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval);

            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
