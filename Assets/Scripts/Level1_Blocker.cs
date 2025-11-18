using UnityEngine;

public class Level1_Blocker : MonoBehaviour
{
    private bool hide;
    public GameObject level1Enemy3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hide = level1Enemy3.gameObject.GetComponent<Level1_Enemy3>().defeated;

        if (hide)
        {
            gameObject.SetActive(false);
        }
    }
}
