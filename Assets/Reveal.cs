using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Reveal : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light Spotlight; 
    void Update()
    {
        if (Mat && Spotlight)
        {
            Mat.SetVector("MyLightPosition", Spotlight.transform.position);
            Mat.SetVector("MyLightDirection", Spotlight.transform.forward);
            Mat.SetFloat("MyLightAngle", Spotlight.spotAngle); 

        }
    }
}
