using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuer : MonoBehaviour
{
    // Method called when the button is pressed
    public void MenuScene()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene by index
        SceneManager.LoadScene(currentSceneIndex);
    }

}
