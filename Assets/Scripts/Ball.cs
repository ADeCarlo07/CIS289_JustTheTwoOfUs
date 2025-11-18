using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance.getTutoralCollectable() == 1)
            {
                int numHearts = GameManager.instance.getNumberOfHearts();
                Debug.Log("Got all tutorial collectables");
                numHearts++;
                GameManager.instance.setNumberOfHearts(numHearts);
                Debug.Log(GameManager.instance.getNumberOfHearts());
            }
            SceneManager.LoadScene("TutorialCrash");
        }
    }
}
