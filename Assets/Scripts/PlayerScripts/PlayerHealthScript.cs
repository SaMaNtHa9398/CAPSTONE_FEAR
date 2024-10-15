using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerHealthScript : MonoBehaviour
{
    public float Health;
    public float maxHealth;
   // public float Shield;
   // public float MaxShield; 
    public Slider HealthSlider;
   // public Slider ShieldSlider;
    public RespawnScript respawning;
    public float respawnTime;
    public GameObject respawnUI;
    public Slider respawnLoading; 
    private void Start()
    {
        respawnUI.SetActive(false);
       // maxHealth = Health;
      //  MaxShield = Shield;
    }
    private void Update()
    {
       HealthSlider.value = Mathf.Clamp(Health / maxHealth, 0, 1);
      //  ShieldSlider.value = Mathf.Clamp(Shield / MaxShield, 0, 1);

    }

    public void TakeMeleeDamage(int MeleeAttackDamage)
    {
       /* if (Shield == MaxShield && Health == maxHealth)
        {
            Shield -= MeleeAttackDamage;
            if(Shield <= 0 && Health == maxHealth)
            {*/
                Health -= MeleeAttackDamage;
                if(Health <= 0)
                {
                    // if the health bar = 0 then the player will died and respawn, they will leave a grave behind as well where all their stuff is 
                    Invoke("Respawn", respawnTime);
                    respawnUI.SetActive(true); 
                    
                }

            //}

        //}
     }
    public void TakeRangeDamage(int RangeAttackDamage)
    {
       /* if (Shield == MaxShield && Health == maxHealth)
        {
            Shield -= RangeAttackDamage;
            if (Shield <= 0 && Health == maxHealth)
            {*/
                Health -= RangeAttackDamage;
                if (Health <= 0)
                {
                    // if the health bar = 0 then the player will died and respawn, they will leave a grave behind as well where all their stuff is 
                    Invoke("Respawn", respawnTime);
                    respawnUI.SetActive(true);

                }

           // }

        //}
    }
    public void Respawn()
    {

    }
}
