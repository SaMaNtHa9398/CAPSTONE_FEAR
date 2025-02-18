using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
   
    public TextMeshProUGUI textDisplay;
    //public Image pfppic, imagerepe; 
    public string[] sentences;

   private int index;
    public float typingSpeed;
    //public Image[] pfp; 
    public GameObject continueButton, ContinueButton2;
    //public GameObject CollectablesPanel;

   void Start()
    {
        SetCursor();  // Make sure the cursor is unlocked at the start
        StartCoroutine(Type());
        ContinueButton2.SetActive(false);
    }

    void SetCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void reverseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
     
    }
    
    public void NextSentence()
    {
        //continueButton.SetActive(false);
       // PictureMover(); 

        if(index <sentences.Length -1 )
        {
            index++;
          
            textDisplay.text = " ";
            StartCoroutine(Type());
        }else
        {
            textDisplay.text = " ";
          
                continueButton.SetActive(false);
                ContinueButton2.SetActive(true);
            //CollectablesPanel.SetActive(true);
            reverseCursor(); 
           
        }

    }

}