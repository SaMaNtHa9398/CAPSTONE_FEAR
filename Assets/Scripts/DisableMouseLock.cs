using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DisableMouseLock : MonoBehaviour
{
    // a script that awas created for the sole purpose of getting the mouse back for the inventory right if the tab button will cause the inventory to pop put and enable the mouse 
    public RectTransform InventoryUI;
    public bool IsMouseEnabled = false; 
    private void Start()
    {
        InventoryUI.gameObject.SetActive(false);
    }
    private void Update()
    {
         
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            IsMouseEnabled = true; 
            InventoryUI.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            IsMouseEnabled = false;
            InventoryUI.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        
    }
}
