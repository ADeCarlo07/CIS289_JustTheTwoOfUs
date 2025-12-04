using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02_Enemy02 : MonoBehaviour
{
  
    public int followIndex;
    public GameObject head;
    public Transform rotationCenter;

    List<Vector2> headPositionList;

    public bool oppositeDirection;

    private float ang;

    private bool isAttacking;
    public GameObject heartUI;

    public float radius = 3f;

    public LayerMask playerLayer;

    public Transform pos;

    public float followSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        headPositionList = head.GetComponent<Level02_Enemy02_Head>().positionHistory;

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (hit != null && !isAttacking)
        {
            StartCoroutine(attack());
        }


        if (headPositionList.Count > followIndex)
        {
            //transform.position = headPositionList[followIndex];
            transform.position = Vector2.Lerp(transform.position, headPositionList[followIndex], Time.deltaTime * followSpeed);
        }


        Vector3 direction = rotationCenter.position - transform.position;

        if (!oppositeDirection)
        {
            ang = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        }
        else
        {
            ang = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0, 0, ang);

    }

    void OnDrawGizmosSelected()
    {
        //So I can see it in the editor when I'm adjusting the size
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos.position, radius);
    }


    IEnumerator attack()
    {
        isAttacking = true;
        heartUI.GetComponent<HeartDamage>().TakeDamage(1);
        yield return new WaitForSeconds(0.75f);
        isAttacking = false;
    }
}
