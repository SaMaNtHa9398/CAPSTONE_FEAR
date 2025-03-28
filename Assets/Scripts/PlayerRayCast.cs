using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public Transform headPos;
    public int length;

    private ClickButton clickButton; 

    private void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(headPos.position, headPos.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(headPos.position, headPos.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            float distance = Vector3.Distance(transform.position, hit.transform.position);
            if (distance <= length)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform.GetComponent<KeypadKeys>() != null)
                    {
                        hit.transform.GetComponent<KeypadKeys>().SendKey();
                    }
                    /*else if (hit.transform.name == "Door")
                    {
                       // hit.transform.GetComponent<doo>().OpenClose();
                    }*/

                }
                else if(Input.GetMouseButtonDown(2))
                {
                    ClickButton clickObj = hit.collider.GetComponent<ClickButton>(); 
                    if(clickObj != null)
                    {
                        clickObj.OnMouseDown();
                        clickButton = clickObj; 
                    }
                }
                if(Input.GetMouseButtonUp(2))
                {
                    if (clickButton != null)
                    {
                        clickButton.OnMouseUp();
                        clickButton = null; 
                    }
                }

            }
        }

    }

}
