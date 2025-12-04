using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Level02_Enemy02_Head : MonoBehaviour
{
    //Save the previous pos of the head so level02_enemy02
    //GameObjects can trail behind
    public List<Vector2> positionHistory = new List<Vector2>();

    public Transform rotationCenter;
    public float rotationRadius = 2f;
    public float speed = 2f;

    private float positionX = 0f;
    private float positionY = 0f;
    private float angle = 0f;

    public bool oppositeDirection;

    private float ang;

    private bool isAttacking;
    public GameObject heartUI;

    public float radius = 3f;

    public Transform pos;

    public LayerMask playerLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

    }

    private void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (hit != null && !isAttacking)
        {
            StartCoroutine(attack());
        }

        positionX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;

        positionY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;


        Vector2 currentPos = new Vector2(positionX, positionY);
        positionHistory.Insert(0, currentPos);

        //Don't want too much :)
        if (positionHistory.Count > 1000)
        {
            positionHistory.RemoveAt(positionHistory.Count - 1);
        }


        transform.position = new Vector2(positionX, positionY);
        angle = angle + Time.deltaTime * speed;



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


        //if(!oppositeDirection)
        //{
        //    transform.Rotate(0, 0, rotateStrength * Time.deltaTime * rotateStrength);
        //}
        //else
        //{
        //    transform.Rotate(0, 0, -rotateStrength * Time.deltaTime * rotateStrength);
        //}

        if (angle >= 360f)
        {
            angle = 0f;
        }
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
