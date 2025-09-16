using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private PlayerActions playerActions;
    private Vector2 movementInput;
    private PlayerInput playerInput;

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

        //reading and storing the input
        movementInput = playerActions.Action_Map.Movement.ReadValue<Vector2>();

        //setting y axis to 0 (temperary until velocity is applied on this axis
        movementInput.y = 0f;
        rb.linearVelocity = movementInput * speed;

        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        switchCharacters();
    }

    private void switchCharacters()
    {
        if(playerInput.actions["SwitchPlayer"].WasPressedThisFrame())
        {
            Debug.Log("Switch players");
        }
        
    }

}
