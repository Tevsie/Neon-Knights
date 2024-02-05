using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 5f;  // Начальное здоровье
    public float healthP1;             // Здоровье игрока 1
    public float healthP2;             // Здоровье игрока 2

    void Start()
    {
        // Инициализация здоровья
        healthP1 = startingHealth;
        healthP2 = startingHealth;
    }

    public void TakeDamage(float damage, string playerTag)
    {
        // Метод для получения урона
        if (playerTag == "Player1")
        {
            healthP1 -= damage;
            Debug.Log("Player 1 Health: " + healthP1);
        }
        else if (playerTag == "Player2")
        {
            healthP2 -= damage;
            Debug.Log("Player 2 Health: " + healthP2);
        }

        // Проверка на смерть (вы можете реализовать свою логику)
        if (healthP1 <= 0f)
        {
            Die("Player1");
        }

        if (healthP2 <= 0f)
        {
            Die("Player2");
        }
    }

    void Die(string playerName)
    {
        // Логика при смерти
        Debug.Log(playerName + " is dead");
    }
}
