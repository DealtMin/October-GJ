public class PlayerStateMachine
{
    public AbstractPlayerState CurrentState { get; private set; }
    public PlayerController Player { get; private set; }

    public void Initialize(PlayerController player)
    {
        Player = player;
        CurrentState = new IdleState(this);
        CurrentState.Enter();
    }

    public void ChangeState(AbstractPlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}