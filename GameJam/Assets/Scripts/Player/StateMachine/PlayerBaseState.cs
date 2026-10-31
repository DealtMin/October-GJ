using UnityEngine;

public abstract class AbstractPlayerState
{
    protected PlayerStateMachine _stateMachine;

    public AbstractPlayerState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    //public virtual void HandleInput(Vector2 moveInput) { }
    public abstract void LogicUpdate(); 
    public abstract void PhysicsUpdate();
}