using UnityEngine;

public class Level01_Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private Vector2 direction;
    public float bulletLifeTime;
    public bool upsideDown;
    private GameObject heartUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetDirection(Vector2 dir, GameObject hrtUI)
    {
        heartUI = hrtUI;
        direction = dir.normalized;
        GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
    }

    void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (upsideDown)
        {
            if (collision.gameObject.CompareTag("GroundUpsideDown"))
            {
                Destroy(this.gameObject);
            }

            if (collision.gameObject.layer == LayerMask.NameToLayer("Character01") && !GameManager.instance.playingAsSpaceDog())
            {
                heartUI.GetComponent<HeartDamage>().TakeDamage(1);
            }

            if (collision.gameObject.CompareTag("Border"))
            {
                Destroy(this.gameObject);
            }

          
        }
        else
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                Destroy(this.gameObject);
            }

            if (collision.gameObject.layer == LayerMask.NameToLayer("Character02") && GameManager.instance.playingAsSpaceDog())
            {
                heartUI.GetComponent<HeartDamage>().TakeDamage(2);
            }

            if (collision.gameObject.CompareTag("Border"))
            {
                Destroy(this.gameObject);
            }

           
        }
        
    }


}
