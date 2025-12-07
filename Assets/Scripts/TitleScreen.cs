using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Image controls;
    public Image credits;

    public GameObject controlsNextArrow;
    public GameObject creditsNextArrow;

    public Material curvedMatieral;
    public Material upsidedownCurvedMaterial;

    public GameObject reusme;

    public Button retry;
    public Button quit;
    public Button controlsB;
    public Button creditsB;
    public Button resume;

    public bool pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.instance != null)
        {
            Destroy(GameManager.instance);
            Level03_HeartCanvas.destroyInstance();
        }
        

        curvedMatieral.SetFloat("_PlayerOffset", 0);
        upsidedownCurvedMaterial.SetFloat("_PlayerOffset", 0);
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void retryButton()
    {
        SceneManager.LoadScene("Title");
    }

    public void creditsButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsNextArrow);

        retry.enabled = false;
        quit.enabled = false;
        controlsB.enabled = false;
        creditsB.enabled = false;

        credits.gameObject.SetActive(true);


    }

    public void controlsButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsNextArrow);


        retry.enabled = false;
        quit.enabled = false;
        controlsB.enabled = false;
        creditsB.enabled = false;

        controls.gameObject.SetActive(true);


    }

    public void nextArrowControls()
    {
        if (pauseMenu)
        {
            resume.enabled = true;
        }

        retry.enabled = true;
        quit.enabled = true;
        controlsB.enabled = true;
        creditsB.enabled = true;


        controls.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(reusme);
    }

    public void nextArrowCredits()
    {
        if (pauseMenu)
        {
            resume.enabled = true;
        }
        retry.enabled = true;
        quit.enabled = true;
        controlsB.enabled = true;
        creditsB.enabled = true;

        credits.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(reusme);
    }
}
