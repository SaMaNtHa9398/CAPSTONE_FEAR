using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{

    public GameObject haunt;
    public AudioSource Sound; 
    public string triggertag;
    BoxCollider BOX;
    private void Awake()
    {
        Sound = GetComponent<AudioSource>();
        BOX = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        if(haunt)
        {
            haunt.SetActive(false);
        }
        else
        {
            haunt = null; 
        }
     
    }
    private void OnTriggerEnter(Collider other)
    {
       //RobotLogicPuzzle2Easy robot =  Robot.GetComponent<RobotLogicPuzzle2Easy>();
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);

        if (other.gameObject.CompareTag(triggertag))
        {
            if (haunt != null)
            {
                haunt.SetActive(true);
            }

            if (Sound != null)
            {
                Sound.Play();
            }
        }

    }
    private void OnTriggerExit(Collider min)
    {
        //RobotLogicPuzzle2Easy robot =  Robot.GetComponent<RobotLogicPuzzle2Easy>();
        Debug.Log("OnTriggerExit called with: " + min.gameObject.name);
        if (min.gameObject.CompareTag(triggertag))
        {
        
            Destroy(gameObject); 
            return;
        }
    }
}
