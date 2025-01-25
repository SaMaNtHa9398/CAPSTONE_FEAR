using KeySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItemController : MonoBehaviour
{
    [Header("Door Flags")]
    [SerializeField] private bool Door1 = false;
    [SerializeField] private bool Door2 = false;
    [SerializeField] private bool Door3 = false;
    [SerializeField] private bool Door4 = false;

    [Header("Key Flags")]
    [SerializeField] private bool Door1Key = false;
    [SerializeField] private bool Door2Key = false;
    [SerializeField] private bool Door3Key = false;
    [SerializeField] private bool Door4Key = false;

    [Header("Med Displays")]
    public GameObject Med; 

    [Header("Inventory")]
    [SerializeField] public KeyInventory _keyInventory = null;
  
    private KeyDoorController doorObject;


   

    private void Start()
    {
        // door.SetActive(true); 
         if (Door1 || Door2 || Door3 || Door4)
         {
             doorObject = GetComponent<KeyDoorController>();
         }
       
    }
    public void objectInteraction()
    {

        //Doors 
        if(Door1)
        {
            _keyInventory.Door1 = true;
            // doorObject.PlayAnimation();
            return;
        }
        if (Door2)
        {
            _keyInventory.Door2 = true;
            // doorObject.PlayAnimation();
            return;
        }
        if (Door3)
        {
            _keyInventory.Door3 = true;
            // doorObject.PlayAnimation();
            return;
        }
        if (Door4)
        {
            _keyInventory.Door4 = true;
            // doorObject.PlayAnimation();
            return;
        }

        //Key PickUps
        if (Door1Key)
        {
            _keyInventory.hasDoor1Key = true;
            ActivateMedDisplay(Med);
            return;
        }
        if (Door2Key)
        {
            _keyInventory.hasDoor2Key = true;
            ActivateMedDisplay(Med);
            return;
        }
        if (Door3Key)
        {
            _keyInventory.hasDoor3Key = true;
            ActivateMedDisplay(Med);
            return;
        }
        if (Door4Key)
        {
            _keyInventory.hasDoor4Key = true;
            ActivateMedDisplay(Med);
            return;
        }

    }
     private void ActivateMedDisplay(GameObject medDisplay)
        {
            if (medDisplay != null)
            {
                medDisplay.SetActive(true);
            }
            gameObject.SetActive(false); // Deactivate the key object
        }

}

