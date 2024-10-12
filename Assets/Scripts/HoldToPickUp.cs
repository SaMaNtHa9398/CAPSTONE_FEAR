using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class HoldToPickUp : MonoBehaviour
{
    [SerializeField]
    private Camera PickUpcamera;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float pickupTime = 2;
    [SerializeField]
    private RectTransform pickupImageRoot;
    [SerializeField]
    private TextMeshProUGUI itemNameText;
    [SerializeField]
    private Image pickupProgressImage;
    private Item itemBeingPickedUp;
    private float currentPickupTimeElapsed;

    public ToolTipManager ToolTipManager; 
    private void Update()
    {
        SelectItemBeingPickedUpFromRay(); 

        if(HasItemTargetted())
        {
            pickupImageRoot.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.E)) IncrementPickUpProgressandTryComplete();
            else currentPickupTimeElapsed = 0f;

            UpdatePickupProgessImage(); 
        }
        else
        {
            pickupImageRoot.gameObject.SetActive(false);
            currentPickupTimeElapsed = 0f; 
        }
    }

    private bool HasItemTargetted()
    {
        return itemBeingPickedUp != null;
    }
    private void UpdatePickupProgessImage()
    {
        float pct = currentPickupTimeElapsed / pickupTime;
        pickupProgressImage.fillAmount = pct; 
    }

    private void IncrementPickUpProgressandTryComplete()
    {
        currentPickupTimeElapsed += Time.deltaTime;
        if (currentPickupTimeElapsed >= pickupTime)
        {
            ToolTipManager._instance.HidToolTip(); 
            MoveItemIntoInventory(); 
        }
    

    }    

    private void SelectItemBeingPickedUpFromRay()
    {
        Ray ray = PickUpcamera.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);
        RaycastHit hitInfo; 
        if(Physics.Raycast(ray, out hitInfo, 2f, layerMask))
        {
            var hitItem = hitInfo.collider.GetComponent<Item>(); 
            if(hitItem == null)
            {
                itemBeingPickedUp = null;
            }
            else if (hitItem != null && hitItem != itemBeingPickedUp)
            {
                itemBeingPickedUp = hitItem;
                itemNameText.text = "Pickup " + itemBeingPickedUp.gameObject.name; 

            }
        }
        else
        {
            itemBeingPickedUp = null; 
        } 
            
    }
    private void MoveItemIntoInventory()
    {
        Destroy(itemBeingPickedUp.gameObject);
        itemBeingPickedUp = null; 
    }

}
