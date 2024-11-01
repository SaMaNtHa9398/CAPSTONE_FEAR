using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    /* // this code was from brackeys or Bmo 
    public Queue <string> sentences;
    private void Start()
    {
        sentences = new Queue<string>(); 
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Convo with " + dialogue.name); 
    }*/

    /*  //https://pastebin.com/aBtSXSt0 

      public static DialogueManager Instance; 

      public Image characterIcon;

      public TextMeshProUGUI characterName;
      public TextMeshProUGUI dialogueArea;

      private Queue<DialogueLine> lines;

      public bool isDialogueActive = false;
      public float typingSpeed = 0.2f;

      public Animator animator;

      private void Awake()
      {
          if (Instance == null)
              Instance = this;

          lines = new Queue<DialogueLine>(); 
      }

      public void StartDialogue(Dialogue dialogue)
      {
          isDialogueActive = true;

          animator.Play("show");

          lines.Clear();

          foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
          {
              lines.Enqueue(dialogueLine);
          }

          DisplayNextDialogueLine();
      }
      public void DisplayNextDialogueLine()
      {
          if (lines.Count == 0)
          {
              EndDialogue();
              return;
          }

          DialogueLine currentLine = lines.Dequeue();

          characterIcon.sprite = currentLine.character.icon;
          characterName.text = currentLine.character.name;

          StopAllCoroutines();

          StartCoroutine(TypeSentence(currentLine));
      }

      IEnumerator TypeSentence(DialogueLine dialogueLine)
      {
          dialogueArea.text = "";
          foreach (char letter in dialogueLine.line.ToCharArray())
          {
              dialogueArea.text += letter;
              yield return new WaitForSeconds(typingSpeed);
          }
      }

      void EndDialogue()
      {
          isDialogueActive = false;
          animator.Play("hide");
      }
  }
    */

    public TextMeshProUGUI textDisplay;
    public string[] sentences;

    private int index;
    public float typingSpeed;
    public Image[] pfp; 
    public AudioSource[] voicelines;
    public Image[] imagesRepresentation; 
    public GameObject continueButton;
    public GameObject Collectables;

    private void Start()
    {
        Collectables.SetActive(false);
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            
            yield return new WaitForSeconds(typingSpeed); 
        }
    }
    public void  PictureMover()
    {
       foreach(Image pfpic in pfp)
        {
            pfpic.enabled = !pfpic.enabled; 
        }

       foreach(Image ir in imagesRepresentation)
        {
            ir.enabled = !ir.enabled; 
        }

       foreach(AudioSource vl in voicelines)
        {
            if (vl.isPlaying)
            {
                vl.Stop(); 
            }
            else
            {
                vl.Play();
            }
        }
    }
    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true); 
        }
        if( index == sentences.Length)
        {
            Collectables.SetActive(true); 
        }

    }

    public void NextSentence()
    {
        continueButton.SetActive(true);
        PictureMover(); 

        if(index <sentences.Length -1 )
        {
            index++;
            textDisplay.text = " ";
            StartCoroutine(Type());
        }else
        {
            textDisplay.text = " "; 
        }
    }

}