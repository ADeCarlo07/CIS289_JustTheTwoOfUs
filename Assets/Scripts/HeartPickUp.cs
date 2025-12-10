using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    public GameObject heartUI;
    public GameObject heart;

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
            if (heartUI.GetComponent<HeartUI>().currentHearts < GameManager.instance.numberOfHearts)
            {
                Debug.Log("healed with" +  heartUI.GetComponent<HeartUI>().currentHearts + " and max being " +  GameManager.instance.numberOfHearts);
                heartUI.GetComponent<HeartUI>().Heal(1);
            }
            else
            {
                heart.GetComponent<HeartDamage>().heal(4);
            }

            Destroy(this.gameObject);
        }
    }
}
