using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
    public GameObject FlashLightonPlayer;
    public bool FlashlightEnabled = false; 
    private void Start()
    {
        FlashLightonPlayer.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        FlashlightEnabled = true; 
        if(other.gameObject.tag =="Player")
        {

            this.gameObject.SetActive(false);
            FlashLightonPlayer.SetActive(true); 
     
        }
    }
}
