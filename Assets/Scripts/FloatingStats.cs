using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class FloatingStats : MonoBehaviour
{
    [SerializeField] private Slider slider;
   // [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset; 
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue; 
    }
    
    
    void Update()
    {
       // transform.rotation = camera.transform.rotation;
        target.position = target.position; 
    }
}
