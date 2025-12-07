using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform heartContainer;

    private List<Image> heartImages = new List<Image>();

    public int currentHearts;

    private Transform heartTransform;

    public bool level03;

    private bool initalized;

    private void Start()
    {
        if (level03)
        {
            if (!initalized)
            {
                currentHearts = GameManager.instance.getNumberOfHearts();
                UpdateHeartDisplay(currentHearts);
                initalized = true;

            }

       
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            currentHearts = GameManager.instance.getNumberOfHearts();
            UpdateHeartDisplay(currentHearts);
        }
       
    }

   

    public void UpdateHeartDisplay(int newHealth)
    {
        currentHearts= newHealth;
        Vector3 nextPosition = Vector3.zero;
        //Add more hearts if needed
        while (heartImages.Count < currentHearts)
        {
            GameObject heart = Instantiate(heartPrefab, heartContainer);
            heart.transform.localPosition = nextPosition;

            Transform offsetTransform = heart.transform.Find("Offset");
            if (offsetTransform != null)
            {
                nextPosition += offsetTransform.localPosition;
            }
            else
            {
                Debug.LogWarning("Offset transform not found in heart prefab.");
            }


            heartImages.Add(heart.GetComponent<Image>());
        }

        //Enable only the number of hearts equal to current health
        for (int i = 0; i < heartImages.Count; i++)
        {
            heartImages[i].enabled = i < currentHearts;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHearts = Mathf.Max(currentHearts - amount, 0);
        UpdateHeartDisplay(currentHearts);
    }

    public void Heal(int amount)
    {
        currentHearts += amount;
        UpdateHeartDisplay(currentHearts);
    }



}
