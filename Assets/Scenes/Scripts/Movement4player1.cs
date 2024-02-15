using UnityEngine;

public class Movement4player1 : MonoBehaviour
{
    // Balancing Parameters
    public BalanceManager balanceManager;
    private float moveSpeed;  

    void Update()
    {
        // Balance Manager handles parameters
        moveSpeed = balanceManager.p1MovementSpeed;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        MovePlayer(horizontalInput, verticalInput);
    }

    void MovePlayer(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        transform.Translate(movement, Space.World);
   }
}
