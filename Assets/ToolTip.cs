using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ToolTip : MonoBehaviour
{
    //https://www.youtube.com/watch?v=y2N_J391ptg 
    public string message, itemtitle,itemtip;
     
    public Image titleBoarderColor;
    public Image descriptionBoarderColor;
    public Image itemIcon; 

    private void OnMouseEnter()
    {
        ToolTipManager._instance.SetAndShowToolTip(message, itemtitle, itemtip,titleBoarderColor.color, descriptionBoarderColor.color,  itemIcon.sprite      ); 
    }
    private void OnMouseExit()
    {
        ToolTipManager._instance.HidToolTip(); 
    }
}
