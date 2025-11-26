using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float bulletLifeTime;
    private Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if (collision.CompareTag("Ground"))
        //{
        //    Destroy(this.gameObject);
        //}

        //if (collision.CompareTag("Wall"))
        //{
        //    Destroy(this.gameObject);
        //}

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
