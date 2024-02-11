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

/*
 * 
 * To call this script from another
 * 
 *public class AnotherScript : MonoBehaviour
{
    public EyeFaderScript eyeFader; // Reference to the EyeFaderScript

    // Example method to trigger eye animation
    public void TriggerEyeAnimation(float goalValue)
    {
        // Call StartEyeAnimation method from EyeFaderScript
        eyeFader.StartEyeAnimation(goalValue);   //The goal is the maximum alpha of the eyes, which is 1
    }
}
*/
