
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level03_Enemy02 : MonoBehaviour
{
    //This was origionally going to be for one enemy, but
    //I'm most likely going to use it for all level 03 enemies
    //so disregard the name

    public bool perfect = false;
    public bool okay = false;
    public bool horrible = false;

    public bool enemy01;
    public bool enemy02;
    public bool enemy03;

    //public Image perfectDialogue;
    //public Image okayDialogue;
    //public Image horribleDialogue;

 

    private AudioSource audioSource;
    private Animator animator;

    private bool evaluated = false;

    public int max = 79;

    public bool start;


    public GameObject[] dialogues;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (!start)
        {
            audioSource = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();

            if (GameManager.instance.curHeartsLevel03 != 0)
            {
                Debug.Log("DAM" + GameManager.instance.curDamageDoneLevel03);
                Debug.Log("HAR " + GameManager.instance.curHeartsLevel03);


                //heartContainter.GetComponent<HeartUI>().currentHearts = GameManager.instance.curHeartsLevel03;
                
                //if (enemy01 && GameManager.instance.level03_02_eval != "p" && GameManager.instance.level03_03_eval != "")
                //{
                //    heartUI.GetComponent<HeartDamage>().SetHealth(GameManager.instance.curDamageDoneLevel03);
                //}
                
            }

        }

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ID " + GameManager.instance.id);
        if (!evaluated)
        {
            if (enemy02 && GameManager.instance.getLevel03Enemy02Done())
            {
                EvaluateHits(GameManager.instance.getNumOfHitsGame01());
               
                
                //GameManager.instance.setLevel03Enemy02Done(false);
            }
            else if (enemy01 && GameManager.instance.getLevel03Enemy01Done())
            {
                EvaluateHits(GameManager.instance.getNumOfHitsGame02());

                //GameManager.instance.setLevel03Enemy01Done(false);
            }
            else if (enemy03 && GameManager.instance.getLevel03Enemy03Done())
            {
                EvaluateHits(GameManager.instance.getNumOfHitsGame03());
                //GameManager.instance.setLevel03Enemy03Done(false);
            }

            Debug.Log("EvaluateHits called for Enemy01: " + GameManager.instance.getNumOfHitsGame02());


            if (perfect)
            {
                if (enemy01)
                {
                    GameManager.instance.level03_01_eval = "p";
                }
                else if (enemy02)
                {
                    GameManager.instance.level03_02_eval = "p";
                }
                else if (enemy03)
                {
                    GameManager.instance.level03_03_eval = "p";
                }
                dialogues[0].SetActive(true);
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            }
            else if (okay)
            {
                if (enemy01)
                {
                    GameManager.instance.level03_01_eval = "o";
                }
                else if (enemy02)
                {
                    GameManager.instance.level03_02_eval = "o";
                }
                else if (enemy03)
                {
                    GameManager.instance.level03_03_eval = "o";
                }
                dialogues[1].SetActive(true);
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            }
            else if (horrible)
            {
                if (enemy01)
                {
                    GameManager.instance.level03_01_eval = "h";
                }
                else if (enemy02)
                {
                    GameManager.instance.level03_02_eval = "h";
                }
                else if (enemy03)
                {
                    GameManager.instance.level03_03_eval = "h";
                }
                dialogues[2].SetActive(true);
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            }
            
            evaluated = true;
        }

    }

    void EvaluateHits(int numHits)
    {

        if (numHits >= max)
        {
            Debug.Log("perfect");
            perfect = true;
            //GameManager.instance.curDamageDoneLevel03 = heartUI.GetComponent<HeartDamage>().GetCurrentHealth();
            //GameManager.instance.curHeartsLevel03 = heartContainter.GetComponent<HeartUI>().currentHearts;
            return;
        }
        else
        {
            double percent = (double)numHits / max * 100.0;
            Debug.Log("PERCENT " + percent);

            if (percent >= 70)
            {
                Debug.Log("okay");
                okay = true;
                //okayDialogue.gameObject.SetActive(true);
                animator.SetTrigger("Attack");
                audioSource.Play();
                HeartDamage heartDamage = FindAnyObjectByType<HeartDamage>();
                heartDamage.TakeDamage(2);
                //GameManager.instance.curDamageDoneLevel03 = heartUI.GetComponent<HeartDamage>().GetCurrentHealth();
                //GameManager.instance.curHeartsLevel03 = heartContainter.GetComponent<HeartUI>().currentHearts;
                return;
            }
            else
            {
                Debug.Log("horrible");
                horrible = true;
                //horribleDialogue.gameObject.SetActive(true);
                animator.SetTrigger("Attack");
                audioSource.Play();
                HeartDamage heartDamage = FindAnyObjectByType<HeartDamage>();

                if (heartDamage.curHealth == 2)
                {
                    heartDamage.TakeDamage(2);
                    heartDamage.TakeDamage(2);
                }
                else
                {
                    heartDamage.TakeDamage(4);
                }

                
                //heartUI.GetComponent<HeartDamage>().TakeDamage(4);
                //GameManager.instance.curDamageDoneLevel03 = heartUI.GetComponent<HeartDamage>().GetCurrentHealth();
                //GameManager.instance.curHeartsLevel03 = heartContainter.GetComponent<HeartUI>().currentHearts;
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //I started working on the second enemy first for some reason, so
            //thats why the game numbers don't match the enemy number

            if (enemy01 && !GameManager.instance.getLevel03Enemy01Done())
            {
                SceneManager.LoadScene("Level03_Rhythm02");
            }

            if (enemy02 && !GameManager.instance.getLevel03Enemy02Done())
            {
                SceneManager.LoadScene("Level03_Rhythm01");
            }

            if (enemy03 && !GameManager.instance.getLevel03Enemy03Done())
            {
                SceneManager.LoadScene("Level03_Rhythm03");
            }
        }
    }

}
