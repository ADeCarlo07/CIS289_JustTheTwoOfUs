using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartDamage : MonoBehaviour
{
    public Image heartUI;
    public int curHealth = 4;
    private int maxHealth = 4;
    public GameObject heartList;
    private int heartCount;
    public AudioSource audioSource;
    public GameObject backGroundMusic;

    public bool level03;

    private bool initalized = false;

    private void Start()
    {
       
        

        if (level03)
        {
            //DontDestroyOnLoad(this.gameObject);
            if (!initalized)
            {
                curHealth = maxHealth;
                initalized = true;
            }

            
        }
        else
        {
            curHealth = maxHealth;
        }

    }

    private void UpdateHealthBar()
    {
        float health = (float)curHealth / maxHealth;
        heartUI.fillAmount = health;

    }

    public int GetCurrentHealth()
    {
        return curHealth;
    }

    public void SetHealth(int value)
    {
        curHealth = Mathf.Clamp(value, 0, maxHealth);
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {

        Debug.Log("player damage: " + damage);
        curHealth -= damage;

        //ensures everything stays in valid range
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
        UpdateHealthBar();

        if (curHealth <= 0)
        {
            heartCount = heartList.GetComponent<HeartUI>().currentHearts;
            Debug.Log("Heart Count: " + heartCount);

            heartCount--;

            heartList.GetComponent<HeartUI>().UpdateHeartDisplay(heartCount);

            if (heartCount == 0)
            {
                if (backGroundMusic != null)
                {
                    AudioSource audioS = backGroundMusic.GetComponent<AudioSource>();
                    audioS.Stop();
                    audioSource.Play();
                }
                
            }
            else
            {
                if (audioSource.isPlaying)
                {
                    AudioSource audioS = backGroundMusic.GetComponent<AudioSource>();
                    audioS.Play();
                    audioSource.Stop();
                }
              
            }

            if (heartCount < 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                curHealth = maxHealth;
                UpdateHealthBar();
            }
        }
    }

    public void heal(int healthAdded)
    {
        curHealth += healthAdded;

        //if (curHealth > maxHealth)
        //{
           
        //    heartCount = heartList.GetComponent<HeartUI>().currentHearts;

        //    if (heartCount < GameManager.instance.numberOfHearts)
        //    {
        //        heartCount++;

        //        heartList.GetComponent<HeartUI>().UpdateHeartDisplay(heartCount);
        //    }
            

        //}

        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
        UpdateHealthBar();


    }
}
