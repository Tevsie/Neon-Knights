using UnityEngine;

public class ConeSize : MonoBehaviour
{
    public float coneWidth;
    public float coneHeight;

    void Update()
    {
        // ������������� ������� ������� �� ������ coneWidth � coneHeight
        transform.localScale = new Vector3(coneWidth, coneHeight, 1f);
    }
}
