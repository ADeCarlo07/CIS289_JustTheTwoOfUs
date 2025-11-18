using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 lastPosition;
    private Transform playerOnPlatform;

    void Start()
    {
        lastPosition = transform.position;
    }

    void LateUpdate()
    {
        if (playerOnPlatform != null)
        {
            //Calculate how much the platform moved this frame
            Vector3 delta = transform.position - lastPosition;

            //Apply that delta to the player
            playerOnPlatform.position += delta;
        }

        lastPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = null;
        }
    }
}
