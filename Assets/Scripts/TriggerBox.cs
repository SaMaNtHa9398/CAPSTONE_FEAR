using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{

    public GameObject Robot;
    public string triggertag;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
       RobotLogicPuzzle2Easy robot =  Robot.GetComponent<RobotLogicPuzzle2Easy>();
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        if (other.gameObject.CompareTag(triggertag))
        {
            if(robot != null) robot.StartGame();
        }
        else
        {
            return;
        }
    }
}
