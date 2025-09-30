using System.Collections;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameManager gameManager;
    private Vector3 origPos;
    private Vector3 targetPos;
    private float timeToMove = 0.2f;
    public float vertex = -6f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = gameManager.getTargetPlayer().transform.position;
    }

    public void MoveToOtherCharacter(bool move)
    {
        Debug.Log(move);
        if(move)
        {
            Vector2 direction = (gameManager.getTargetPlayer().transform.position - gameManager.getOtherPlayer().transform.position).normalized;
            rb.AddForce(direction);
        }

    }

    

}
