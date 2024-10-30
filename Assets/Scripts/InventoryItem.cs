using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryItem
{
    public Loot lootdata;
    public int stackSize;
    public bool isStackable = false;

 
    public InventoryItem(Loot loot)
    {
        lootdata = loot;
        AddToStack(); 
    }
    public void AddToStack()
    {
        stackSize++; 
    }
    public void RemoveFromStack()
    {
        stackSize--; 
    }
}
