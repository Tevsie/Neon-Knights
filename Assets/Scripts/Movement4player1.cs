using UnityEngine;

public class Movement4player1 : MonoBehaviour
{
    public float moveSpeed = 5f;  // �������� ����������� ���������

    void Update()
    {
        // �������� ������� ������ �� �������������� � ������������ ����
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // �������� ������� ��� ����������� ���������
        MovePlayer(horizontalInput, verticalInput);
    }

    void MovePlayer(float horizontal, float vertical)
    {
        // ��������� ������ �������� �� ������ ������� ������
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        // ��������� ����������� � ���������� ������� ���������
        transform.Translate(movement, Space.World);

        // ������� ������� �������� ��������� � ������� (��� ������)
        Debug.Log("Current Speed: " + movement.magnitude / Time.deltaTime);
    }
}
