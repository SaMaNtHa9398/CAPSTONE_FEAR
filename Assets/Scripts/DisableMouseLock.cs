using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DisableMouseLock : MonoBehaviour
{
    /* // a script that awas created for the sole purpose of getting the mouse back for the inventory right if the tab button will cause the inventory to pop put and enable the mouse 
      public GameObject InventoryUI;
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


      }*/
    public GameObject InventoryUI; // Assign this in the Inspector
    private bool isInventoryOpen = false;

    private void Start()
    {
        if (InventoryUI != null)
        {
            InventoryUI.SetActive(false); // Ensure inventory starts closed
        }
        else
        {
            Debug.LogError("InventoryUI is not assigned in the Inspector!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        if (InventoryUI == null)
        {
            Debug.LogError("InventoryUI is not assigned! Fix this in the Inspector.");
            return;
        }

        isInventoryOpen = !isInventoryOpen; // Toggle state
        InventoryUI.SetActive(isInventoryOpen);

        Cursor.lockState = isInventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isInventoryOpen;

        Debug.Log($"Inventory Open: {isInventoryOpen}, Cursor Visible: {Cursor.visible}, LockState: {Cursor.lockState}");
    }




}
