using UnityEngine;

public class Level1_Enemy2_HeartRad : MonoBehaviour
{
    public float radius = 1f;
    public LayerMask bulletLayer;
    public bool stopAttacking;

    void Update()
    {

        if (!stopAttacking)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, bulletLayer);
            if (hit != null)
            {
                Debug.Log("Bullet hit the heart: " + hit.name);
                stopAttacking = true;
            }
            else
            {
                stopAttacking = false;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        //So I can see it in the editor when I'm adjusting the size
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
