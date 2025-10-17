using UnityEngine;
using UnityEngine.Rendering;

public class Level1_Enemy1_Attack : MonoBehaviour
{
    public float pullForce = 10f;
    public GameObject player;
    private bool playerInRad = false;
    private Rigidbody2D player_rb;
    public Transform mouth;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        player_rb = player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (playerInRad)
        {
            Vector3 direction = (mouth.position - player.transform.position).normalized;
            player_rb.AddForce(direction * pullForce, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("OutOfRad", false);
            animator.SetTrigger("Attack");
            Debug.Log("player in rad");
            playerInRad = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("OutOfRad", true);
            Debug.Log("player out of rad");
            playerInRad = false;
        }
    }
}
