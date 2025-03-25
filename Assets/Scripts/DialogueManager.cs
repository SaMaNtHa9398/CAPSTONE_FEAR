using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{

    /* public TextMeshProUGUI textDisplay;
     public string[] sentences;

     private int index;
     public float typingSpeed;

     public GameObject continueButton, ContinueButton2;
     public GameObject CollectablesPanel;

    void Start()
     {
         if (sentences.Length > 0)
         {
             StartCoroutine(Type()); // Start typing the first sentence
         }
     }


     IEnumerator Type()
     {
         foreach (char letter in sentences[index].ToCharArray())
         {
             textDisplay.text += letter;

             yield return new WaitForSeconds(typingSpeed);
         }


     }



     private void Update()
     {

         if (Input.GetKeyDown(KeyCode.R) && textDisplay.text == sentences[index])
         {
             NextSentence(); 
         }

     }

     public void NextSentence()
     {


         if(index <sentences.Length -1 )
         {
             index++;

             textDisplay.text = " ";
             StartCoroutine(Type());
         }else
         {
             textDisplay.text = " ";

                // continueButton.SetActive(false);



         }

     }*/


    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue(); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(textComponent.text == lines[index])
            {
                NextLine(); 
            } 
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index]; 
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine()); 
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    void NextLine()
    {
        if(index < lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine()); 
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}