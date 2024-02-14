using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D cursorTexture; // Drag your custom cursor texture here in the Unity Editor
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        // Calculate hotspot to be the center of the cursor image
        Vector2 hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        
        // Set custom cursor texture
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
