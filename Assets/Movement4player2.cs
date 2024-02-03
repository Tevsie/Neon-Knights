using UnityEngine;

public class Movement4player2 : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость перемещения персонажа

    void Update()
    {
        // Получаем входные данные по горизонтальной и вертикальной осям
        float horizontalInput = Input.GetAxis("Horizontal1");
        float verticalInput = Input.GetAxis("Vertical1");

        // Вызываем функцию для перемещения персонажа
        MovePlayer(horizontalInput, verticalInput);
    }

    void MovePlayer(float horizontal, float vertical)
    {
        // Вычисляем вектор движения на основе входных данных
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        // Применяем перемещение к глобальной позиции персонажа
        transform.Translate(movement, Space.World);
    }
}

