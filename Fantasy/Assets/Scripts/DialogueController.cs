using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueController : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text nameText;
    [SerializeField] private PlayerAudio dialogueAudio;
    public string[] dialogue;
    public string[] names;
    public int index;
    public int index2;
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

        nameText.text = names[index];
        
        if(nameText.text == "Pixie")
        {
            nameText.color = new Color32(75, 229, 212, 255);
        }
        else
        {
            nameText.color = new Color32(188, 65, 179, 255);
        }
    }
        
    public void zeroText()
        {
            dialogueText.text = " ";
            nameText.text = " ";
            dialoguePanel.SetActive(false);
        }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
            dialogueAudio.PlaySFX(dialogueAudio.dialogueSound);
        }

        

        /*colocar aqui o nome por atribuindo a variável nameText o primeiro valor do array names
         porém pesquisar como converter string para o tipo text na unity
         */
    }

    public void startDialogue()
    {
        StartCoroutine(Typing());
    }

    public void nextLine()
    {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                index++;
                index2++;
                dialogueText.text = " ";
                nameText.text = " ";
                StartCoroutine(Typing());
                //change the names index value here, everythime player press the input key the index goes to the next what mean + 1
                if(index >= dialogue.Length)
                {
                    zeroText();
                }
            }

    }
}
