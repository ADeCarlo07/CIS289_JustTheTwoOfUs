using UnityEngine;

public class Level02_Enemy03_Hit : MonoBehaviour
{
    public bool playerInRange;
    public float radius = .6f;
    public LayerMask playerLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (hit != null)
        {
            playerInRange = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        //So I can see it in the editor when I'm adjusting the size
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
