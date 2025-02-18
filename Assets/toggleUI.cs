using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleUI : MonoBehaviour
{
    public GameObject UItoggleon;
    private bool isUIActive = false;

    void Start()
    {
        UItoggleon.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isUIActive = !isUIActive; // Toggle UI state

            UItoggleon.SetActive(isUIActive);
            Cursor.lockState = isUIActive ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isUIActive;
        }
    }
}
