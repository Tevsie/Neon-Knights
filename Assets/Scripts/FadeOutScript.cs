using System.Collections;
using UnityEngine;

public class FadeOutScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rend;

    [Header("Fade Settings")]
    [SerializeField] private float fadeSpeed = 0.05f; // Speed of the fade

    private Color startColor; // Initial color with only alpha changed

    // Start is called before the first frame update
    void Start()
    {
        if (rend == null)
            rend = GetComponent<SpriteRenderer>();

        startColor = rend.color; // Store the initial color with only alpha changed
        startColor.a = 1f; // Ensure initial alpha is 1 (fully opaque)
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // Target alpha is 0 (fully transparent)

        while (elapsedTime < 1f) // Ensure the fade completes when reaching the target alpha
        {
            float newAlpha = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime);
            rend.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha); // Apply new color with interpolated alpha

            elapsedTime += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        rend.color = targetColor; // Ensure the final alpha is set to the target alpha
    }

    public void StartFadingOut()
    {
        StartCoroutine(FadeOut());
    }

    // Allow modifying the fade speed from the Inspector
    public float FadeSpeed
    {
        get { return fadeSpeed; }
        set { fadeSpeed = value; }
    }
}
