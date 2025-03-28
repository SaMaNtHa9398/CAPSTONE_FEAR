using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class HudControler : MonoBehaviour
{
    public static HudControler instance;

    private void Awake()
    {
        instance = this; 
    }

    [SerializeField] Text interactionText;

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + " (F)";
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
