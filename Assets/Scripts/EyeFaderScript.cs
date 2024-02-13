using System.Collections;
using UnityEngine;

public class EyeFaderScript : MonoBehaviour
{
    public Material mat;
    public string shaderVarRef;
    public float shaderVarRate = 0.1f;

    public IEnumerator FadeOutEyes()
    {
        float currentValue = mat.GetFloat(shaderVarRef);

        // Animate until reaching fully transparent
        while (currentValue > 0f)
        {
            currentValue -= shaderVarRate;
            mat.SetFloat(shaderVarRef, currentValue);
            yield return null; 
        }
    }

    public IEnumerator FadeInEyes()
    {
        float currentValue = mat.GetFloat(shaderVarRef);

        // Animate until reaching fully opaque
        while (currentValue < 1f)
        {
            currentValue += shaderVarRate;
            mat.SetFloat(shaderVarRef, currentValue);
            yield return null; 
        }
    }
}

/* At the moment, Stan is retaining mostly the original function of the EyeFaderScript. A BackupEyeFader has been created which is a copy of Gabriel's version.
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
