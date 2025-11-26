using UnityEngine;
using UnityEngine.UI;

public class DialogueEvent : MonoBehaviour
{
    public Image dialogueBox;
    private bool dialogueComplete;
    public bool spaceGuyHitLevel1;
    public GameObject spaceGuy;

    public bool level01;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //For some reason in level01 when SpaceGuy was touching the trigger for
        //a dialogue event nothing would happen, I had to find some other method
        if (spaceGuyHitLevel1)
        {
            if (spaceGuy != null && !dialogueComplete)
            {
                if (Vector2.Distance(spaceGuy.transform.position, transform.position) < 1.0f)
                {
                    dialogueBox.gameObject.SetActive(true);
                    dialogueComplete = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (spaceGuyHitLevel1)
        //{
        //    if (collision.gameObject.layer == LayerMask.NameToLayer("Character01") && !dialogueComplete)
        //    {
        //        dialogueBox.gameObject.SetActive(true);
        //        dialogueComplete = true;
        //    }
        //}

        if (level01)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Character02") && !dialogueComplete)
            {
                dialogueBox.gameObject.SetActive(true);
                dialogueComplete = true;
            }
        }
        
        else
        {
            if (collision.gameObject.CompareTag("Player") && !dialogueComplete)
            {
                dialogueBox.gameObject.SetActive(true);
                dialogueComplete = true;
            }

            else if (collision.gameObject.CompareTag("SpaceGuy") && !dialogueComplete)
            {
                dialogueBox.gameObject.SetActive(true);
                dialogueComplete = true;
            }


        }
    }
}
