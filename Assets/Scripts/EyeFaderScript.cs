using System.Collections;
using UnityEngine;

public class EyeFaderScript : MonoBehaviour
{
    public Material mat;
    public string shaderVarRef;
    public float shaderVarRate = 0.1f;

    // Start the eye animation
    public void StartEyeAnimation(float goal)
    {
        StartCoroutine(AnimateEyes(goal));
    }

    // Coroutine to animate the eyes
    private IEnumerator AnimateEyes(float goal)
    {
        float valueToAnimate = mat.GetFloat(shaderVarRef);

        // Animate until reaching the goal value
        while (valueToAnimate > goal)
        {
            valueToAnimate -= shaderVarRate;
            mat.SetFloat(shaderVarRef, valueToAnimate);
            yield return null; // Wait for the next frame
        }
    }

    // Coroutine to turn off the eye effect
    public IEnumerator TurnOffEyes()
    {
        mat.SetFloat(shaderVarRef, 0f);
        yield return null;
    }
}
