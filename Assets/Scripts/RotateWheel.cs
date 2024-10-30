using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateWheel : MonoBehaviour
{
    public static event Action <string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    public int numbershown;

    private void Start()
    {
        coroutineAllowed = true;
        numbershown = 1;

    }

    private void OnMouseDown()
    {
        if(coroutineAllowed)
        {
            StartCoroutine("RotateTheWheel");
        }
    }
    private IEnumerator RotateTheWheel()
    {
        coroutineAllowed = false;
        for (int i = 0; i<=11; i++)
        {
            transform.Rotate(0f, 0f, 3f);
            yield return new WaitForSeconds(0.01f);
        }
        coroutineAllowed = true;
        numbershown += 1;
        //if (numbershown > 9)
        {
            //numbershown = 0;

        }
        Rotated(name, numbershown);
    }
}
