using UnityEngine;

public class Laser2Damage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player1
        if (other.CompareTag("Player1"))
        {
            // Вызываем метод Die() из компонента PlayerHealth
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Проверяем, что playerHealth не равен null
            if (playerHealth != null)
            {
                // Уменьшаем здоровье игрока 1
                playerHealth.healthP1--;

                // Выводим здоровье в консоль (для дебага)
                Debug.Log("Player 1 hit. Health: " + playerHealth.healthP1);

                // Проверяем, если здоровье игрока 1 меньше или равно 0, вызываем метод Die()
                if (playerHealth.healthP1 <= 0)
                {
                    Debug.Log("dead");
                }
            }
        }
    }
}