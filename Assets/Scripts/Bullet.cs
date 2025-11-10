using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float bulletLifeTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
