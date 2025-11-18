using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_SpecialLevel03 : MonoBehaviour
{
    private PlayerActions playerActions;
    private PlayerInput playerInput;
    public GameObject pauseMenu;

    public GameObject spaceGuyTriggered;
    public GameObject spaceDogTriggered;
    public GameObject blockTriggered;

    public Transform spawn01;
    public Transform spawn02;
    public Transform spawn03;

    public GameObject triggerNote;

    public int numHits;

    private void Awake()
    {
        playerActions = new PlayerActions();
        playerInput = GetComponent<PlayerInput>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Pause"].WasPressedThisFrame())
        {
            pauseMenu.SetActive(true);
            
        }

        if (playerInput.actions["SpaceDogButton"].WasPressedThisFrame())
        {
            spaceDogTriggered.SetActive(true);
            Instantiate(triggerNote, spawn02.position, Quaternion.identity);
        }
        else if (playerInput.actions["SpaceDogButton"].WasReleasedThisFrame())
        {
            spaceDogTriggered.SetActive(false);
        }

        if (playerInput.actions["SpaceGuyButton"].WasPressedThisFrame())
        {
            spaceGuyTriggered.SetActive(true);
            Instantiate(triggerNote, spawn01.position, Quaternion.identity);
        }
        else if (playerInput.actions["SpaceGuyButton"].WasReleasedThisFrame())
        {
            spaceGuyTriggered.SetActive(false);
        }

        if (playerInput.actions["Block"].WasPressedThisFrame())
        {
            Instantiate(blockTriggered, spawn03.position, Quaternion.identity);
        }
       
    }

    private void OnEnable()
    {

        playerActions.Rhythm_Map.Enable();

    }

    private void OnDisable()
    {
        playerActions.Rhythm_Map.Disable();
    }

    

}
