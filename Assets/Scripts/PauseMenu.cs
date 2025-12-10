using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject credits;
    public GameObject creditsNextArrow;
    public GameObject controls;
    public GameObject controlsNextArrow;
    public bool tutorial;
    public bool level1;
    public bool level2;
    public bool level2Special;
    public bool level3;
    public bool rhythymGame;
    public GameObject backgroundMusic;
    public GameObject chaseMusic;
   //private float time;
    //private float chaseTime;

    private bool isPaused;

    public GameObject pauseFirstButton;

    private bool isCrediting;
    private bool isControlling;

    public GameObject managerLevel03Special;

    public Button resume;
    public Button retry;
    public Button quit;
    public Button controlsB;
    public Button creditsB;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && !isPaused)
        {
            if (tutorial)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = false;
                //time = backgroundMusic.GetComponent<AudioSource>().time;
                backgroundMusic.GetComponent<AudioSource>().Pause();
            }
            else if (level1)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController_SpecialLevel01>().canMove = false;
                //time = backgroundMusic.GetComponent<AudioSource>().time;
                backgroundMusic.GetComponent<AudioSource>().Pause();
            }
            else if (level2)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = false;
                //time = backgroundMusic.GetComponent<AudioSource>().time;
                backgroundMusic.GetComponent<AudioSource>().Pause();
            }
            else if (level2Special)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController_Level02Special>().enabled = false;
                //time = backgroundMusic.GetComponent<AudioSource>().time;
                backgroundMusic.GetComponent<AudioSource>().Pause();
                //chaseTime = chaseMusic.GetComponent<AudioSource>().time;
                chaseMusic.GetComponent<AudioSource>().Pause();
            }
            else if (level3)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = false;
                //time = backgroundMusic.GetComponent<AudioSource>().time;
                backgroundMusic.GetComponent<AudioSource>().Pause();
            }


            else if (rhythymGame)
            {
               managerLevel03Special.GetComponent<PlayerController_SpecialLevel03>().enabled = false;
               //time = backgroundMusic.GetComponent<AudioSource>().time;
                backgroundMusic.GetComponent<AudioSource>().Pause();
            }

            Time.timeScale = 0;
            
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
            isPaused = true;
        }
    }
   
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

  


    public void ResumeGame()
    {
        if (tutorial)
        {
            GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = true;
            //backgroundMusic.GetComponent<AudioSource>().time = time;
            backgroundMusic.GetComponent<AudioSource>().UnPause();
        }
        else if (level1)
        {
            //if (GameManager.instance.playingAsSpaceDog())
            //{
            //    Physics2D.gravity = new Vector2(0, -9.8f);
            //}
            //else
            //{
            //    Physics2D.gravity = new Vector2(0, 9.8f);
            //}

            GameManager.instance.getTargetPlayer().GetComponent<PlayerInput>().actions["Jump"].Reset();

            GameManager.instance.getTargetPlayer().GetComponent<PlayerController_SpecialLevel01>().canMove = true;


            GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;



            //backgroundMusic.GetComponent<AudioSource>().time = time;
            backgroundMusic.GetComponent<AudioSource>().UnPause();
        }
        else if (level2)
        {
            GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = true;
            //backgroundMusic.GetComponent<AudioSource>().time = time;
            backgroundMusic.GetComponent<AudioSource>().UnPause();
        }
        else if (level2Special)
        {
            GameManager.instance.getTargetPlayer().GetComponent<PlayerController_Level02Special>().enabled = true;
            //backgroundMusic.GetComponent<AudioSource>().time = time;
            backgroundMusic.GetComponent<AudioSource>().UnPause();
            //chaseMusic.GetComponent<AudioSource>().time = chaseTime;
            chaseMusic.GetComponent<AudioSource>().UnPause();
        }
        else if (level3)
        {
            GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = true;
           // backgroundMusic.GetComponent<AudioSource>().time = time;
            backgroundMusic.GetComponent<AudioSource>().UnPause();
        }
        else if (rhythymGame)
        {
            managerLevel03Special.GetComponent<PlayerController_SpecialLevel03>().enabled = true;
            //backgroundMusic.GetComponent<AudioSource>().time = time;
            backgroundMusic.GetComponent<AudioSource>().UnPause();
        }


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
            Physics2D.gravity = new Vector2(0, -9.8f);

            GameManager.instance.setLevel1Collectable(0);

            SceneManager.LoadScene("Level01DEMO");
           
        }

        if (level2)
        {
            GameManager.instance.setLevel2Collectable(0);
            SceneManager.LoadScene("Level02");
           
        }
        if (level2Special)
        {
            GameManager.instance.setLevel2Collectable(0);
            SceneManager.LoadScene("Level02");
        }

        if (level3)
        {
            Level03_HeartCanvas.destroyInstance();


            GameManager.instance.setLevel3Collectable(0);
            GameManager.instance.setLevel03Enemy01Done(false);
            GameManager.instance.setLevel03Enemy02Done(false);
            GameManager.instance.setLevel03Enemy03Done(false);
            GameManager.instance.setNumOfHitsGame01(0);
            GameManager.instance.setNumOfHitsGame02(0);
            GameManager.instance.setNumOfHitsGame03(0);
            GameManager.instance.curDamageDoneLevel03 = 0;
            GameManager.instance.curHeartsLevel03 = 0;
            SceneManager.LoadScene("Level03DEMO");
            
        }

        if (rhythymGame)
        {
            Level03_HeartCanvas.destroyInstance();

            GameManager.instance.setLevel3Collectable(0);
            GameManager.instance.setLevel03Enemy01Done(false);
            GameManager.instance.setLevel03Enemy02Done(false);
            GameManager.instance.setLevel03Enemy03Done(false);
            GameManager.instance.setNumOfHitsGame01(0);
            GameManager.instance.setNumOfHitsGame02(0);
            GameManager.instance.setNumOfHitsGame03(0);
            SceneManager.LoadScene("Level03DEMO");
        }

    }

    public void Credits()
    {
        resume.enabled = false;
        retry.enabled = false;
        quit.enabled = false;
        controlsB.enabled = false;
        creditsB.enabled = false;

        credits.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsNextArrow);
    }

    public void Controls()
    {
        resume.enabled = false;
        retry.enabled = false;
        quit.enabled = false;
        controlsB.enabled = false;
        creditsB.enabled = false;

        controls.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsNextArrow);
    }


}
