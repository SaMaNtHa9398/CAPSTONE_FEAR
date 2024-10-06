using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceInteractable : MonoBehaviour
{
    public string InteractionPrompt { get; }
    public bool Interact(Interactor interactor);
}

