using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKeys : MonoBehaviour
{
    public string key;

    public void SendKey()
    {
        this.transform.GetComponentInParent<Keypad>().PasscodeEntry(key);
    }
}
