using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    //code from user1production

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
    }
}
