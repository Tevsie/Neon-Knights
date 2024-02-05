using UnityEngine;

public class BackgroundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Start playing the background music
        audioSource.Play();
    }

    // You can add more methods here to control the background music playback as needed
}
