using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class InventorySlot: MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI labelText;
    public TextMeshProUGUI stackSizeText;

    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
        stackSizeText.enabled = false;
    }

    public void DrawSlot(InventoryItem loot)
    {
        if(loot == null)
        {
            ClearSlot();
            return; 
        }
        icon.enabled = true;
        labelText.enabled = true;
        stackSizeText.enabled = true;

        icon.sprite = loot.lootdata.icon;
        labelText.text = loot.lootdata.lootName;
        stackSizeText.text = loot.stackSize.ToString(); 
    }
    
}
