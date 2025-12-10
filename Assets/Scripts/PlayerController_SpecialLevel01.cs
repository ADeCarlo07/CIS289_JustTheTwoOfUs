using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PlayerController_SpecialLevel01 : MonoBehaviour
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
    public Material material02;



    public CinemachineCamera cam;
    public GameObject circleCollider;
    //public float vertexOfParabola;
    //public GameManager gameManager;
    public GameObject follower;
    private int maxNumJumps = 2;
    private int numJumps = 0;
    public GameObject spaceDog;
    //certain things aren't needed unless the scene uses my matieral that curves the scene
    public bool curvedScene;


    public float level01_heightOffset;
    private bool offsetApplied;


    public GameObject rotateFollowObject;


    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip walkingSound;
    public AudioClip runningSound;

    public GameObject pauseMenu;

    private bool canSwitch;

    public bool canMove = true;


    private void Awake()
    {
      
        playerActions = new PlayerActions();
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        //This was important way early on in development of level 1
        //Currently, you don't even really see the other characters rotating
        //counterpart because things in level 1 got overly complicated with the
        //rightside up and upside down objects. Essentially, when the player would
        //switch and the other character would stay still while the new current character
        //would move around, their position would get displaced because of the curvature
        //of the ground bellow. I didn't like this for the player, so I made a seperate
        //GameObject that would appear and this object would become hidden and stay in place
        //while the new rotating GameObject acts as a visual. Worked really well while I had it
        

        //It follows the character while it moves, but isn't visible in the beginning
        rotateFollowObject.GetComponent<HideFollow>().enabled = true;

        foreach (SpriteRenderer sr in rotateFollowObject.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.enabled = false;
        }

        playerActions.Action_Map.Enable();

    }

    private void OnDisable()
    {
        playerActions.Action_Map.Disable();
        offsetApplied = false;
        audioSource.Stop();
        audioSource2.Stop();
    }

    private void FixedUpdate()
    {
       if (canMove)
       {
            if (curvedScene)
            {
                Vector3 position = circleCollider.transform.position;
                position.x = this.transform.position.x;
                circleCollider.transform.position = position;
            }

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);
            Run();

            //ternary operator, saying if we are running current speed is run speed
            //and if we aren't its walkspeed
            currentSpeed = isRunning ? runSpeed : walkSpeed;

            //reading and storing the input
            movementInput = playerActions.Action_Map.Movement.ReadValue<Vector2>();
            movementInput = movementInput.normalized;


            //Audio
            if (movementInput != Vector2.zero && isGrounded)
            {
                if (isRunning)
                {
                    if (audioSource2.isPlaying)
                    {
                        audioSource2.Stop();
                    }

                    if (!audioSource.isPlaying)
                    {
                        audioSource.clip = runningSound;
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                }
                else
                {
                    if (audioSource.isPlaying)
                    {
                        audioSource.Stop();
                    }

                    if (!audioSource2.isPlaying)
                    {
                        audioSource2.clip = walkingSound;
                        audioSource2.loop = true;
                        audioSource2.Play();
                    }
                }
            }
            else
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                if (audioSource2.isPlaying)
                {
                    audioSource2.Stop();
                }
            }

            float currentYVelocity = rb.linearVelocityY;
            rb.linearVelocity = new Vector2(movementInput.x * currentSpeed, currentYVelocity);


            //checking to see if player can jump and letting them jump

            if (GameManager.instance.playingAsSpaceDog())
            {
                if (jumpRequested && numJumps != maxNumJumps)
                {
                    numJumps++;
                    Debug.Log("Max num jumps: " + maxNumJumps);
                    Debug.Log("Space dog jumped " + numJumps);
                    animator.SetTrigger("Jump");
                    rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                    jumpRequested = false;
                }
                if (numJumps >= maxNumJumps && isGrounded)
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
                    rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
                    jumpRequested = false;
                }
            }



            if (curvedScene)
            {
                if (GameManager.instance.playingAsSpaceDog())
                {
                    material.SetFloat("_PlayerOffset", this.transform.position.x);
                }
                else
                {
                    material02.SetFloat("_PlayerOffset", this.transform.position.x);
                }

            }

            Debug.Log("Is grounded: " + isGrounded);


            animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
            animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
            animator.SetInteger("VertVel", (int)rb.linearVelocity.y);
        }

        

    }
    private void OnApplicationQuit()
    {
        if (curvedScene)
        {
            material.SetFloat("_PlayerOffset", 0);
            material02.SetFloat("_PlayerOffset", 0);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        

        GameManager.instance.setSpaceDog(spaceDog);
        GameManager.instance.setTargetPlayer(spaceDog);
        GameManager.instance.setOtherPlayer(otherCharacter);
        animator = GetComponent<Animator>();

     


    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.getOtherPlayer().GetComponent<PlayerController_SpecialLevel01>().enabled == false)
        {

            GameManager.instance.getOtherPlayer().GetComponent<PlayerController_SpecialLevel01>().enabled = true;
            GameManager.instance.getOtherPlayer().GetComponent<PlayerController_SpecialLevel01>().canMove = false;
        }
        if (canMove)
        {
            if (playerInput.actions["Pause"].WasPressedThisFrame())
            {
                pauseMenu.SetActive(true);
            }

            if (!GameManager.instance.playingAsSpaceDog() && !offsetApplied)
            {
                Vector3 pos = transform.position;
                pos.y = level01_heightOffset;
                transform.position = pos;
                Debug.Log("offset guy");

                offsetApplied = true;
            }


            if (GameManager.instance.playingAsSpaceDog())
            {

                //make gravity normal
                Physics2D.gravity = new Vector2(0, -9.8f);

                if (movementInput.x != 0)
                {
                    //flips entire gameObject by inverting its x scale
                    Vector3 scale = transform.localScale;
                    scale.x = Mathf.Sign(movementInput.x) * Mathf.Abs(scale.x);
                    transform.localScale = scale;
                }
                //else
                //{
                //    //Snap back to facing right
                //    Vector3 scale = transform.localScale;
                //    scale.x = Mathf.Abs(scale.x);
                //    transform.localScale = scale;
                //}
            }
            else
            {
                //flip gravity
                Physics2D.gravity = new Vector2(0, 9.8f);


                //this is so the space guy character remains upside down
                Vector3 scale = transform.localScale;
                scale.y = -Mathf.Abs(scale.y);

                if (movementInput.x != 0)
                {
                    scale.x = Mathf.Sign(movementInput.x) * Mathf.Abs(scale.x);
                }

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
        

    }

    private void switchCharacters()
    {
        if (playerInput.actions["SwitchPlayer"].WasPressedThisFrame() && isGrounded && canSwitch && canMove)
        {

            if (!GameManager.instance.playingAsSpaceDog())
            {
                gameObject.GetComponent<SpaceGuyShoot>().enabled = false;
            }
            else if (GameManager.instance.playingAsSpaceDog())
            {
                GameManager.instance.getOtherPlayer().GetComponent<SpaceGuyShoot>().enabled = true;
            }

            if (GameManager.instance.getTargetPlayer() == spaceDog)
            {
                GameManager.instance.setTargetPlayer(otherCharacter);
                GameManager.instance.setOtherPlayer(spaceDog);
                audioSource.Stop();
                audioSource2.Stop();
            }
            else
            {
                GameManager.instance.setTargetPlayer(spaceDog);
                GameManager.instance.setOtherPlayer(otherCharacter);
                audioSource.Stop();
                audioSource2.Stop();
            }



            Debug.Log("Switch players");
            
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
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

            canMove = false;

            GameManager.instance.setMustMoveCamera(true);


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.instance.playingAsSpaceDog())
        {
            if (collision.gameObject.CompareTag("GroundUpsideDown"))
            {
                canSwitch = true;
            }
        }

        if (GameManager.instance.playingAsSpaceDog())
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                canSwitch = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!GameManager.instance.playingAsSpaceDog())
        {
            if (collision.gameObject.CompareTag("GroundUpsideDown"))
            {
                canSwitch = false;
            }
        }

        if (GameManager.instance.playingAsSpaceDog())
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                canSwitch = false;
            }
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
