using System.Collections;
using UnityEngine;

public class Level03_Bolt : MonoBehaviour
{
    public float speed;
    public GameObject bottomOfScreen;
    public GameObject backgroundMuisc;
    public float newSpeed = 6.5f;
    public float timeUntilNormal = 6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
        if (collision.gameObject.CompareTag("Buttons"))
        {
            speedUpGame();
            Invoke("setGameBackToNormal", timeUntilNormal);
           
        }
    }

    private void speedUpGame()
    {
        Level03_Note[] notes = Object.FindObjectsByType<Level03_Note>(FindObjectsSortMode.None);
        Level03_Bolt[] bolts = Object.FindObjectsByType<Level03_Bolt>(FindObjectsSortMode.None);

        foreach (Level03_Note note in notes)
        {
            note.speed = newSpeed;
        }

        foreach (Level03_Bolt bolt in bolts)
        {
            bolt.speed = newSpeed;
        }

        backgroundMuisc.GetComponent<AudioSource>().pitch = 1.5f;
    }

    private void setGameBackToNormal()
    {
        Level03_Note[] notes = Object.FindObjectsByType<Level03_Note>(FindObjectsSortMode.None);
        Level03_Bolt[] bolts = Object.FindObjectsByType<Level03_Bolt>(FindObjectsSortMode.None);

        foreach (Level03_Note note in notes)
        {
            note.speed = 4f;
        }

        foreach (Level03_Bolt bolt in bolts)
        {
            bolt.speed = 4f;
        }

        backgroundMuisc.GetComponent<AudioSource>().pitch = 1f;
        //Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
