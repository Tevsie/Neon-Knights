using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerBaseState currentState;
    PlayerActiveState ActiveState = new PlayerActiveState();
    PlayerCooldownState CooldownState = new PlayerCooldownState();
    PlayerRespawnState RespawnState = new PlayerRespawnState();
    PlayerLostState LostState = new PlayerLostState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = ActiveState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);

    }
}
