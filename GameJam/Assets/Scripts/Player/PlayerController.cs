using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    public InputActionAsset inputActions;
    public Rigidbody2D Rigidbody;
    public Animator Animator;
    public float interactDistance = 1.5f;
    public LayerMask interactableLayer;
    public Vector2 FacingDirection { get; private set; } = Vector2.down; 

    public float moveSpeed = 5f;

    public PlayerStateMachine StateMachine { get; private set; }
    public Vector2 MoveInput { get; private set; }
    public bool InteractInput { get; private set; }

    private InputAction moveAction;
    private InputAction eatAction;
    private InputAction interactAction;
    private void Awake()
    {
        InteractInput = false;

        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.gravityScale = 0f; 
        Rigidbody.freezeRotation = true;

        StateMachine = new PlayerStateMachine();
        var playerMap = inputActions.FindActionMap("Player");
        moveAction = playerMap.FindAction("Move");
        interactAction = playerMap.FindAction("Interact");
        eatAction = playerMap.FindAction("Eat");
    }

    public void SetFacingDirection(Vector2 direction)
    {
        if (direction.sqrMagnitude > 0.01f)
        {
            FacingDirection = direction.normalized;
        }
    }

    public void TryInteract()
    {
        Vector2 origin = transform.position;
        
        Vector2 direction = FacingDirection;
        Debug.DrawRay(origin, direction * interactDistance, Color.green, 1f);
        
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, interactDistance, interactableLayer);

        if (hit.collider != null)
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    public void TryEat()
    {
        Vector2 origin = transform.position;
        
        Vector2 direction = FacingDirection;
        Debug.DrawRay(origin, direction * interactDistance, Color.green, 1f);
        
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, interactDistance, interactableLayer);

        if (hit.collider != null)
        {
            IEdible edible = hit.collider.GetComponent<IEdible>();
            if (edible != null)
            {
                edible.Eat();
            }
        }
    }

    private void OnEnable()
    {        
        moveAction.Enable();
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;

        interactAction.Enable();
        interactAction.started += OnInteractPerformed;     

        eatAction.started += OnEatPerformed;
        eatAction.Enable();  
    }

    private void Start()
    {
        StateMachine.Initialize(this);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void OnDisable()
    {
        moveAction.performed -= OnMovePerformed;
        moveAction.canceled -= OnMoveCanceled;
        moveAction.Disable();    

        interactAction.started -= OnInteractPerformed;
        interactAction.Disable();   

        eatAction.started -= OnEatPerformed;
        eatAction.Disable();         
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        StateMachine.ChangeState(new InteractState(StateMachine));
    }

    private void OnEatPerformed(InputAction.CallbackContext context)
    {
        StateMachine.ChangeState(new EatState(StateMachine));
    }
}