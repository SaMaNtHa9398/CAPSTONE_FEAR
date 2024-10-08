using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Chest");
        return true;
    }
}
