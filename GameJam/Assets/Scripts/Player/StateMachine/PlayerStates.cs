using UnityEngine;

class IdleState: AbstractPlayerState
{
    public IdleState(PlayerStateMachine sm) : base(sm) { }
    //public override void Enter() => _stateMachine.Player.Animator.SetTrigger("Idle");
    public override void PhysicsUpdate() {
        var rb = _stateMachine.Player.Rigidbody; 
        rb.linearVelocity = Vector2.zero;
    }
    public override void LogicUpdate() {
        if (_stateMachine.Player.MoveInput.sqrMagnitude >= 0.01f) _stateMachine.ChangeState(new WalkState(_stateMachine));
    }
}

class WalkState: AbstractPlayerState
{
    public WalkState(PlayerStateMachine sm) : base(sm) { }
    //public override void Enter() => _stateMachine.Player.Animator.SetBool("Walk", true);
    //public override void Exit() => _stateMachine.Player.Animator.SetBool("Walk", false);
    public override void PhysicsUpdate() {
        var rb = _stateMachine.Player.Rigidbody; 
        Vector2 normalizedInput = _stateMachine.Player.MoveInput.normalized;
        
        rb.linearVelocity = normalizedInput * _stateMachine.Player.moveSpeed;
    }
    public override void LogicUpdate() {
        if (_stateMachine.Player.MoveInput.sqrMagnitude <= 0.01f) _stateMachine.ChangeState(new IdleState(_stateMachine));
    }
}

class InteractState: AbstractPlayerState
{
    public InteractState(PlayerStateMachine sm) : base(sm) { }
    public override void Enter() => _stateMachine.Player.TryInteract();
    public override void PhysicsUpdate() {
        var rb = _stateMachine.Player.Rigidbody; 
        rb.linearVelocity = Vector2.zero;
    }
    public override void LogicUpdate() {
        _stateMachine.ChangeState(new IdleState(_stateMachine));
    }
}

class EatState: AbstractPlayerState
{
    public EatState(PlayerStateMachine sm) : base(sm) { }
    public override void Enter() => _stateMachine.Player.TryEat();
    public override void PhysicsUpdate() {
        var rb = _stateMachine.Player.Rigidbody; 
        rb.linearVelocity = Vector2.zero;
    }
    public override void LogicUpdate() {
        _stateMachine.ChangeState(new IdleState(_stateMachine));
    }
}