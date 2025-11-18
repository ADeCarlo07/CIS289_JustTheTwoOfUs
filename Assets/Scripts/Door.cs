using UnityEngine;

public class Door : MonoBehaviour
{
    private void Awake()
    {
       
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.setNumberOfHearts(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.triggerTutorialButton01 && GameManager.instance.triggerTutorialButton02)
        {
            this.gameObject.SetActive(false);
        }
    }
}
