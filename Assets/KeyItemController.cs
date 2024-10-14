using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    [SerializeField] private bool Door1 = false;
    [SerializeField] private bool Door1key = false;
    [SerializeField] private keyInventory _keyInventory = null;
    private KeyDoorController doorObject;
    public GameObject door; 
    private void Start()
    {
        door.SetActive(true); 
        if (Door1)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
    }
    public void objectInteraction()
    {
        if (Door1)
        {
            door.SetActive(false); 
        }

        else if (Door1key)
        {
            _keyInventory.hasDoor1Key = true;
            gameObject.SetActive(false);
        }
    }
}
}
