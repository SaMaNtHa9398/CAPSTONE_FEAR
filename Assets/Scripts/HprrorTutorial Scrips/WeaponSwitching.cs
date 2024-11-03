using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    /* //code from user1production

     public GameObject obj1;
     public GameObject obj2;
     public GameObject obj3;


     private void Start()
     {
         obj1.SetActive(false);
         obj2.SetActive(false);
         obj3.SetActive(false); 

     }

     private void Update()
     {
         if(Input.GetKeyDown(KeyCode.Alpha1))
         {
             obj1.SetActive(false);
             obj2.SetActive(false);
             obj3.SetActive(false);
         }
         if (Input.GetKeyDown(KeyCode.Alpha2))
         {
             obj1.SetActive(true);
             obj2.SetActive(false);
             obj3.SetActive(false);
         }
         if (Input.GetKeyDown(KeyCode.Alpha2))
         {
             obj1.SetActive(false);
             obj2.SetActive(true);
             obj3.SetActive(false);
         }
         if (Input.GetKeyDown(KeyCode.Alpha3))
         {
             obj1.SetActive(false);
             obj2.SetActive(false);
             obj3.SetActive(true);
         }
     }*/
    public int selectedWeapon = 0;
    private void Start()
    {
        SelectWeapon(); 

    }

    private void Update()
    {
            int previousSelectedWeapon = selectedWeapon; 
        if(Input.GetAxis("Mouse ScrollWheel")> 0f)
        {


            if(selectedWeapon >= transform.childCount -1 )
            {
                selectedWeapon = 0; 
            }
            else
            {
                selectedWeapon++; 
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon >= 0)
            {
                selectedWeapon = transform.childCount -1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0; 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }


        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon(); 
        }    


    }
    void SelectWeapon()
    {
        int i = 0; 
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
         
            i++; 
        }

    }
}
