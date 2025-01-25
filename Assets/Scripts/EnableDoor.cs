using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDoor : MonoBehaviour
{
    SlidingPuzzle sliding;
    InteractableCounter counters;
    DescructibleWall walls; 
    public int Number; 
    private void Start()
    {
        sliding = GetComponent<SlidingPuzzle>();
        counters = GetComponent<InteractableCounter>();
        walls = GetComponent<DescructibleWall>(); 
    }
    private void Update()
    {
        //if (sliding.ConditionMeet() >= Number) // Replace with your own condition
        {
            
        }
    }
    
}
