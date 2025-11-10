using System.Collections;
using UnityEngine;

public class Level1_Enemy2_Tree : MonoBehaviour
{
    public GameObject level1_Enemy2;
    public GameObject bullet;
    public Transform bulletSpawn01;
    public Transform bulletSpawn02;
    public Transform bulletSpawn03;
    //private bool playerInRad;

    private float shootCooldown = .5f;
    private float shootTimer = 0f;

    public RotateWithCurve curveController;

    private bool isFiring = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f && level1_Enemy2.GetComponent<Level01_Enemy02>().playerInRad)
        {
            
            StartCoroutine(FireSequence());

            //reset timer
            shootTimer = shootCooldown;
        }
    }

    IEnumerator FireSequence()
    {
        if (isFiring)
        {
            yield break;
        }


        isFiring = true;

        yield return new WaitForSeconds(.005f);
        Shoot();

        yield return new WaitForSeconds(.15f);
        Shoot03();

        yield return new WaitForSeconds(.15f);
        Shoot02();

        isFiring = false;
    }


    private void Shoot()
    {
        //go / <-- that direction

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletSpawn01.position;

        float slope = curveController.SampleGroundSlope(bulletSpawn01.position.x);
        Vector2 direction = new Vector2(1f, -slope - 1f).normalized;

        Vector2 downwardBias = new Vector2(0f, -1f);
        Vector2 finalDirection = (direction + downwardBias).normalized;

        float angle = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        newBullet.GetComponent<Level01_Bullet>().SetDirection(finalDirection);
    }

    private void Shoot02()
    {
        //go \ <-- that direction

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletSpawn02.position;

        float slope = curveController.SampleGroundSlope(bulletSpawn02.position.x);
        Vector2 direction = new Vector2(-1f, -slope - 1f).normalized;

        Vector2 downwardBias = new Vector2(0f, -1f);
        Vector2 finalDirection = (direction + downwardBias).normalized;

        float angle = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        newBullet.GetComponent<Level01_Bullet>().SetDirection(finalDirection);
    }

    private void Shoot03()
    {
        //go | <-- that direction

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletSpawn03.position;

        float slope = curveController.SampleGroundSlope(bulletSpawn03.position.x);
        Vector2 direction = new Vector2(0f, -1f);
        Vector2 slopeInfluence = new Vector2(slope * 0.5f, 0f); // subtle horizontal lean

        Vector2 finalDirection = (direction + slopeInfluence).normalized;

        float angle = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        newBullet.GetComponent<Level01_Bullet>().SetDirection(finalDirection);

    }
}
