using UnityEngine;

public class Level1_Enemy1_Bush : MonoBehaviour
{
    public bool canAttack;
    public GameObject openEye;
    public GameObject closedEye;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.instance.playingAsSpaceDog())
        {
            canAttack = false;
            openEye.SetActive(false);
            closedEye.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.instance.playingAsSpaceDog())
        {
            canAttack = true;
            openEye.SetActive(true);
            closedEye.SetActive(false);
        }
    }
}
