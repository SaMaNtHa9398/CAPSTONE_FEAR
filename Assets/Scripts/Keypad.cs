using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using TMPro;

public class Keypad : MonoBehaviour
{
    //https://github.com/onursendot/digital-keypad-system/blob/master/KeypadSystem/Assets/KeypadSystem/Scripts/KeypadController.cs


    public string passcode;
    public int passcodelimit;
    //public GameObject door; 
    public TextMeshPro passcodeText;
     public DescructibleWall wall;
    public AudioClip wrong;
    public AudioClip clear;
    public AudioClip correct; 
    //[Header("Animation")]
   
   // public Animator doorAnim;
    //[SerializeField] private string openAnimationName = "DoorOpen";
    [Header("Audio")]

    AudioManager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
       // doorAnim = gameObject.GetComponent<Animator>();
        passcodeText.text = "";
      //door.SetActive(true); 
    }

    public void PasscodeEntry(string number)
    {
        Debug.Log($"PasscodeEntry called with number: {number}");
        if (number == "Clear")
        {
            Clear();
            return;
        }
        else if (number == "Enter")
        {
            Enter();
            return;
        }
        if (passcodeText.text.Length < passcodelimit)
        {
            // Update the text box with the new input
            passcodeText.text += number;
        }

        /* int length = passcodeText.text.ToString().Length;
         if (length < passcodelimit)
         {
             passcodeText.text = passcodeText.text + number;
         }*/
    }

    public void Clear()
    {
        
       passcodeText.text = "";
       // passcodeText.color = Color.white;
    }

    private void Enter()
    {
        if (passcodeText.text == passcode)
        {
            // door.SetActive(false); 
            //doorAnim.Play(openAnimationName, 0, 0.0f);
            //passcodeText.color = Color.green;
            audiomanager.PlaySfx(audiomanager.CorrectSound);
            StartCoroutine(waitAndClear());
            wall.Open();

        }
        else
        {
           // passcodeText.color = Color.red;
            StartCoroutine(waitAndClear());
            audiomanager.PlaySfx(audiomanager.WrongSound);
        }

    }
    IEnumerator waitAndClear()
    {
        yield return new WaitForSeconds(0.75f);
        Clear();
    }

}
