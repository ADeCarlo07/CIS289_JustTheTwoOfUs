using UnityEngine;

public class Level1_Enemy3 : MonoBehaviour
{
    public GameObject player;
    public GameObject moveRadius;
    public GameObject attackRad;
    private Animator animator;

    public float speed = 2f;

    private Level1_Enemy3_radius moveRadiusScript;
    private Level1_Enemy3_radius attackRadiusScript;

    private Vector3 targetPosition;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        moveRadiusScript = moveRadius.GetComponent<Level1_Enemy3_radius>();
        attackRadiusScript = attackRad.GetComponent<Level1_Enemy3_radius>();
    }



    private void FixedUpdate()
    {
        if (!GameManager.instance.playingAsSpaceDog())
        {
            bool playerInAttackRad = attackRadiusScript.playerInRange;
            bool playerInMoveRad = moveRadiusScript.playerInRange;

            //Update animator states
            animator.SetBool("OutOfRadius", !playerInAttackRad);
            animator.SetBool("PlayerInWalkingRad", playerInMoveRad && !playerInAttackRad);

            Debug.Log("OutOfRad: " + animator.GetBool("OutOfRadius"));
            Debug.Log("PlayerInWalkingRad: " + animator.GetBool("PlayerInWalkingRad"));

            //Only move if in walking range and not attacking
            if (playerInMoveRad && !playerInAttackRad)
            {
                Debug.Log("Walking towards player");
                targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {

        //Make sure game object flips so it looks like its walking
        //towards player when going both left and right
        Vector3 scale = transform.localScale;
        float horizontalOffset = player.transform.position.x - transform.position.x;

        if (Mathf.Abs(horizontalOffset) > 0.01f)
        {
            float faceDirection = Mathf.Sign(horizontalOffset);
            bool isUpsideDown = scale.y < 0;

            float adjustedDirection = faceDirection;

            if (isUpsideDown)
            {
                adjustedDirection = -faceDirection;
            }

            scale.x = adjustedDirection * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}
