
using System.Collections;
using UnityEngine;

public class Level01_Enemy02 : MonoBehaviour
{
    //If I could go back in time to when I decided to make the levels curve for
    //that artistic flare, I would slap myself across the face.

    Animator animator;
    public GameObject bullet;
    public Transform bulletSpawn01;
    public Transform bulletSpawn02;
    public Transform bulletSpawn03;
    public bool playerInRad;

    private float shootCooldown = 2f;
    private float shootTimer = 0f;

    public RotateWithCurve curveController;

    private bool isFiring = false;

    public GameObject heartRad;
    public bool isHeartShot;

    public GameObject heartUI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isHeartShot = heartRad.GetComponent<Level1_Enemy2_HeartRad>().stopAttacking;

        if (!isHeartShot)
        {
            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0f && playerInRad)
            {
                animator.SetTrigger("Attack");
                StartCoroutine(FireSequence());

                //reset timer
                shootTimer = shootCooldown;
            }
        }
        else
        {
            animator.SetBool("StopAttacking", true);
        }
        
    }

    IEnumerator FireSequence()
    {
        if (isFiring)
        {
            yield break;
        }
            

        isFiring = true;

        //animator.SetTrigger("Attack");

        //Put in random numbers until something was good enough.
        //Last ones are around the time when the animation looks like
        //its firing, first one needed less of a delay for it to look
        //on time.
        yield return new WaitForSeconds(.05f);
        Shoot();

        yield return new WaitForSeconds(.65f);  
        Shoot02();

        yield return new WaitForSeconds(.65f);
        Shoot03();

        isFiring = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRad = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRad = false;
        }
    }

    //I basically used random things until something worked :(

    private void Shoot()
    {
        //go / <-- that direction

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletSpawn01.position;

        float slope = curveController.SampleGroundSlope(bulletSpawn01.position.x);
        Vector2 direction = new Vector2(1f, slope + 1f).normalized;

        //Blend with upward bias
        //If there was no bias then it would go in the wrong direction since
        //everything is flipped the wrong way for this enemy. Cool in retrospect...
        Vector2 upwardBias = new Vector2(0f, 1f);
        Vector2 finalDirection = (direction + upwardBias).normalized;

        float angle = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        newBullet.GetComponent<Level01_Bullet>().SetDirection(finalDirection, heartUI);
    }

    private void Shoot02()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletSpawn02.position;

        //Flip slope to mirror rightward behavior
        float slope = -curveController.SampleGroundSlope(bulletSpawn02.position.x);
        Vector2 direction = new Vector2(-1f, slope - 1f).normalized;

        Vector2 upwardBias = new Vector2(0f, 1f);
        Vector2 finalDirection = (direction + upwardBias * 2f).normalized;

        float angle = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        newBullet.GetComponent<Level01_Bullet>().SetDirection(finalDirection, heartUI);
    }

    private void Shoot03()
    {
        //go | <-- that direction

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletSpawn03.position;

        float slope = curveController.SampleGroundSlope(bulletSpawn03.position.x);
        Vector2 tangent = new Vector2(1f, slope).normalized;
        Vector2 normal = new Vector2(-tangent.y, tangent.x);

        newBullet.GetComponent<Level01_Bullet>().SetDirection(normal, heartUI);

        float angle = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

    }

}
