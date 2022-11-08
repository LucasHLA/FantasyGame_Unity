using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueController : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public int index;
    [SerializeField] private float textSpeed;
    public bool isTalking;
    void Start()
    {
        isTalking = true;
    }

    public void Update()
    {
        if (index < dialogue.Length)
        {
            nextLine();
            isTalking = true;
        }
        else
        {
            isTalking = false;
        }
    }
        
    public void zeroText()
        {
            dialogueText.text = " ";
            dialoguePanel.SetActive(false);
        }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        
    }

    public void startDialogue()
    {
        StartCoroutine(Typing());
    }

    public void nextLine()
    {
            if (Input.GetKeyDown(KeyCode.H))
            {
                index++;
                dialogueText.text = " ";
                StartCoroutine(Typing());

                if(index >= dialogue.Length)
                {
                    zeroText();
                }
            }

    }
}
