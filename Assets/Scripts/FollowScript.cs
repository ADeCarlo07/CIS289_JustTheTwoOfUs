using System.Collections;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameManager gameManager;
    public float vertexOfParabola = -6f;
    public Material material;
    public float moveDuration = 2f;
    private bool isMoving;
    private Vector3 endPos;
    //certain things aren't needed unless the scene uses my matieral that curves the scene
    public bool curvedScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        if (gameManager.getMustMoveCamera() && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveToTarget());
            

            
        }

        if (!gameManager.getMustMoveCamera())
        {
            transform.position = gameManager.getTargetPlayer().transform.position;
        }
    }


    IEnumerator MoveToTarget()
    {
        Vector3 startPos = transform.position;
        if (curvedScene)
        {
            Vector3 endPosY = gameManager.getTargetPlayer().transform.position;
            endPosY.y = vertexOfParabola;
            endPos = endPosY;
        }
        else
        {
            endPos = gameManager.getTargetPlayer().transform.position;
        }
        

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            transform.position = Vector3.Lerp(startPos, endPos, t);

            if (curvedScene)
            {
                material.SetFloat("_PlayerOffset", transform.position.x);
            }
           

            yield return null;
        }

        transform.position = endPos;
        

        if (curvedScene)
        {
            material.SetFloat("_PlayerOffset", endPos.x);
            gameManager.getTargetPlayer().GetComponent<RotateWithCurve>().enabled = false;
        }
        
        gameManager.getTargetPlayer().GetComponent<Rigidbody2D>().gravityScale = 1;
        gameManager.getTargetPlayer().GetComponent<PlayerController>().enabled = true;
        gameManager.getTargetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        gameManager.getTargetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        gameManager.getTargetPlayer().transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 pos = gameManager.getTargetPlayer().transform.position;
        if (curvedScene)
        {
            pos.y = vertexOfParabola;
        }
        gameManager.getTargetPlayer().transform.position = pos;

        gameManager.setMustMoveCamera(false);


        isMoving = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    

}
