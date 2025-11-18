using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject credits;
    public GameObject controls;
    public bool tutorial;
    public bool level1;
    public bool level2;
    public bool level2Special;
    public bool level3;
    //public bool rhythymGame;

    private bool isPaused;

    public GameObject pauseFirstButton;

    private bool isCrediting;
    private bool isControlling;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && !isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
    }
   

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;

    }

    public void RestartLevel()
    {
        isPaused = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);

        if (tutorial)
        {
            GameManager.instance.setTutorialCollectable(0);
            GameManager.instance.triggerTutorialButton01 = false;
            GameManager.instance.triggerTutorialButton02 = false;

            SceneManager.LoadScene("Tutorial");
           
        }
         
        if (level1)
        {
            GameManager.instance.setLevel1Collectable(0);

            SceneManager.LoadScene("Level01");
           
        }

        if (level2)
        {

            SceneManager.LoadScene("Level02");
           
        }

        if (level2Special)
        {
            GameManager.instance.setLevel2Collectable(0);

            SceneManager.LoadScene("Level02_Underwater");
          
        }

        if (level3)
        {
            GameManager.instance.setLevel3Collectable(0);
 
            SceneManager.LoadScene("Level03");
            
        }

    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void Controls()
    {
        controls.SetActive(true);
    }


}
