using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialAnimation : MonoBehaviour
{
    public Image dialogue;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogue.gameObject.activeSelf)
        {
            animator.SetTrigger("Start");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Tutorial") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            SceneManager.LoadScene("TutorialToLevel01");
        }
        
    }
}
