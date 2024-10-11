using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootlist = new List<Loot>();
    public float SpawnRadius, SpawnMax;
    public int NumberOfItem;
    public int spawnMaxNumb, spawnMinNumb; 
     
    List<Loot> GetDroppedItems()
    {
        int randomNumber = Random.Range(spawnMinNumb, spawnMaxNumb); //1-100
        Debug.Log(randomNumber);
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
            //Loot droppedItem = PossibleItems[Random.Range(0, PossibleItems.Count)];
            //return droppedItem;
            return PossibleItems; 
        }
        Debug.Log("No loot dropped");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnposition)
    {
        List<Loot> droppedItems = GetDroppedItems();


       
            if (droppedItems != null && droppedItems.Count > 0)
            {
                for (int i = 0; i < Mathf.Min(NumberOfItem, droppedItems.Count); i++) 
                {

                    Loot selectLoot = droppedItems[Random.Range(0, droppedItems.Count)];
                    droppedItemPrefab = selectLoot.lootPrefab;

                    GameObject lootgameObject = Instantiate(droppedItemPrefab, spawnposition, Quaternion.identity);

                    float dropForce = 0f;

                    Vector3 dropDirection = new Vector3(Random.Range(SpawnRadius, SpawnMax), 0, Random.Range(SpawnRadius, SpawnMax));

                    lootgameObject.GetComponent<Rigidbody>().AddForce(dropDirection * dropForce, ForceMode.Impulse);

                }
            }
         
    }
}

