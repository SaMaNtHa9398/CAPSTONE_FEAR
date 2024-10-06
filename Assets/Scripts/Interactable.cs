using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal context;
 
    public bool playerInRange;
  
    private void OnTriggerEnter(Collider other)
 
    {
  
        if (other.CompareTag("mila") && !other.isTrigger)
 
        {
 
        context.Raise();
  
        playerInRange = true; 
 
        }

    }

    private void OnTriggerExit(Collider other)

    {
    
        if (other.CompareTag("mila") && !other.isTrigger)
        
        {
       
                context.Raise();
        
                playerInRange = false;
        
        }
    
    }

}
