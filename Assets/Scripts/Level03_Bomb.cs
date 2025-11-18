using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level03_Bomb : MonoBehaviour
{
    public float speed;
    public GameObject bottomOfScreen;

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
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("EndOfScreen"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
