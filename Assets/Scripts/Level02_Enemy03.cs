using System.Collections;
using TMPro;
using UnityEngine;

public class Level02_Enemy03 : MonoBehaviour
{
    public GameObject player;
    public GameObject attackRadius;
    private Animator animator;

    public float radius = 5f;
    public LayerMask playerLayer;


    public float speed = 5f;

    private bool isAttacking;

    public GameObject heartUI;

    public GameObject hitBox;

    private Coroutine attackC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitBox.GetComponent<Level02_Enemy03_Hit>().playerInRange)
        {
            Destroy(this.gameObject);
        }


        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (hit != null && !isAttacking)
        {
            attackC = StartCoroutine(attack());
        }
       


        Vector3 scale = transform.localScale;

        //Decide which direction to face
        bool shouldFaceLeft = player.transform.position.x < transform.position.x;

        if (shouldFaceLeft)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

    }

    void OnDrawGizmosSelected()
    {
        //So I can see it in the editor when I'm adjusting the size
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackRadius.transform.position, radius);
    }


    private void FixedUpdate()
    {
      
        if (attackRadius.GetComponent<Level02_Enemy03_AttackRad>().playerInRange)
        {
            animator.SetBool("OutOfRad", false);
            animator.SetTrigger("Attack");

            Debug.Log("Walking towards player");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("OutOfRad", true);
            if (attackC != null)
            {
                StopCoroutine(attackC);
                attackC = null;
            }
         
        }
    }

    IEnumerator attack()
    {
        isAttacking = true;
        heartUI.GetComponent<HeartDamage>().TakeDamage(1);
        yield return new WaitForSeconds(0.75f);
        isAttacking = false;
    }


}
