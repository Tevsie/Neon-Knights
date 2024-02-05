using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 5f;  // ��������� ��������
    public float healthP1;             // �������� ������ 1
    public float healthP2;             // �������� ������ 2

    void Start()
    {
        // ������������� ��������
        healthP1 = startingHealth;
        healthP2 = startingHealth;
    }

    public void TakeDamage(float damage, string playerTag)
    {
        // ����� ��� ��������� �����
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

        // �������� �� ������ (�� ������ ����������� ���� ������)
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
        // ������ ��� ������
        Debug.Log(playerName + " is dead");
    }
}
