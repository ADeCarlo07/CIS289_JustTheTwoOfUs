using UnityEngine;

public class Level02_Enemy03 : MonoBehaviour
{
    public GameObject player;
    public GameObject attackRadius;
    private Animator animator;

    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        if (attackRadius.GetComponent<Level02_Enemy03_AttackRad>().playerInRange)
        {
            animator.SetBool("OutOfRad", false);
            animator.SetTrigger("Attack");


            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("OutOfRad", true);
        }
    }


}
