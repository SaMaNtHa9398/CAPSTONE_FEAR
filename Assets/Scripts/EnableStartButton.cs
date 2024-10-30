using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnableStartButton : MonoBehaviour
{
    [SerializeField] private Button buttonComponent;
    [SerializeField] private Image imageComponent;
    [SerializeField] private Text textComponent;
    public string Tag;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void OntriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        if (other.gameObject.CompareTag(Tag))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            buttonComponent.enabled = true;
            imageComponent.enabled = true;
            textComponent.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        buttonComponent.enabled = false;
        imageComponent.enabled = false;
        textComponent.enabled = false;
    }
}



