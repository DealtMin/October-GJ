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
    public virtual void AnimationUpdate()
    {
        _stateMachine.Player.Animator.SetFloat("UpDown", _stateMachine.Player.FacingDirection.y);
        _stateMachine.Player.Animator.SetFloat("IsSide", _stateMachine.Player.FacingDirection.x);
    }
    public abstract void LogicUpdate(); 
    public abstract void PhysicsUpdate();
}