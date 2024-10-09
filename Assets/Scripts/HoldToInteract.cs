using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HoldToInteract : MonoBehaviour
{
    [SerializeField]
    private Camera cameraInteract;
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
    private Chest itemBeingOpened;
    private float currentPickupTimeElapsed;

    private Animator animator; 
    private void Update()
    {
        SelectItemBeingPickedUpFromRay();

        if (HasItemTargetted())
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
        return itemBeingOpened != null;
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
            OpenChest();

    }

    private void SelectItemBeingPickedUpFromRay()
    {
        Ray ray = cameraInteract.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red);
        RaycastHit hitInfo;
        
        if (Physics.Raycast(ray, out hitInfo, 1f, layerMask))
        {
            var hitChest = hitInfo.collider.GetComponent<ChestInteract>();
            if (hitChest == null)
            {
                itemBeingOpened = null;
            }
            else if (hitChest != null && hitChest != itemBeingOpened)
            {
               // itemBeingOpened = hitChest;
                itemNameText.text = "Opening " + itemBeingOpened.gameObject.name;

            }
        }
        else
        {
            itemBeingOpened = null;
        }

    }

    private void OpenChest()
    {
        // play animation 

        // expel loot 
        GetComponent<LootBag>().InstantiateLoot(transform.position);
    }
}
