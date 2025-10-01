using Unity.Cinemachine;
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
    public Material material;
    public CinemachineCamera cam;
    public GameObject circleCollider;
    public float vertexOfParabola;
    public GameManager gameManager;
    public GameObject follower;
    


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
        Vector3 position = circleCollider.transform.position;
        position.x = this.transform.position.x;
        circleCollider.transform.position = position;
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

        material.SetFloat("_PlayerOffset", this.transform.position.x);
      
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
        animator.SetInteger("VertVel", (int)rb.linearVelocity.y);

    }
    private void OnApplicationQuit()
    {
        material.SetFloat("_PlayerOffset", 0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager.setTargetPlayer(this.gameObject);
        gameManager.setOtherPlayer(otherCharacter);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (movementInput.x != 0)
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
            gameManager.setTargetPlayer(otherCharacter);
            gameManager.setOtherPlayer(this.gameObject);

            Debug.Log("Switch players");
            currentSpeed = 0f;
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.GetComponent<RotateWithCurve>().enabled = true;
            this.GetComponent<PlayerController>().enabled = false;

            gameManager.setMustMoveCamera(true);


            //Debug.Log("Switch players");
            //currentSpeed = 0f;
            //rb.gravityScale = 0;
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //this.GetComponent<RotateWithCurve>().enabled = true;
            //this.GetComponent<PlayerController>().enabled = false;

           

            //otherCharacter.GetComponent<RotateWithCurve>().enabled = false;
            //otherCharacter.GetComponent<Rigidbody2D>().gravityScale = 1;
            //otherCharacter.GetComponent<PlayerController>().enabled = true;
            //otherCharacter.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            //otherCharacter.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            //otherCharacter.transform.rotation = Quaternion.Euler(0, 0, 0);
            //Vector3 pos = otherCharacter.transform.position;
            //pos.y = vertexOfParabola;
            //otherCharacter.transform.position = pos;

            gameManager.setCanActivateOtherCharacter(false);
            
            


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
