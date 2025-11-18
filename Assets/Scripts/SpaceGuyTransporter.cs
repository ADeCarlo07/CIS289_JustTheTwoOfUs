using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceGuyTransporter : MonoBehaviour
{
    //Special case script for level02

    public Material material;
    public Image dialogue;
    public string scene;
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
                SceneManager.LoadScene(scene);
                material.SetFloat("_PlayerOffset", 0);
            }
        }

    }
}
