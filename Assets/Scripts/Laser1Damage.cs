using UnityEngine;

public class Laser1Damage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player2
        if (other.CompareTag("Player2"))
        {
            // �������� ����� Die() �� ���������� PlayerHealth
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // ���������, ��� playerHealth �� ����� null
            if (playerHealth != null)
            {
                // ��������� �������� ������ 2
                playerHealth.healthP2--;

                // ������� �������� � ������� (��� ������)
                Debug.Log("Player 2 hit. Health: " + playerHealth.healthP2);

                // ���������, ���� �������� ������ 2 ������ ��� ����� 0, �������� ����� Die()
                if (playerHealth.healthP2 <= 0)
                {
                    Debug.Log("dead");
                }
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            // ���������� ������ �����
            Destroy(other.gameObject);
        }
    }
}
