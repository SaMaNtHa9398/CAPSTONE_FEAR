using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootlist = new List<Loot>();
     
    Loot GetDroppedItems()
 
    {
        int randomNumber = Random.Range(1, 101); //1-100
        List<Loot> PossibleItems = new List<Loot>();
        foreach(Loot item in lootlist)
        {
            if(randomNumber <= item.dropChance)
            {
                PossibleItems.Add(item);
                //return PossibleItems; 
            }
        }

        if (PossibleItems.Count > 0)
        {
            Loot droppedItem = PossibleItems[Random.Range(0, PossibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No loot dropped");
        return null;
    }

   public void InstantiateLoot(Vector3 spawnposition)
   {
        Loot droppedItem = GetDroppedItems();
 
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnposition, Quaternion.identity);

            lootGameObject.GetComponent<MeshFilter>().mesh = droppedItem.lootPrefab.GetComponent<MeshFilter>().mesh;

            float dropForce = 300f;

            Vector3 dropDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

            lootGameObject.GetComponent<Rigidbody>().AddForce(dropDirection * dropForce, ForceMode.Impulse);
        }
   }

}

