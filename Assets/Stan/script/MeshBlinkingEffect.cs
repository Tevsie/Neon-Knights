using UnityEngine;
using System.Collections;

public class MeshBlinkingEffect : MonoBehaviour
{
    public float blinkDuration = 0.5f; // Duration for blinking
    public float blinkInterval = 0.1f; // Interval between each blink

    private Transform[] childTransforms; // Array to store child transforms
    private MeshRenderer[] childRenderers; // Array to store child MeshRenderers

    void Start()
    {
        // Get the transforms and MeshRenderers of all child objects
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
            // Toggle visibility for each MeshRenderer
            ToggleMeshRenderersVisibility(false);
            yield return new WaitForSeconds(blinkInterval);

            ToggleMeshRenderersVisibility(true);
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    // Get all child transforms and MeshRenderers
    private void GetAllChildComponents()
    {
        int childCount = transform.childCount;
        childTransforms = new Transform[childCount];
        childRenderers = new MeshRenderer[childCount];

        for (int i = 0; i < childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            MeshRenderer childRenderer = childTransform.GetComponent<MeshRenderer>();

            if (childRenderer != null)
            {
                childTransforms[i] = childTransform;
                childRenderers[i] = childRenderer;
            }
        }
    }

    // Toggle visibility for all child MeshRenderers
    private void ToggleMeshRenderersVisibility(bool visible)
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
