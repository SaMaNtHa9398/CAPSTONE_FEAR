using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshPro _promptText;
    
    void Start()
    {
        // mainCam = Camera.main;
        uiPanel.SetActive(false);
    }

    private void LateUpdate()

    {
 
    //var rotation = mainCam.transform.rotation;
 
    //transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up); 
  
    }

    public bool IsDisplayed = false;

    public void SetUp(string promptText)

    {
    
        _promptText.text = promptText;
    
        uiPanel.SetActive(true);
   
        IsDisplayed = true;
    
    }

    public void Close()

    {
   
        uiPanel.SetActive(false);
    
        IsDisplayed = false;
    
    }

}

