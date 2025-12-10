using UnityEngine;

public class Level1_Enemy1_Bush : MonoBehaviour
{
    public bool canAttack;
    public GameObject openEye;
    public GameObject closedEye;
    public LayerMask playerLayer;
        public float radius = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canAttack = true;

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (hit != null)
        {
            canAttack = false;
            openEye.SetActive(false);
            closedEye.SetActive(true);
        }
        else
        {
            canAttack = true;
            openEye.SetActive(true);
            closedEye.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        //So I can see it in the editor when I'm adjusting the size
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == playerLayer && GameManager.instance.playingAsSpaceDog())
    //    {

    //    }

    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") && GameManager.instance.playingAsSpaceDog())
    //    {

    //    }

    //}
}
