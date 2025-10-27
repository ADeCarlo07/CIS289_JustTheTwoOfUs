using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceGuyTransporter : MonoBehaviour
{
    public Material material;
    public Image dialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceGuy"))
        {
            if (!dialogue.gameObject.activeSelf)
            {
                SceneManager.LoadScene("Level02_Underwater");
                material.SetFloat("_PlayerOffset", 0);
            }
        }

    }
}
