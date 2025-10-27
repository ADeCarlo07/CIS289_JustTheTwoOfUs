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
    //public GameManager gameManager;
    public GameObject follower;
    private int maxNumJumps = 1;
    private int numJumps = 0;
    public GameObject spaceDog;
    //certain things aren't needed unless the scene uses my matieral that curves the scene
    public bool curvedScene;


    public GameObject rotateFollowObject;


    private void Awake()
    {
        playerActions = new PlayerActions();
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {

        if (curvedScene)
        {
            rotateFollowObject.GetComponent<HideFollow>().enabled = true;

            foreach (SpriteRenderer sr in rotateFollowObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sr.enabled = false;
            }
        }
       


        playerActions.Action_Map.Enable();
       
    }

    private void OnDisable()
    {
        playerActions.Action_Map.Disable();
    }

    private void FixedUpdate()
    {
        if (curvedScene)
        {
            Vector3 position = circleCollider.transform.position;
            position.x = this.transform.position.x;
            circleCollider.transform.position = position;
        }
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Run();

        //ternary operator, saying if we are running current speed is run speed
        //and if we aren't its walkspeed
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        //reading and storing the input
        movementInput = playerActions.Action_Map.Movement.ReadValue<Vector2>();

        float currentYVelocity = rb.linearVelocityY;
        rb.linearVelocity = new Vector2 (movementInput.x * currentSpeed, currentYVelocity);

      
        //checking to see if player can jump and letting them jump

        if (GameManager.instance.playingAsSpaceDog())
        {
            if (jumpRequested && numJumps != maxNumJumps)
            {
                numJumps++;
                Debug.Log("Space dog jumped");
                animator.SetTrigger("Jump");
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
              
                jumpRequested = false;
            }
            if (numJumps == maxNumJumps && isGrounded)
            {
                numJumps = 0;
                jumpRequested = false;
            }

        }
        else
        {
            if (isGrounded && jumpRequested)
            {
                animator.SetTrigger("Jump");
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpRequested = false;
            }
        }
        


        if (curvedScene)
        {
            material.SetFloat("_PlayerOffset", this.transform.position.x);
        }

        
      
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
        animator.SetInteger("VertVel", (int)rb.linearVelocity.y);

    }
    private void OnApplicationQuit()
    {
        if (curvedScene)
        {
            material.SetFloat("_PlayerOffset", 0);
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.setSpaceDog(spaceDog);
        GameManager.instance.setTargetPlayer(this.gameObject);
        GameManager.instance.setOtherPlayer(otherCharacter);
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

        if (GameManager.instance.playingAsSpaceDog())
        {
            if (playerInput.actions["Jump"].WasPressedThisFrame())
            {
                jumpRequested = true;
            }
        }
        else
        {
            if (playerInput.actions["Jump"].WasPressedThisFrame() && isGrounded)
            {
                jumpRequested = true;
            }
        }
        

        animator.SetBool("IsGrounded", isGrounded);
        
    }

    private void switchCharacters()
    {
        if(playerInput.actions["SwitchPlayer"].WasPressedThisFrame())
        {
            GameManager.instance.setTargetPlayer(otherCharacter);
            GameManager.instance.setOtherPlayer(this.gameObject);

            Debug.Log("Switch players");
            rb.linearVelocity = Vector2.zero;
            //rb.angularVelocity = 0f;
            currentSpeed = 0f;
            rb.gravityScale = 0;



            rb.constraints = RigidbodyConstraints2D.FreezeAll;



            if (curvedScene)
            {
                rotateFollowObject.GetComponent<HideFollow>().enabled = false;

                foreach (SpriteRenderer sr in rotateFollowObject.GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.enabled = true;
                }

                foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.enabled = false;
                }
                //this.GetComponent<RotateWithCurve>().enabled = true;
                //GameManager.instance.getTargetPlayer().GetComponent<RotateWithCurve>().enabled = false;
            }

            this.GetComponent<PlayerController>().enabled = false;

            GameManager.instance.setMustMoveCamera(true);

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
