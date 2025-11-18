using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject targetPlayer;
    private GameObject otherPlayer;
    private bool mustMoveCamera;
    private GameObject spaceDog;
    private bool spaceDogRotate;
    public bool triggerTutorialButton01;
    public bool triggerTutorialButton02;
    private int level1Collectables = 0;
    public int numberOfHearts;
    private int tutorialCollectables = 0;
    private int level2Collectables = 0;
    private int level3Collectables = 0;
    private int numOfHitsGame01;
    private int numOfHitsGame02;
    private int numOfHitsGame03;

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

    public void setNumOfHitsGame01(int n)
    {
        numOfHitsGame01 = n;
    }

    public int getNumOfHitsGame01()
    {
        return numOfHitsGame01;
    }

    public void setNumOfHitsGame02(int n)
    {
        numOfHitsGame02 = n;
    }

    public int getNumOfHitsGame02()
    {
        return numOfHitsGame02;
    }

    public void setumOfHitsGame03(int n)
    {
        numOfHitsGame03 = n;
    }

    public int getNumOfHitsGame03()
    {
        return numOfHitsGame03;
    }

    public void setNumberOfHearts(int h)
    {
        numberOfHearts = h;
    }

    public int getNumberOfHearts()
    {
        return numberOfHearts;
    }

    public void setLevel1Collectable(int c)
    {
        level1Collectables = c;
    }

    public void setLevel2Collectable(int c)
    {
        level2Collectables = c;
    }

    public void setLevel3Collectable(int c)
    {
        level3Collectables = c;
    }

    public void setTutorialCollectable(int c)
    {
        tutorialCollectables = c;
    }

    public void incrementLevel2Collectable()
    {
        level2Collectables++;
    }

    public int getLevel2Collectable()
    {
        return level2Collectables;
    }

    public void incrementLevel3Collectables()
    {
        level3Collectables++;
    }

    public int getLevel3Collectables()
    {
        return level3Collectables;
    }

    public void incrementTutorialCollectable()
    {
        tutorialCollectables++;
    }

    public int getTutoralCollectable()
    {
        return tutorialCollectables;
    }

    public void incrementLevel1Collectable()
    {
        level1Collectables++;
    }

    public int getLevel1Collectable()
    {
        return level1Collectables;
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
