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
    private bool level03Enemy02Done;
    private bool level03Enemy01Done;
    private bool level03Enemy03Done;

    public int curDamageDoneLevel03 = 0;
    public int curHeartsLevel03 = 0;

    public int id = 0;

    public string level03_01_eval = "";
    public string level03_02_eval = "";
    public string level03_03_eval = "";


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
        Debug.Log("DAM_GM: " + curDamageDoneLevel03);
    }

    

    public void setLevel03Enemy02Done(bool b)
    {
        level03Enemy02Done = b;
    }

    public bool getLevel03Enemy02Done()
    {
        return level03Enemy02Done;
    }

    public void setLevel03Enemy01Done(bool b)
    {
        level03Enemy01Done = b;
    }

    public bool getLevel03Enemy01Done()
    {
        return level03Enemy01Done;
    }

    public void setLevel03Enemy03Done(bool b)
    {
        level03Enemy03Done = b;
    }

    public bool getLevel03Enemy03Done()
    {
        return level03Enemy03Done;
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

    public void setNumOfHitsGame03(int n)
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
