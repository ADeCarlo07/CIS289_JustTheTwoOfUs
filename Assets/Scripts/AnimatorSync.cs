using UnityEngine;

public class AnimatorSync : MonoBehaviour
{
    //This will only really be used when a character has been
    //switched and is no longer taking input in PlayerController.
    //When input is disabled the animations no longer have
    //the parameters being told to the animator so things
    //were prone to breaking or not playing right.
    //Having this in a seperate script stops that.


    private Animator animator;
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //fixed update because I'm working with physics
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
        animator.SetInteger("VertVel", (int)rb.linearVelocity.y);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
