using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTramsform; 
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>(); 
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTramsform = objectGrabPointTransform;
        objectRigidbody.useGravity = false; 
    }
    public void Drop()
    {
        this.objectGrabPointTramsform = null;
        objectRigidbody.useGravity = true;
    }
    private void FixedUpdate()
    {
        if(objectGrabPointTramsform != null)
        {
            float lerpSpeed = 10f; 
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTramsform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition); 
        }
    }
}
