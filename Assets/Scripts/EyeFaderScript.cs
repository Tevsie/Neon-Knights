using System.Collections;
using UnityEngine;

public class EyeFaderScript : MonoBehaviour
{
    public Material mat;
    public string shaderVarRef;
    public float shaderVarRate = 0.1f;

    // Coroutine to fade out the eye effect
    public IEnumerator FadeOutEyes()
    {
        float currentValue = mat.GetFloat(shaderVarRef);

        // Animate until reaching fully transparent
        while (currentValue > 0f)
        {
            currentValue -= shaderVarRate;
            mat.SetFloat(shaderVarRef, currentValue);
            yield return null; // Wait for the next frame
        }
    }

    // Coroutine to fade in the eye effect
    public IEnumerator FadeInEyes()
    {
        float currentValue = mat.GetFloat(shaderVarRef);

        // Animate until reaching fully opaque
        while (currentValue < 1f)
        {
            currentValue += shaderVarRate;
            mat.SetFloat(shaderVarRef, currentValue);
            yield return null; // Wait for the next frame
        }
    }
}
