using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Level02_Enemy01 : MonoBehaviour
{
    public GameObject player;

    public float speed = 2f;

    private Vector3 targetPosition;

    public float radius = 5f;
    public LayerMask playerLayer;

    private bool playerInMoveRad;

    public GameObject backgroundMusic;

    public AudioSource audioSource;

    public AudioSource lowHealth;

    public GameObject blocker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lowHealth.isPlaying && playerInMoveRad)
        {
            lowHealth.Stop();
        }

        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (hit != null)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    private void FixedUpdate()
    {
        if (playerInMoveRad)
        {
            Debug.Log("Walking towards player");
            targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        //So I can see it in the editor when I'm adjusting the size
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInMoveRad = true;

            //Blocks the player from being able to go back up to the beginning
            //of the level and doesn't let them escape the chase
            blocker.SetActive(true);

            AudioSource audioS = backgroundMusic.GetComponent<AudioSource>();
            audioS.Stop();

            if (lowHealth.isPlaying)
            {
                lowHealth.Stop();
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        }
        
    }



}
