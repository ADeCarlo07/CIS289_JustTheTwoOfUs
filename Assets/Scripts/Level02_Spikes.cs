using UnityEngine;

public class Level02_Spikes : MonoBehaviour
{
    public GameObject heartUI;

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
            heartUI.GetComponent<HeartDamage>().TakeDamage(1);
        }
    }
}
