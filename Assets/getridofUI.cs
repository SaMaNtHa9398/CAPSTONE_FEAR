using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getridofUI : MonoBehaviour
{
    public GameObject UItoggleon;
    public GameObject model;
    public GameObject UIpickup;
    private bool isUIActive = false;

    void Start()
    {
     
    }

    void Update()
    {
        model.SetActive(false);
        UIpickup.SetActive(false);
        if (Input.GetKeyDown(KeyCode.R))
        {
            UItoggleon.SetActive(false);
            Destroy(gameObject); 

        }
    }
}
