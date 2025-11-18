using System.Collections;
using UnityEngine;

public class Level1_Enemy2_Tree : MonoBehaviour
{
    public GameObject level1_Enemy2;
    public GameObject bullet;
    public Transform bulletSpawn01;
    public Transform bulletSpawn02;
    public Transform bulletSpawn03;
    public GameObject heartUI;
    //private bool playerInRad;

    private float shootCooldown = .5f;
    private float shootTimer = 0f;

    public RotateWithCurve curveController;

    private bool isFiring = false;

    private bool heartShot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Special case only for this one script, literally nothing else was working for me
        bool hidden = level1_Enemy2.GetComponent<Level1Manager>().hidden;
        heartShot = level1_Enemy2.GetComponent<Level01_Enemy02>().isHeartShot;

        if (!heartShot && hidden && GameManager.instance.playingAsSpaceDog())
        {
            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0f)
            {

                StartCoroutine(FireSequence());

                //reset timer
                shootTimer = shootCooldown;
            }
        }
        
    }

    IEnumerator FireSequence()
    {
        if (isFiring)
        {
            yield break;
        }


        isFiring = true;

        //Smaller wait times so more leaves fall
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
        //This used to be \ <-- that direction but it was too difficult to deal with sadly
        //go | <-- that direction

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletSpawn01.position;

        float slope = curveController.SampleGroundSlope(bulletSpawn01.position.x);
        Vector2 direction = new Vector2(0f, -1f);
        //For this script and my level01_enemy02 script, if slope is being multiplied by a random
        //number, its because I was messing around with how steep I wanted it to go
        Vector2 slopeInfluence = new Vector2(slope * 0.5f, 0f);

        Vector2 finalDirection = (direction + slopeInfluence).normalized;

        //angle it so its rotated in the right direction
        float angle = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        //This goes for both my level01_enemy02 and this script, I'm passing the current
        //heartUI so I don't have to have it in the prefab, nice loophole
        newBullet.GetComponent<Level01_Bullet>().SetDirection(finalDirection, heartUI);
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
        newBullet.GetComponent<Level01_Bullet>().SetDirection(finalDirection, heartUI);
    }

    private void Shoot03()
    {
        //go | <-- that direction

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletSpawn03.position;

        float slope = curveController.SampleGroundSlope(bulletSpawn03.position.x);
        Vector2 direction = new Vector2(0f, -1f);
        Vector2 slopeInfluence = new Vector2(slope * 0.5f, 0f);

        Vector2 finalDirection = (direction + slopeInfluence).normalized;

        float angle = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        newBullet.GetComponent<Level01_Bullet>().SetDirection(finalDirection, heartUI);

    }
}
