using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        // Get the VideoPlayer component on the same GameObject
        videoPlayer = GetComponent<VideoPlayer>();

        // Play the video
        videoPlayer.Play();
    }
}
