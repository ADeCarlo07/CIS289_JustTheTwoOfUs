using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.DefaultInputActions;

public class PlayerController_Level02Special : MonoBehaviour
{
    private Vector2 movementInput;
    private Rigidbody2D rb;
    private PlayerActions playerActions;
    private PlayerInput playerInput;
    private Animator animator;
    public float speed = 4f;
    public float swimForce = 4f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerActions = new PlayerActions();
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Swim"].WasPressedThisFrame())
        {
            animator.SetTrigger("PushUp");
            Debug.Log("Player wants to swim");
           
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, swimForce);
        }
    }

    private void FixedUpdate()
    {
        movementInput = playerActions.Swimming_Map.Movement.ReadValue<Vector2>();

        float currentYVelocity = rb.linearVelocityY;
        rb.linearVelocity = new Vector2(movementInput.x * speed, currentYVelocity);

    }
    private void OnEnable()
    {

        playerActions.Swimming_Map.Enable();

    }

    private void OnDisable()
    {
        playerActions.Swimming_Map.Disable();
    }

 

}
