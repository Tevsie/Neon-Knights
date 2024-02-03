using UnityEngine;

public class Movement4player2 : MonoBehaviour
{
    public float moveSpeed = 5f;  // �������� ����������� ���������

    void Update()
    {
        // �������� ������� ������ �� �������������� � ������������ ����
        float horizontalInput = Input.GetAxis("Horizontal1");
        float verticalInput = Input.GetAxis("Vertical1");

        // �������� ������� ��� ����������� ���������
        MovePlayer(horizontalInput, verticalInput);
    }

    void MovePlayer(float horizontal, float vertical)
    {
        // ��������� ������ �������� �� ������ ������� ������
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        // ��������� ����������� � ���������� ������� ���������
        transform.Translate(movement, Space.World);
    }
}

