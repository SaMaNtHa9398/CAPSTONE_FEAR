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

    private bool isClicked = false;

    // Start is called before the first frame update
    private void Awake()
    {
        myRend = GetComponent<Renderer>();
        myRend.enabled = true;
        myTP = transform.position;
    }

    public void OnMouseDown()
    {
        if (myLogic.player)
        {
            ClickedColour();
            transform.position = new Vector3 (myTP.x, myTP.y, -21.25f);
            onClick.Invoke(myNumber);
            isClicked = true; 
        }

    }
    public void OnMouseUp()
    {
        UnClickedColour();
        //transform.position = new Vector3 (myTP.x, myTP.y, myTP.z);
        transform.position = myTP;
        isClicked = false; 
    }
    public void ClickedColour()
    {
        myRend.sharedMaterial = nMat;
    }
    public void UnClickedColour()
    {
        myRend.sharedMaterial = lmat;
    }
}
