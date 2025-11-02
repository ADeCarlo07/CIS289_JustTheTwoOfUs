using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutTo01 : MonoBehaviour
{
    public float maxTime = 7f;
    private float elapsedTime = 0;
    public string nextLevelName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= maxTime)
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
