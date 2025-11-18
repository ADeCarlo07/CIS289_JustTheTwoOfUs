using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.DefaultInputActions;

public class PlayerController_Level02Special : MonoBehaviour
{
    //Easiest movement script I've had to make.. A blessing really.

    private Vector2 movementInput;
    private Rigidbody2D rb;
    private PlayerActions playerActions;
    private PlayerInput playerInput;
    private Animator animator;
    public float speed = 4f;
    public float swimForce = 4f;
    public AudioSource audioSource;
    public AudioClip swim;

    public GameObject pauseMenu;


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
        GameManager.instance.setTargetPlayer(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Swim"].WasPressedThisFrame())
        {
            audioSource.PlayOneShot(swim);
            animator.SetTrigger("PushUp");
            Debug.Log("Player wants to swim");
           
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, swimForce);
        }
        if (playerInput.actions["Pause"].WasPressedThisFrame())
        {
            pauseMenu.SetActive(true);
        }

        if (movementInput.x != 0)
        {
            //flips entire gameObject by inverting its x scale
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(movementInput.x) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    private void FixedUpdate()
    {
        movementInput = playerActions.Swimming_Map.Movement.ReadValue<Vector2>();
        movementInput = movementInput.normalized;

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
