using UnityEngine;

public class Level1_Enemy3_radius : MonoBehaviour
{
    public float radius = 3f;
    public LayerMask playerLayer;
    public bool playerInRange;

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (hit != null)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        //So I can see it in the editor when I'm adjusting the size
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
