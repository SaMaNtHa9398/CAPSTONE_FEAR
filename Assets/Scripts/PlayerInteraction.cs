using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactor currentInteractable;

    // Update is called once per frame
    void Update()
    {
        CheckInteraction(); 
        if(Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact(); 
        }
    }
    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); 
        //if colliders with anything within player reach 
        if(Physics.Raycast(ray, out hit, playerReach))
        {
            if(hit.collider.tag == "Interactable")
            {
                Interactor newInteractable = hit.collider.GetComponent<Interactor>();

                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                if(newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable); 
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactor newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HudControler.instance.EnableInteractionText(currentInteractable.message); 
    }
    void DisableCurrentInteractable()
    {
        HudControler.instance.DisableInteractionText(); 
        if(currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null; 
        }
    }
}
