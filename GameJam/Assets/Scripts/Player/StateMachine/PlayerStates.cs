using UnityEngine;

class IdleState: AbstractPlayerState
{
    public IdleState(PlayerStateMachine sm) : base(sm) { }
    public override void Enter() => _stateMachine.Player.Animator.SetBool("Idle", true);
    public override void Exit() => _stateMachine.Player.Animator.SetBool("Idle", false);
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
    public override void Enter() => _stateMachine.Player.Animator.SetBool("Walk", true);
    public override void Exit() => _stateMachine.Player.Animator.SetBool("Walk", false);
    public override void PhysicsUpdate() {
        var rb = _stateMachine.Player.Rigidbody; 
        Vector2 normalizedInput = _stateMachine.Player.MoveInput.normalized;
        
        rb.linearVelocity = normalizedInput * _stateMachine.Player.moveSpeed;
        _stateMachine.Player.SetFacingDirection(normalizedInput);
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
    private float interactTimer;
    private float interactDuration = 3f;
    public EatState(PlayerStateMachine sm) : base(sm) { }

    public override void Enter()
    {
        if (_stateMachine.Player.TryEat()) _stateMachine.Player.Animator.SetTrigger("Eat");
        else
        {
            if (_stateMachine.Player.MoveInput.sqrMagnitude > 0.01f)
                _stateMachine.ChangeState(new WalkState(_stateMachine));
            else
                _stateMachine.ChangeState(new IdleState(_stateMachine));
        }
        
    }

    public override void LogicUpdate()
    {
        interactTimer += Time.deltaTime;

        if (interactTimer >= interactDuration)
        {
            if (_stateMachine.Player.MoveInput.sqrMagnitude > 0.01f)
                _stateMachine.ChangeState(new WalkState(_stateMachine));
            else
                _stateMachine.ChangeState(new IdleState(_stateMachine));
        }
    }
    public override void PhysicsUpdate() {
        var rb = _stateMachine.Player.Rigidbody; 
        rb.linearVelocity = Vector2.zero;
    }
}

class DialogState: AbstractPlayerState
{
    public DialogState(PlayerStateMachine sm) : base(sm) { }
    public override void Enter() => _stateMachine.Player.Animator.SetBool("Idle", true);
    public override void Exit() => _stateMachine.Player.Animator.SetBool("Idle", false);
    public override void PhysicsUpdate() {
        var rb = _stateMachine.Player.Rigidbody; 
        rb.linearVelocity = Vector2.zero;
    }
    public override void LogicUpdate() {
        if (!_stateMachine.Player.InDialog) _stateMachine.ChangeState(new IdleState(_stateMachine));
    }
}