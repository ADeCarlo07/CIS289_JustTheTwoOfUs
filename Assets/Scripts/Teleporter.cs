using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public bool level1;
    public string levelName;
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
            SceneManager.LoadScene(levelName);
            if (level1)
            {
                if (GameManager.instance.getLevel1Collectable() == 3)
                {
                    int numHearts = GameManager.instance.getNumberOfHearts();
                    Debug.Log("Got all level 1 collectables");
                    numHearts++;
                    GameManager.instance.setNumberOfHearts(numHearts);
                }
            }
        }
    }
}
