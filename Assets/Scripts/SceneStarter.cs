using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneStarter : MonoBehaviour
{
    // Method called when the button is pressed
    public void StartGame()
    {
        // Start the loading process
        StartCoroutine(LoadScenes());
    }

    // Coroutine to load the game scenes
    private IEnumerator LoadScenes()
    {
        // Disable objects in the start scene
        DisableObjectsInStartScene();

        // Load the main game scene
        SceneManager.LoadScene("scene_demo", LoadSceneMode.Additive);

        // Load the second scene (e.g., background)
        //SceneManager.LoadScene("scene_background", LoadSceneMode.Additive);

        // Wait for a short time before disabling objects in the start scene
        yield return new WaitForSeconds(0.1f);

        // Disable objects in the start scene again (just in case)
        DisableObjectsInStartScene();
    }

    // Disable objects in the start scene
    private void DisableObjectsInStartScene()
    {
        Scene startScene = SceneManager.GetSceneByName("scene_start");
        if (startScene.IsValid())
        {
            GameObject[] objectsInStartScene = startScene.GetRootGameObjects();
            foreach (GameObject obj in objectsInStartScene)
            {
                obj.SetActive(false);
            }
        }
    }
}
