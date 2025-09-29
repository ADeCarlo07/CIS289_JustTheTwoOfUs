using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    private float currentSpeed;
    private PlayerActions playerActions;
    private Vector2 movementInput;
    private PlayerInput playerInput;
    public GameObject otherCharacter;
    private Animator animator;
    private bool isRunning;
    public float jumpForce = 12f;
    private bool isGrounded;
    public LayerMask groundLayer;
    private bool jumpRequested;
    public Transform groundCheck;
    private string nameOfCharacter;


    private void Awake()
    {
        playerActions = new PlayerActions();
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerActions.Action_Map.Enable();
       
    }

    private void OnDisable()
    {
        playerActions.Action_Map.Disable();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        Run();

        //ternary operator, saying if we are running current speed is run speed
        //and if we aren't its walkspeed
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        //reading and storing the input
        movementInput = playerActions.Action_Map.Movement.ReadValue<Vector2>();

        float currentYVelocity = rb.linearVelocityY;
        rb.linearVelocity = new Vector2 (movementInput.x * currentSpeed, currentYVelocity);

      
        //checking to see if player can jump and letting them jump
        if (isGrounded && jumpRequested)
        {
            animator.SetTrigger("Jump");
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpRequested = false;
        }
    

        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
        animator.SetInteger("VertVel", (int)rb.linearVelocity.y);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameOfCharacter = gameObject.name;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementInput.x != 0)
        {
            //flips entire gameObject by inverting its x scale
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(movementInput.x) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }


        switchCharacters();

        if (playerInput.actions["Jump"].WasPressedThisFrame() && isGrounded)
        {
            jumpRequested = true;
        }

        animator.SetBool("IsGrounded", isGrounded);
        
    }

    private void switchCharacters()
    {
        if(playerInput.actions["SwitchPlayer"].WasPressedThisFrame())
        {
            Debug.Log("Switch players");
            currentSpeed = 0f;
            this.GetComponent<PlayerController>().enabled = false;
            otherCharacter.GetComponent<PlayerController>().enabled = true;

        }
        
    }
    
    private void Run()
    {
        if (playerInput.actions["Run"].IsPressed())
        {
            Debug.Log("Player is running");
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    

}
