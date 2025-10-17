using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject targetPlayer;
    private GameObject otherPlayer;
    private bool mustMoveCamera;
    private GameObject spaceDog;
    private bool spaceDogRotate;
    public static GameManager instance { get; private set; }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

  

    public GameObject getSpaceDog()
    {
        return spaceDog;
    }

    public void setSpaceDog(GameObject sd)
    {
        spaceDog = sd;
    }

    public bool playingAsSpaceDog()
    {
        if (targetPlayer == spaceDog)
        {
            setSpaceDogRotate(true);
            return true;
        }
        else
        {
            setSpaceDogRotate(false);
            return false;
        }
    }

    public void setSpaceDogRotate(bool set)
    {
        spaceDogRotate = set;
    }

    public bool getSpaceDogRotate()
    {
        return spaceDogRotate;
    }


    public bool getMustMoveCamera()
    {
        return mustMoveCamera;
    }

    public void setMustMoveCamera(bool mmc)
    {
        mustMoveCamera = mmc;
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
