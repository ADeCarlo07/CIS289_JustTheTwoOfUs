
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level03_DescNextArrow : MonoBehaviour
{
    public Image controls;
    public GameObject backgroundMusic;
    public GameObject nextArrowB;

    public bool tutorial;
    public bool rhythm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controls.gameObject.activeSelf)
        {
            if (tutorial)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = false;
            }
            else if (rhythm)
            {
                this.gameObject.GetComponent<PlayerController_SpecialLevel03>().enabled = false;
            }

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(nextArrowB);
            Time.timeScale = 0;
        }
    }

    public void nextArrow()
    {
        if (tutorial)
        {
            GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = true;
        }
        else if (rhythm)
        {
            this.gameObject.GetComponent<PlayerController_SpecialLevel03>().enabled = true;
        }

        controls.gameObject.SetActive(false);
        Time.timeScale = 1;
        backgroundMusic.GetComponent<AudioSource>().Play();
      
    }
}
