using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{

    public GameObject haunt;
    public AudioSource Sound; 
    public string triggertag;
    private void Start()
    {
        haunt.SetActive(false); 
    }
    private void OnTriggerEnter(Collider other)
    {
       //RobotLogicPuzzle2Easy robot =  Robot.GetComponent<RobotLogicPuzzle2Easy>();
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        if (other.gameObject.CompareTag(triggertag))
        {
            if(haunt != null) haunt.SetActive(true);
            if (Sound != null) Sound.Play();
        }
        else
        {
            haunt.SetActive(false); 
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //RobotLogicPuzzle2Easy robot =  Robot.GetComponent<RobotLogicPuzzle2Easy>();
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        if (other.gameObject.CompareTag(triggertag))
        {
          
          haunt.SetActive(false);
            Sound.Stop(); 
            Destroy(this); 
            return;
        }
    }
}
