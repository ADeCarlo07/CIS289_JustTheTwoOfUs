using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject otherPlayer;
    private bool inRadius = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Follow()
    {
        if (otherPlayer != null)
        {
            if (!inRadius)
            {
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FollowRadius"))
        {
            inRadius = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FollowRadius"))
        {
            inRadius = false;
        }
    }
}
