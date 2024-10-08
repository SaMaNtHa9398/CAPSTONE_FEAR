using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    /*public Signal context;
 
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
    
    }*/

    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);

    } 
}
