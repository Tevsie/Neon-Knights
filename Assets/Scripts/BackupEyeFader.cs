using System.Collections;
using UnityEngine;

public class BackupEyeFader : MonoBehaviour
{
    public Material mat;
    public string shaderVarRef;
    public float shaderVarRate = 0.1f;

    // Start the eye animation
    public void StartEyeAnimation(float goal)
    {
        StartCoroutine(TurnOffEyes());
        StartCoroutine(AnimateEyes(goal));
    }

    // Coroutine to animate the eyes
    private IEnumerator AnimateEyes(float goal)
    {
        float valueToAnimate = mat.GetFloat(shaderVarRef);

        // Animate until reaching the goal value
        while (valueToAnimate < goal)
        {
            valueToAnimate -= shaderVarRate;
            mat.SetFloat(shaderVarRef, valueToAnimate);
            yield return null; // Wait for the next frame
        }
    }

    // Coroutine to turn off the eye effect
    private IEnumerator TurnOffEyes()
    {
        mat.SetFloat(shaderVarRef, 0f);
        yield return null;
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