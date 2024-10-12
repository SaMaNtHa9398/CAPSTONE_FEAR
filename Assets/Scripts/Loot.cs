using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject lootPrefab;
    public string lootName;
    public int dropChance;
    public string description; 

    public Sprite icon;

    //Health items 
    public bool healthconsumable;
    public int nutritionalValue;
    
    // Shield items 
    public bool shieldConsumable;
    public int shieldValue;

    //stamina Jellies; 

    //candles 


    //matches 


    //ammo 

    //smg
    

    //AR 

    //Shotgun 


    public Loot(string lootName, int dropChance, Sprite Icon,  bool HealthConsumable, int NutritionalValue, bool ShieldConsumable, int ShieldValue) 
    {
        // UI
        this.lootName = lootName;
        this.dropChance = dropChance;
        this.icon = Icon; 

        // Health Consumables
        healthconsumable = HealthConsumable;
        nutritionalValue = NutritionalValue;

        //Shield Consumables 
        shieldConsumable = ShieldConsumable;
        shieldValue = ShieldValue; 

    }
}
