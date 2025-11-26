using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool level1;
    public bool tutorial;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            if (level1)
            {
                GameManager.instance.incrementLevel1Collectable();
                Destroy(this.gameObject);
            }

            if (tutorial)
            {
                GameManager.instance.incrementTutorialCollectable();
                Destroy(this.gameObject);
            }

            if (level2)
            {
                GameManager.instance.incrementLevel2Collectable();
                Destroy(this.gameObject);
            }

            if (level3)
            {
                GameManager.instance.incrementLevel3Collectables();
                Destroy(this.gameObject);
            }
           
        }
    }
}
