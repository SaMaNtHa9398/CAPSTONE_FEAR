using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public int ammo;
    public GameObject Mila; 
    private void OnTriggerEnter(Collider other)
    {
       GunSystem gun= other.gameObject.GetComponentInChildren<GunSystem>(); 
        if(gun)
        {
            gun.AddAmmo(ammo);
            Destroy(gameObject); 
        }    
    }
}
