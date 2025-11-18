using Unity.VisualScripting;
using UnityEngine;

public class AmmoAdder : MonoBehaviour
{
    public GameObject ammoBar;
    public GameObject spaceGuy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ammoBar.GetComponent<AmmoBar>().AddAmmo(5);
            //Shooting script
            SpaceGuyShoot shoot = spaceGuy.GetComponent<SpaceGuyShoot>();

            //Add ammo but clamp to max (5)
            shoot.ammoCount = Mathf.Min(shoot.ammoCount + 5, 5);

            Destroy(this.gameObject);
        }
    }
}
