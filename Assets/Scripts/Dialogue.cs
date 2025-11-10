using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;   
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLines
    {
        public string line;
        public Sprite characterDialogueBox;
       
        


        public string getLine()
        {
            return line;
        }

        public void setLine(string l)
        {
            line = l;
        }

        public Sprite getCharDialogueBox()
        {
            return characterDialogueBox;
        }

        public void setCharDialogueBox(Sprite s)
        {
            characterDialogueBox = s;
        }


        public DialogueLines(string l, Sprite s)
        {
            line = l;
            characterDialogueBox = s;
        }
        public DialogueLines()
        {

        }
    
    
    }

    public Image image;
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    private int index;
    public List<DialogueLines> dialogueLines = new List<DialogueLines>();
    public bool level01;
    public bool level02;
    public bool level02_underwater;
    public bool level03;
    public bool tutorial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        textComponent.text = string.Empty;
        if (dialogueLines.Count > 0 )
        {
            

            if (level01)
            {
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController_SpecialLevel01>().enabled = false;
            }
            else if (level02)
            {
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = false;
            }
            else if (level02_underwater)
            {
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController_Level02Special>().enabled = false;
            }
            else if (level03)
            {
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = false;
            }
            else if (tutorial)
            {
                GameManager.instance.getTargetPlayer().GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = false;
            }
            else
            {
                
            }
                
            StartDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;
        DialogueLines currentLine = dialogueLines[index];

        //swap sprite
        if (image != null && currentLine.getCharDialogueBox() != null)
        {
            image.sprite = currentLine.getCharDialogueBox();
        }
        
        foreach (char c in currentLine.getLine().ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }

    public void NextArrowPressed()
    {
        if (textComponent.text == dialogueLines[index].getLine())
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = dialogueLines[index].getLine();
        }
    }

    void NextLine()
    {
        if (index < dialogueLines.Count - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {

            if (level01)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController_SpecialLevel01>().enabled = true;
            }
            else if (level02)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = true;
            }
            else if (level02_underwater)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController_Level02Special>().enabled = true;
            }
            else if (level03)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = true;
            }
            else if (tutorial)
            {
                GameManager.instance.getTargetPlayer().GetComponent<PlayerController>().enabled = true;
            }
            else
            {

            }
            gameObject.SetActive(false);
        }
    }

}
