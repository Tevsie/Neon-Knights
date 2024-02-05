using UnityEngine;

public class Laser1Damage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player2
        if (other.CompareTag("Player2"))
        {
            // Вызываем метод Die() из компонента PlayerHealth
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Проверяем, что playerHealth не равен null
            if (playerHealth != null)
            {
                // Уменьшаем здоровье игрока 2
                playerHealth.healthP2--;

                // Выводим здоровье в консоль (для дебага)
                Debug.Log("Player 2 hit. Health: " + playerHealth.healthP2);

                // Проверяем, если здоровье игрока 2 меньше или равно 0, вызываем метод Die()
                if (playerHealth.healthP2 <= 0)
                {
                    Debug.Log("dead");
                }
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            // Уничтожаем объект врага
            Destroy(other.gameObject);
        }
    }
}
