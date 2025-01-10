using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDoor : MonoBehaviour
{
    InteractableCounter interactableCounter;
    SlidingPuzzle sliding;
    public GameObject Door;
   

    // Start is called before the first frame update
    void Start()
    {
        Door.SetActive(true); 
       
    }

    // Update is called once per frame
    void Update()
    {
        if (sliding.ConditionMeet || interactableCounter.ConditionMeet)
        {
            Door.SetActive(false); 
            // will be adding the Door Disppearing Act with physicals
        }
    }
}
