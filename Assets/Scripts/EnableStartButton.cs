using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnableStartButton : MonoBehaviour
{
  
    [SerializeField] private Image imageComponent;
    [SerializeField] private GameObject haunt;
    
     public string Tag;

    // Start is called before the first frame update
    private void Start()
    {
        haunt.SetActive(false); 
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        if (other.gameObject.CompareTag(Tag))
        {
            imageComponent.enabled = true;
            haunt.SetActive(true); 
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        imageComponent.enabled = false;
        haunt.SetActive(false);
    }
}



