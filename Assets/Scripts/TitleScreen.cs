using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Image controls;
    public Image credits;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
        Destroy(GameManager.instance);
        SceneManager.LoadScene("Title");
    }

    public void creditsButton()
    {
        credits.gameObject.SetActive(true);
    }

    public void controlsButton()
    {
        controls.gameObject.SetActive(true);
    }

    public void nextArrowControls()
    {
        controls.gameObject.SetActive(false);
    }

    public void nextArrowCredits()
    {
        credits.gameObject.SetActive(false);
    }
}
