using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public Material lmat;
    public Material nMat;

    //Use this for initilization
    private Renderer myRend;
    private Vector3 myTP;

    public int myNumber = 99;
    public RobotLogicPuzzle2Easy myLogic;
    public delegate void ClickEvent(int number);

    public event ClickEvent onClick;

    public int rayLength;
    public LayerMask mask;
    public string interactableTag; 
    // Start is called before the first frame update
    private void Awake()
    {
        myRend = GetComponent<Renderer>();
        myRend.enabled = true;
        myTP = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

    }
    private void OnButtonInteract()
    {
        RaycastHit button;
        Vector3 buttonpos = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, buttonpos, out button, rayLength, mask))
        {
            if(button.collider.CompareTag(interactableTag))
            {

                if (myLogic.player)
                {
                    ClickedColour();
                    transform.position = new Vector3(myTP.x, myTP.y, -21.25f);
                    //onClick.Invoke(myNumber);
                }
                else
                {
                    UnClickedColour();
                    transform.position = new Vector3(myTP.x, myTP.y, myTP.z);
                }

            }
        }
    }


   /* private void OnMouseDown()
    {
        if (myLogic.player)
        {
            ClickedColour();
            transform.position = new Vector3(myTP.x, myTP.y, -21.25f);
            onClick.Invoke(myNumber);
        }

    }
    private void OnMouseUp()
    {
        UnClickedColour();
        transform.position = new Vector3(myTP.x, myTP.y, myTP.z);
    }*/
    public void ClickedColour()
    {
        myRend.sharedMaterial = nMat;
    }
    public void UnClickedColour()
    {
        myRend.sharedMaterial = lmat;
    }
}
