using UnityEngine;

public class PlayerActiveState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine player)
    {
        Debug.Log("Hello from the other side");
    }
    public override void UpdateState(PlayerStateMachine player)
    {
        // player.SwitchState(player.CooldownState);
    }
    public override void OnCollisionEnter(PlayerStateMachine player)
    {

    }
}
