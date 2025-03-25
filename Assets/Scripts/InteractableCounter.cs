using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableCounter : MonoBehaviour
{
    public string Tag;
    public int interactionsNum = 0;
    public int requiredInteractions = 4;
    public List<GameObject> gameObjs = new List<GameObject>();
    //public GameObject PuzzleImage;
    //public TextMeshPro Text;
    //public GameObject door;
   // public GameObject interactionCounterTurnactive;
    //public bool ConditionMeet = false;
    public GameObject TriggerArea;
    public DescructibleWall wall;
   
    AudioManager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); 
    }
    private void Start()
    {
        //door.SetActive(true);
        //interactionCounterTurnactive.SetActive(false);
        TriggerArea.SetActive(true);
        

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);


        if (other.gameObject.CompareTag(Tag))
        {
          if (!gameObjs.Contains(other.gameObject))
            {
               gameObjs.Add(other.gameObject); 
                 interactionsNum += 1;
            }

           // Text.text = interactionsNum.ToString();

        }




        if (interactionsNum == requiredInteractions)
        {
            
            audiomanager.PlaySfx(audiomanager.CorrectSound); 
            TriggerArea.SetActive(false);
            interactionsNum = requiredInteractions;
            wall.Open(); 
        }

        if(interactionsNum >= requiredInteractions)
        {
            interactionsNum = requiredInteractions;
            
        }
    }
}
