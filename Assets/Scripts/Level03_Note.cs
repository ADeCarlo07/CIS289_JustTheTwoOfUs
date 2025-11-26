using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Level03_Note : MonoBehaviour
{
    public float speed;
    public GameObject bottomOfScreen;

    public bool dogNote;
    public bool guyNote;

    public GameObject level03;

    public bool lowNote;
    public bool highNote;
    public bool normNote;

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
        Vector3 currentPos = new Vector3();
        currentPos.y = transform.position.y;
        currentPos.x = transform.position.x;
        Vector3 targetPos = new Vector3();
        targetPos.y = bottomOfScreen.transform.position.y;
        targetPos.x = transform.position.x;
        transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hit"))
        {
            if (dogNote || guyNote)
            {
                AudioSource[] audio = level03.GetComponents<AudioSource>();
                if (dogNote && highNote)
                {
                    audio[0].Play();
                }
                else if (dogNote && lowNote)
                {
                    audio[1].Play();
                }
                else if (dogNote && normNote)
                {
                    audio[2].Play();
                }

                if (guyNote && highNote)
                {
                    audio[3].Play();
                }
                else if (guyNote && lowNote)
                {
                    audio[4].Play();
                }
                else if (guyNote && normNote)
                {
                    audio[5].Play();
                }

                level03.GetComponent<PlayerController_SpecialLevel03>().numHits++;
                Debug.Log("NumHits: " + level03.GetComponent<PlayerController_SpecialLevel03>().numHits);
                Destroy(gameObject);
            }
           
        }
    }
}
