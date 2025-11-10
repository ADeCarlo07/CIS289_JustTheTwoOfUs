using UnityEngine;
using UnityEngine.Tilemaps;

public class Button01 : MonoBehaviour
{
    public Tilemap buttonActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.triggerTutorialButton01)
        {
            buttonActive.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            buttonActive.gameObject.SetActive(true);
            GameManager.instance.triggerTutorialButton01 = true;
            Destroy(collision.gameObject);
        }
    }
}
