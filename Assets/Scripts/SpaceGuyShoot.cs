using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceGuyShoot : MonoBehaviour
{
    public Transform bulletSpawnpoint;
    public GameObject bullet;
    private int ammoCount = 0;
    private int maxAmmo = 5;
    private PlayerInput playerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        
    }

    public void Shoot()
    {
        if (playerInput.actions["Shoot"].WasPressedThisFrame() && ammoCount != maxAmmo)
        {
            Debug.Log("Player shot");
            Instantiate(bullet, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
            ammoCount++;
        }
    }
}
