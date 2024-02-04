using UnityEngine;

public class Movement4player1 : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость перемещения персонажа

    void Update()
    {
        // Получаем входные данные по горизонтальной и вертикальной осям
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Вызываем функцию для перемещения персонажа
        MovePlayer(horizontalInput, verticalInput);
    }

    void MovePlayer(float horizontal, float vertical)
    {
        // Вычисляем вектор движения на основе входных данных
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        // Применяем перемещение к глобальной позиции персонажа
        transform.Translate(movement, Space.World);

        // Выводим текущую скорость персонажа в консоль (для дебага)
        Debug.Log("Current Speed: " + movement.magnitude / Time.deltaTime);
    }
}
