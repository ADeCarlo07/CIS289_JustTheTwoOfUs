using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartDamage : MonoBehaviour
{
    public Image heartUI;
    public int curHealth;
    private int maxHealth = 4;
    public Image heartList;
    private int heartCount;

    private void Start()
    {
        
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

        if (curHealth >= 0)
        {
            heartCount = heartList.GetComponent<HeartUI>().currentHearts;

            heartCount--;

            heartList.GetComponent<HeartUI>().currentHearts = heartCount;

            heartUI.fillAmount = (float) curHealth / maxHealth;

            if (heartCount >= 0)
            {
                SceneManager.LoadScene("GameOver");
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
