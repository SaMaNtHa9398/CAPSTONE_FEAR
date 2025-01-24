using KeySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItemController : MonoBehaviour
{
    [SerializeField] private bool MingDoor = false;
    [SerializeField] private bool EchoDoor = false;
    [SerializeField] private bool BaileyDoor = false;
    [SerializeField] private bool ClaireDoor = false; 
    [SerializeField] private bool Door1Key = false;
    [SerializeField] private bool Door2Key = false;
    [SerializeField] private bool Door3Key = false;
    [SerializeField] private bool Door4Key = false;

    public GameObject Med1, Med2, Med3, Med4;
  
    [SerializeField] public KeyInventory _keyInventory = null;
  
    private KeyDoorController doorObject;


   

    private void Start()
    {
       // door.SetActive(true); 
        if (MingDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
        else if(EchoDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
        else if(BaileyDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
        else if (ClaireDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
    }
    public void objectInteraction()
    {
        if(MingDoor)
        {
            doorObject.PlayAnimation(); 
        }
        else if (Door1Key)
         {
            _keyInventory.hasDoor1Key = true;
            Med1.SetActive(true);
            gameObject.SetActive(false); 
         }
        else if (EchoDoor)
        {
            doorObject.PlayAnimation(); 
        }
       else if (EchoDoor)
        {
            _keyInventory.hasDoor2Key = true;
            Med1.SetActive(true);-
            gameObject.SetActive(false);
        }
        else if (BaileyDoor)
        {
            doorObject.PlayAnimation();
        }
        else if (BaileyDoor)
        {
            _keyInventory.hasDoor3Key = true;
            Med1.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (ClaireDoor)
        {
            doorObject.PlayAnimation();
        }
        else if (ClaireDoor)
        {
            _keyInventory.hasDoor4Key = true;
            Med1.SetActive(true);
            gameObject.SetActive(false);
        }


    }

}

