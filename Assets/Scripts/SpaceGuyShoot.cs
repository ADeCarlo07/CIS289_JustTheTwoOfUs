using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpaceGuyShoot : MonoBehaviour
{
    public Transform bulletSpawnpoint;
    public GameObject bullet;
    public int ammoCount = 5;
    private PlayerInput playerInput;
    public Image ammoBar;
    public AudioSource audioSource;
    public AudioClip shotSound;
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
        if (playerInput.actions["Shoot"].WasPressedThisFrame() && ammoCount != 0)
        {
            audioSource.PlayOneShot(shotSound);
            Debug.Log("Player shot");
            ammoCount--;
            ammoBar.GetComponent<AmmoBar>().RemoveAmmo(1);


            Vector2 direction;
            if (transform.localScale.x > 0)
            {
                direction = Vector2.right;
            }
            else
            {
                direction = Vector2.left;
            }

            GameObject newBullet = Instantiate(bullet, bulletSpawnpoint.position, bulletSpawnpoint.rotation);

            newBullet.GetComponent<Bullet>().SetDirection(direction);

            //flips object
            if (transform.localScale.x < 0)
            {
                Vector3 flippedScale = newBullet.transform.localScale;
                flippedScale.x *= -1;
                newBullet.transform.localScale = flippedScale;
            }
        }
    }
}
