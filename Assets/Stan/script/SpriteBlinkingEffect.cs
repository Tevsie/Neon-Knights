using UnityEngine;
using System.Collections;

public class SpriteBlinkingEffect : MonoBehaviour
{
    public float blinkDuration = 0.5f; // Duration for blinking
    public float blinkInterval = 0.1f; // Interval between each blink

    private Transform[] childTransforms; // Array to store child transforms
    private SpriteRenderer[] childRenderers; // Array to store child SpriteRenderers

    void Start()
    {
        // Get the transforms and SpriteRenderers of all child objects
        GetAllChildComponents();
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
            // Toggle visibility for each SpriteRenderer
            ToggleSpriteRenderersVisibility(false);
            yield return new WaitForSeconds(blinkInterval);

            ToggleSpriteRenderersVisibility(true);
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    // Get all child transforms and SpriteRenderers
    private void GetAllChildComponents()
    {
        int childCount = transform.childCount;
        childTransforms = new Transform[childCount];
        childRenderers = new SpriteRenderer[childCount];

        for (int i = 0; i < childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            SpriteRenderer childRenderer = childTransform.GetComponent<SpriteRenderer>();

            if (childRenderer != null)
            {
                childTransforms[i] = childTransform;
                childRenderers[i] = childRenderer;
            }
        }
    }

    // Toggle visibility for all child SpriteRenderers
    private void ToggleSpriteRenderersVisibility(bool visible)
    {
        if (childRenderers != null)
        {
            for (int i = 0; i < childRenderers.Length; i++)
            {
                if (childRenderers[i] != null)
                {
                    childRenderers[i].enabled = visible;
                }
            }
        }
    }
}
