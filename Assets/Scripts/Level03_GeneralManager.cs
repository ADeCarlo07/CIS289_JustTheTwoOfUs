using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Level03_GeneralManager : MonoBehaviour
{
    //No longer in use
    public Transform spaceGuyPosEnemy01;
    public Transform spaceGuyPosEnemy02;
    public Transform spaceGuyPosEnemy03;
    public Transform spaceDogPosEnemy01;
    public Transform spaceDogPosEnemy02;
    public Transform spaceDogPosEnemy03;

    public GameObject spaceDog;
    public GameObject spaceGuy;
    public GameObject spaceGuyR;
    public GameObject spaceDogR;


    public GameObject startingDialogue;
    public GameObject enemy01Dialogue;
    public GameObject enemy02Dialogue;
    public GameObject enemy03Dialogue;

    private bool transported = false;

    public GameObject heartUI;
    public GameObject heartContainer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
        StartCoroutine(lateStart());
    }

    IEnumerator lateStart()
    {
        while (GameManager.instance == null)
        {
            //wait until GameManager exists
            yield return null;
        }
            
        if (!transported)
        {
            if (GameManager.instance.getLevel03Enemy03Done())
            {

                startingDialogue.SetActive(false);
                enemy03Dialogue.SetActive(false);
                enemy01Dialogue.SetActive(false);
                enemy02Dialogue.SetActive(false);
                Transport(spaceDogPosEnemy03, spaceGuyPosEnemy03);
            }
            else if (GameManager.instance.getLevel03Enemy01Done())
            {
                startingDialogue.SetActive(false);
                enemy01Dialogue.SetActive(false);
                enemy02Dialogue.SetActive(false);
                Transport(spaceDogPosEnemy01, spaceGuyPosEnemy01);
            }
            else if (GameManager.instance.getLevel03Enemy02Done())
            {
                startingDialogue.SetActive(false);
                enemy02Dialogue.SetActive(false);
                //enemy01Dialogue.SetActive(false);
                Transport(spaceDogPosEnemy02, spaceGuyPosEnemy02);
            }


            transported = true;
        }

    }

    private void Awake()
    {
        
    }


    private void Transport(Transform dogPos, Transform guyPos)
    {
        spaceDog.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        spaceGuy.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        if (spaceDog.GetComponent<PlayerController>().enabled)
        {
            spaceDog.GetComponent<PlayerController>().enabled = false;
        }
        spaceDog.GetComponent<Rigidbody2D>().gravityScale = 0;

        spaceDog.transform.position = dogPos.position;
        spaceGuy.transform.position = guyPos.position;
 

        spaceDogR.transform.position = spaceDog.transform.position;
        spaceGuyR.transform.position = spaceGuy.transform.position;
    }





    // Update is called once per frame
    void Update()
    {
       
    }
}
