using UnityEngine;

public class RotateAndMoveObject : MonoBehaviour
{
    public float rotationSpeed = 5f; // Скорость вращения объекта
    public float movementSpeed = 5f; // Скорость перемещения объекта по вертикали

    void Update()
    {
        // Получаем входные данные по горизонтальной и вертикальной осям
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Выполняем вращение объекта
        Rotate(horizontalInput);

        // Выполняем перемещение объекта по вертикали
        Move(verticalInput);
    }

    void Rotate(float input)
    {
        // Определяем угол вращения на основе входных данных
        float rotationAmount = input * rotationSpeed * Time.deltaTime;

        // Создаем кватернион для вращения вокруг оси Z
        Quaternion deltaRotation = Quaternion.Euler(0f, 0f, rotationAmount);

        // Применяем вращение к объекту
        transform.rotation *= deltaRotation;
    }

    void Move(float input)
    {
        // Определяем расстояние для перемещения на основе входных данных
        float movementDistance = input * movementSpeed * Time.deltaTime;

        // Перемещаем объект по вертикали
        transform.Translate(Vector3.up * movementDistance);
    }
}
