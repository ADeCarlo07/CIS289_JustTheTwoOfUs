using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public bool level1;
    public string levelName;

    public bool level2;
    public bool level3;

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

        if (level1)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Character02"))
            {
                SceneManager.LoadScene(levelName);

                if (GameManager.instance.getLevel1Collectable() == 3)
                {
                    int numHearts = GameManager.instance.getNumberOfHearts();
                    Debug.Log("Got all level 1 collectables");
                    numHearts++;
                    GameManager.instance.setNumberOfHearts(numHearts);
                }
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(levelName);


                if (level2)
                {
                    if (GameManager.instance.getLevel2Collectable() == 3)
                    {
                        int numHearts = GameManager.instance.getNumberOfHearts();
                        Debug.Log("Got all level 2 collectables");
                        numHearts++;
                        GameManager.instance.setNumberOfHearts(numHearts);
                    }
                }

                if (level3)
                {
                    if (GameManager.instance.getLevel3Collectables() == 3)
                    {
                        int numHearts = GameManager.instance.getNumberOfHearts();
                        Debug.Log("Got all level 3 collectables");
                        numHearts++;
                        GameManager.instance.setNumberOfHearts(numHearts);
                    }
                }


            }
        }
        
    }
}
