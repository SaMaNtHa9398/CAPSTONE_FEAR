using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reveal : MonoBehaviour
{
   [SerializeField] GameObject Mat;
    [SerializeField] Light spotlight;

    public GameObject lantern; 
    public float lightReach = 5f;
    public Transform headPos;
    public bool RevealInsightRange;
    public LayerMask UI;
    private Lantern lanternCom;
    private void Start()
    {
       
        Mat.SetActive(false); 
    }
    private void Update()
    {
        RevealInsightRange = Physics.CheckSphere(headPos.position, lightReach, UI);
        RevealInsightRange = true; 
        if (RevealInsightRange) Activate();

    }
    private void Activate()
    {
        Mat.SetActive(true);
       
    }
    void CheckMaterial ()
    {
        /* RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(headPos.position, headPos.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(headPos.position, headPos.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            //if colliders with anything within player reach 
            if (Physics.Raycast(ray, out hit, lightReach))
            {
                if (hit.collider.tag == "Blood")
                {
                    Mat.SetActive(true);
                }
            }
            else
            {
                Mat.SetActive(false);
            }
        }*/

    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(headPos.position, lightReach);
     
    }*/

}



