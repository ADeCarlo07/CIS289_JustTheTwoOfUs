using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartDamage : MonoBehaviour
{
    public Image heartUI;
    public int curHealth;
    private int maxHealth = 4;
    public GameObject heartList;
    private int heartCount;
    public AudioSource audioSource;
    public GameObject backGroundMusic;

    private void Start()
    {
        curHealth = maxHealth;
    }
    
    private void UpdateHealthBar()
    {
        float health = (float)curHealth / maxHealth;
        heartUI.fillAmount = health;

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
                AudioSource audioS = backGroundMusic.GetComponent<AudioSource>();
                audioS.Stop();
                audioSource.Play();
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

        if (curHealth > maxHealth)
        {
            heartCount = heartList.GetComponent<HeartUI>().currentHearts;
            heartCount++;

            heartList.GetComponent<HeartUI>().UpdateHeartDisplay(heartCount);

        }

        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
        UpdateHealthBar();


    }
}
