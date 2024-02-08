using UnityEngine;
using System.Collections;

public class BlinkingDamage : MonoBehaviour
{
    // Coroutine for blinking effect
    public IEnumerator BlinkEffect(GameObject enemy)
    {
        float blinkDuration = 0.5f; // Duration for blinking
        float blinkInterval = 0.1f; // Interval between each blink
        int blinkIterations = Mathf.FloorToInt(blinkDuration / blinkInterval);

        Renderer enemyRenderer = enemy.GetComponent<Renderer>();

        if (enemyRenderer != null)
        {
            for (int i = 0; i < blinkIterations; i++)
            {
                // Toggle visibility for the enemy renderer
                enemyRenderer.enabled = !enemyRenderer.enabled;
                yield return new WaitForSeconds(blinkInterval);
            }

            // Ensure the renderer is visible after blinking
            enemyRenderer.enabled = true;
        }
    }
}
