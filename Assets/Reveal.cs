using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Reveal : MonoBehaviour
{
    [SerializeField] GameObject Mat;
    [SerializeField] Light Spotlight;

    public float lightReach = 5f;
    Interactor currentInteractable;

    private void Start()
    {
        Mat.SetActive(true); 
    }

    void CheckMaterial ()
    {
         RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //if colliders with anything within player reach 
        if (Physics.Raycast(ray, out hit, lightReach))
        {
            if (hit.collider.tag == "BloodPainting")
            {
                Mat.SetActive(false);
            }
        }
        else
        {
            Mat.SetActive(true);   
        }
    }    
}
