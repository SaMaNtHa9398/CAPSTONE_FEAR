using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
   
    public Text textDisplay;
    public string[] sentences;

    private int index;
    public float typingSpeed;
    
    public GameObject continueButton, ContinueButton2;
    public GameObject CollectablesPanel;

   void Start()
    {
       
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
        
        if (Input.GetKeyDown(KeyCode.F) && textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
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
          
                continueButton.SetActive(false);
                
            
           
        }

    }

}