using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string[] sceneNamesToLoad; // Array of scene names to load

    void Start()
    {
        // Loop through the scene names and load each scene
        foreach (string sceneName in sceneNamesToLoad)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
