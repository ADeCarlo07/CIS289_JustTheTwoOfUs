using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using System;
using NUnit.Framework;
using System.Collections.Generic;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        textComponent.text = string.Empty;
        if (dialogueLines.Count > 0 )
        {
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
            gameObject.SetActive(false);
        }
    }

}
