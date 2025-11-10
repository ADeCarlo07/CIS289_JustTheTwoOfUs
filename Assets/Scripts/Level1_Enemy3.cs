using UnityEngine;

public class Level1_Enemy3 : MonoBehaviour
{
    public GameObject player;
    public GameObject moveRadius;
    public GameObject attackRad;
    private Animator animator;

    public float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        bool playerInAttackRad = attackRad.GetComponent<Level1_Enemy3_radius>().playerInRange;

        if (moveRadius.GetComponent<Level1_Enemy3_radius>().playerInRange && !playerInAttackRad)
        {
            animator.SetBool("PlayerInWalkingRad", true);
            //animator.SetTrigger("Attack");

            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        }

        if (playerInAttackRad)
        {
            animator.SetBool("OutOfRadius", false);

        }
        else
        {
            animator.SetBool("OutOfRadius", true);
        }

        if (!moveRadius.GetComponent<Level1_Enemy3_radius>().playerInRange)
        {
            animator.SetBool("PlayerInWalkingRad", false);
        }
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
