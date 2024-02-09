using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting;

public class BoundaryManager : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectSide;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z) );
        objectSide = 0.5f;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectSide, screenBounds.x - objectSide);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectSide, screenBounds.y - objectSide);
        transform.position = viewPos;
    }
}
