using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableMouse : MonoBehaviour
{

    private void Awake()
    {
        UnlockCursor(); 
    }
    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Frees the cursor
        Cursor.visible = true; // Shows the cursor
    }
}
