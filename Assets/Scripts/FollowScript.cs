using System.Collections;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    //This script is what the main camera follows in most scenes and takes care of
    //camera movement when switching characters

    //public GameManager gameManager;
    public float vertexOfParabola = -6f;
    public Material material;
    public float moveDuration = 2f;
    private bool isMoving;
    private Vector3 endPos;
    //certain things aren't needed unless the scene uses my matieral that curves the scene
    public bool curvedScene;
    public bool level01;
    public GameObject spaceDog;
    public float level01_heightOffset;
    public AudioSource followAudioSource;
    public AudioClip switchSound;

    public float heightOffset;

    //Was origionally a circle for curved scenes (ground player was on), but I changed
    //it to a parabola shape so it properly matches the material
    public GameObject circleCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        //Speical level01 case
        if (level01)
        {
            




            if (GameManager.instance.getMustMoveCamera() && !isMoving)
            {
                if (!followAudioSource.isPlaying)
                {
                    followAudioSource.PlayOneShot(switchSound);
                }

                isMoving = true;

                GameManager.instance.getTargetPlayer().GetComponent<PlayerController_SpecialLevel01>().enabled = true;
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().gravityScale = 1;
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                GameManager.instance.getTargetPlayer().transform.rotation = Quaternion.Euler(0, 0, 0);



                //Vector3 pos = GameManager.instance.getTargetPlayer().transform.position;
                //GameManager.instance.getTargetPlayer().transform.position = pos;

                GameManager.instance.setMustMoveCamera(false);

                foreach (SpriteRenderer sr in GameManager.instance.getTargetPlayer().GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.enabled = true;
                }

                isMoving = false;
            }
            else
            {
                //Vector3 pos = GameManager.instance.getTargetPlayer().transform.position;
                ////pos.x = GameManager.instance.getTargetPlayer().transform.position.x;
                ////pos.y = transform.position.y;
                //transform.position = pos;

                Vector2 pos = transform.position;
                Vector2 pPos = GameManager.instance.getTargetPlayer().transform.position;

                if (GameManager.instance.playingAsSpaceDog())
                {
                    pos.y = pPos.y + heightOffset;

                }
                else
                {
                    pos.y = pPos.y - heightOffset;
                }
                pos.x = pPos.x;
                transform.position = pos;

            }
            
        }
        else
        {
            if (GameManager.instance.getMustMoveCamera() && !isMoving)
            {
                isMoving = true;
             
                StartCoroutine(MoveToTarget());



            }


            if (!GameManager.instance.getMustMoveCamera())
            {
                Vector2 pos = transform.position;
                Vector2 pPos = GameManager.instance.getTargetPlayer().transform.position;

                pos.y = pPos.y + heightOffset;
                pos.x = pPos.x;
                transform.position = pos;

                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                GameManager.instance.getTargetPlayer().transform.rotation = Quaternion.Euler(0, 0, 0);

                //foreach (SpriteRenderer sr in GameManager.instance.getTargetPlayer().GetComponentsInChildren<SpriteRenderer>())
                //{
                //    sr.enabled = false;
                //}
            }
        }
        
    }


    IEnumerator MoveToTarget()
    {
       

        if (!followAudioSource.isPlaying)
        {
            followAudioSource.PlayOneShot(switchSound);
        }
     
        Vector3 startPos = transform.position;
        if (curvedScene && !level01)
        {
            

            Vector3 endPosY = GameManager.instance.getTargetPlayer().transform.position;
            endPosY.y = vertexOfParabola;
            endPos = endPosY;
        }
        else
        {
            endPos = GameManager.instance.getTargetPlayer().transform.position;
        }
        

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            Vector3 position = circleCollider.transform.position;
            position.x = this.transform.position.x;
            circleCollider.transform.position = position;

            //When on a curved scene, this is how it looks like the cam
            //Is moving along the curve
            if (curvedScene && !level01)
            {
                material.SetFloat("_PlayerOffset", transform.position.x);
            }
           

            yield return null;
        }

        //After moving to the new target player it is now at the end, finalize certain pos
        //and activate scripts

        transform.position = endPos;
        

        if (curvedScene)
        {
            material.SetFloat("_PlayerOffset", endPos.x);
            //GameManager.instance.getTargetPlayer().GetComponent<RotateWithCurve>().enabled = false;
            foreach (SpriteRenderer sr in GameManager.instance.getTargetPlayer().GetComponentsInChildren<SpriteRenderer>())
            {
                sr.enabled = true;
            }
        }


        GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = true;
        GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().gravityScale = 1;

    



        GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GameManager.instance.getTargetPlayer().transform.rotation = Quaternion.Euler(0, 0, 0);
        
            
        
        //Vector3 pos = GameManager.instance.getTargetPlayer().transform.position;
        //if (curvedScene)
        //{
        //    pos.y = vertexOfParabola;
        //}
       
        //GameManager.instance.getTargetPlayer().transform.position = pos;

        GameManager.instance.setMustMoveCamera(false);

        //followAudioSource.Stop();
        isMoving = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    

}
