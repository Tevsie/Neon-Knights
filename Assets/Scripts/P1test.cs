using UnityEngine;

public class RotateAndMoveObject : MonoBehaviour
{
    public float rotationSpeed = 5f; // �������� �������� �������
    public float movementSpeed = 5f; // �������� ����������� ������� �� ���������

    void Update()
    {
        // �������� ������� ������ �� �������������� � ������������ ����
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ��������� �������� �������
        Rotate(horizontalInput);

        // ��������� ����������� ������� �� ���������
        Move(verticalInput);
    }

    void Rotate(float input)
    {
        // ���������� ���� �������� �� ������ ������� ������
        float rotationAmount = input * rotationSpeed * Time.deltaTime;

        // ������� ���������� ��� �������� ������ ��� Z
        Quaternion deltaRotation = Quaternion.Euler(0f, 0f, rotationAmount);

        // ��������� �������� � �������
        transform.rotation *= deltaRotation;
    }

    void Move(float input)
    {
        // ���������� ���������� ��� ����������� �� ������ ������� ������
        float movementDistance = input * movementSpeed * Time.deltaTime;

        // ���������� ������ �� ���������
        transform.Translate(Vector3.up * movementDistance);
    }
}
