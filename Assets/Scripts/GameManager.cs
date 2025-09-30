using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject targetPlayer;
    private GameObject otherPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject getTargetPlayer()
    {
        return targetPlayer;
    }

    public GameObject getOtherPlayer()
    {
        return otherPlayer;
    }

    public void setTargetPlayer(GameObject t)
    {
        targetPlayer = t;
    }

    public void setOtherPlayer(GameObject o)
    {
        otherPlayer = o;
    }
}
