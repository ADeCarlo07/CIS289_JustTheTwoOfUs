using UnityEngine;

public class Level03_End : MonoBehaviour
{
    public GameObject level03;
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
        if (collision.gameObject.CompareTag("EndOfScreen"))
        {
            int numHits = level03.GetComponent<PlayerController_SpecialLevel03>().numHits;
            GameManager.instance.setNumOfHitsGame01(numHits);
        }
    }
}
