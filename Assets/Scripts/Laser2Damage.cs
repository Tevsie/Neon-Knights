using UnityEngine;

public class Laser2Damage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player1
        if (other.CompareTag("Player1"))
        {
            // �������� ����� Die() �� ���������� PlayerHealth
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // ���������, ��� playerHealth �� ����� null
            if (playerHealth != null)
            {
                // ��������� �������� ������ 1
                playerHealth.healthP1--;

                // ������� �������� � ������� (��� ������)
                Debug.Log("Player 1 hit. Health: " + playerHealth.healthP1);

                // ���������, ���� �������� ������ 1 ������ ��� ����� 0, �������� ����� Die()
                if (playerHealth.healthP1 <= 0)
                {
                    Debug.Log("dead");
                }
            }
        }
    }
}