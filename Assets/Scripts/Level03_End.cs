using UnityEngine;
using UnityEngine.SceneManagement;

public class Level03_End : MonoBehaviour
{
    public GameObject level03;
    public string toLevel03;
    public bool enemy02;
    public bool enemy03;
    public bool enemy01;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy01)
        {
            GameManager.instance.id = 2;
            Debug.Log("ID" + GameManager.instance.id);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("EndOfScreen"))
        {
            if (enemy02)
            {
                int numHits = level03.GetComponent<PlayerController_SpecialLevel03>().numHits;
                GameManager.instance.setNumOfHitsGame01(numHits);
                GameManager.instance.setLevel03Enemy02Done(true);
                SceneManager.LoadScene(toLevel03);
            }

            if (enemy03)
            {
                int numHits = level03.GetComponent<PlayerController_SpecialLevel03>().numHits;
                GameManager.instance.setNumOfHitsGame03(numHits);
                GameManager.instance.setLevel03Enemy03Done(true);
                SceneManager.LoadScene(toLevel03);
            }

            if (enemy01)
            {
              
                int numHits = level03.GetComponent<PlayerController_SpecialLevel03>().numHits;
                GameManager.instance.setNumOfHitsGame02(numHits);
                GameManager.instance.setLevel03Enemy01Done(true);
                SceneManager.LoadScene(toLevel03);
            }
           
        }
    }
}
