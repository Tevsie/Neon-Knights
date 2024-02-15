using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject objectToToggle1;
    public GameObject objectToToggle2;
    public GameObject objectToToggle3;
    public GameObject objectToToggle4;
    public GameObject additionalObject;
    public AudioSource audioSource;
    public MonoBehaviour[] scriptsToDisable;

    private bool isPaused = false;
    private float originalVolume;

    void Start()
    {
        // Save original volume of the audio source
        originalVolume = audioSource.volume;
    }

    void Update()
    {
        // Check for Esc key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle pause state
            isPaused = !isPaused;

            if (isPaused)
            {
                // Pause the game
                Pause();
                Debug.Log("Game Paused");
            }
            else
            {
                // Unpause the game
                Unpause();
                Debug.Log("Game Unpaused");
            }
        }
    }

    // Pause the game
    private void Pause()
    {
        Time.timeScale = 0; // Stop game time

        // Deactivate objects
        ToggleObjects(false);

        // Disable scripts
        DisableScripts(true);

        // Decrease volume of the audio source
        DecreaseVolume();

        // Activate additional object
        if (additionalObject != null)
        {
            additionalObject.SetActive(true);
        }
    }

    // Unpause the game
    public void Unpause()
    {
        Time.timeScale = 1; // Resume game time

        // Activate objects back
        ToggleObjects(true);

        // Enable scripts
        DisableScripts(false);

        // Restore original volume of the audio source
        RestoreVolume();

        // Deactivate additional object
        if (additionalObject != null)
        {
            additionalObject.SetActive(false);
        }
    }

    // Toggle objects activation
    private void ToggleObjects(bool activate)
    {
        if (objectToToggle1 != null)
        {
            objectToToggle1.SetActive(activate);
        }

        if (objectToToggle2 != null)
        {
            objectToToggle2.SetActive(activate);
        }

        if (objectToToggle3 != null)
        {
            objectToToggle3.SetActive(activate);
        }

        if (objectToToggle4 != null)
        {
            objectToToggle4.SetActive(activate);
        }
    }

    // Disable or enable scripts
    private void DisableScripts(bool disable)
    {
        foreach (var script in scriptsToDisable)
        {
            if (script != null)
            {
                script.enabled = !disable;
            }
        }
    }

    // Decrease volume of the audio source
    private void DecreaseVolume()
    {
        if (audioSource != null)
        {
            audioSource.volume = originalVolume * 0.2f; // Decrease volume to 20%
        }
    }

    // Restore original volume of the audio source
    private void RestoreVolume()
    {
        if (audioSource != null)
        {
            audioSource.volume = originalVolume;
        }
    }
}
