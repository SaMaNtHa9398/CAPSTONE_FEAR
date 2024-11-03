using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;

    private ObjectGrabable objectGrabable; 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(objectGrabable == null)
            {
                float pickUpDistance =10f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    //Debug.Log(raycastHit.transform);
                    if(raycastHit.transform.TryGetComponent(out  objectGrabable))
                    {
                        objectGrabable.Grab(objectGrabPointTransform); 
                       // Debug.Log(objectGrabable); 
                    }
                }
            }
            else
            {
                objectGrabable.Drop();
                objectGrabable = null; 
            }
        }
    }
}
