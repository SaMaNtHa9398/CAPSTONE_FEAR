using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<Loot, InventoryItem> itemDictionary = new Dictionary<Loot, InventoryItem>();

    public void Add(Loot loot)
    {
        if (itemDictionary.TryGetValue(loot, out InventoryItem item))
        {
            item.AddToStack(); 
        }
        else
        {
            InventoryItem newItem = new InventoryItem(loot);
            inventory.Add(newItem);
            itemDictionary.Add(loot, newItem);
        }
    }

    public void Remove(Loot loot)
    {

        if (itemDictionary.TryGetValue(loot, out InventoryItem item))
        {
            item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(loot); 
            }
        }

    }
}
