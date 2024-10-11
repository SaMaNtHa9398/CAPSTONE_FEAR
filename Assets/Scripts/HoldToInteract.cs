using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HoldToInteract : MonoBehaviour
{
    [SerializeField]
    GameObject token;
    [SerializeField]
    public HoldToInteract hold;  
   
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

    private bool isChestOpened = false;
    private void Update()
    {
        SelectItemBeingPickedUpFromRay();
        token.SetActive(false);
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
        isChestOpened = false;
    }

    private void IncrementPickUpProgressandTryComplete()
    {
        currentPickupTimeElapsed += Time.deltaTime;
        isChestOpened = false; 
        if (currentPickupTimeElapsed >= pickupTime && !isChestOpened)
        {
           
            isChestOpened = true;
            currentPickupTimeElapsed = 0f; 
            IntermediateStep(); 
        }    

    }

    private void IntermediateStep()
    {
        if (isChestOpened)
        {
            OpenChest();
        }
    }
    private void SelectItemBeingPickedUpFromRay()
    {
        Ray ray = cameraInteract.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red);
        RaycastHit hitInfo;
        
        if (Physics.Raycast(ray, out hitInfo, 1f, layerMask))
        {
            var hitChest = hitInfo.collider.GetComponent<Chest>();
            if (hitChest == null)
            {
                itemBeingOpened = null;
                isChestOpened = false;
            }
            else if (hitChest != null && hitChest != itemBeingOpened)
            {
                itemBeingOpened = hitChest;
                itemNameText.text = "Opening " + itemBeingOpened.gameObject.name;
                isChestOpened = false;
            }
        }
        else
        {
            isChestOpened = false;
            itemBeingOpened = null;
        }

    }

    private void OpenChest()
    {
        // play animation 

       
        // expel loot 
        GetComponentInChildren<LootBag>().InstantiateLoot(transform.position);
        token.SetActive(true);
        hold.enabled = !hold.enabled;
        pickupImageRoot.gameObject.SetActive(false);
    }
}
