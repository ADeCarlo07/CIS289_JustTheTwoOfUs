using UnityEngine;
using System.Collections;

public class Level1_Enemy1_AttackRad : MonoBehaviour
{
    public float radius = 5f;
    public LayerMask playerLayer;
    public bool playerInRange;
    public GameObject heartUI;
    private bool isAttacking;
    public GameObject bush;

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (hit != null && !isAttacking && bush.GetComponent<Level1_Enemy1_Bush>().canAttack)
        {
            StartCoroutine(attack());
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

    IEnumerator attack()
    {
        isAttacking = true;
        heartUI.GetComponent<HeartDamage>().TakeDamage(1);
        yield return new WaitForSeconds(0.75f);
        isAttacking = false;
    }
}
