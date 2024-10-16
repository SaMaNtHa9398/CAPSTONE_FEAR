using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerHealthScript : MonoBehaviour
{
    public float Health;
    public float maxHealth;
   
    public Slider HealthSlider;
   
    public float respawnTime;
    public GameObject respawnUI, respawnPoint, player;
    public Slider respawnLoading;

    private bool isDead = false;
    private void Start()
    {
       // respawnUI.SetActive(false);
        maxHealth = Health;
     
    }
    private void Update()
    {
       HealthSlider.value = Mathf.Clamp(Health / maxHealth, 0, 1);
      

    }

    public void takeDamage (int DMG )
    {
        Debug.Log("Damage Taken: " + DMG);
        if (isDead) return;
        Health -= DMG;

        if(Health <= 0)
        {
            Health = 0;
            Invoke("Respawn", respawnTime);
            respawnUI.SetActive(true);
            isDead = true; 
        }
    }

    public void Respawn()
    {
        player.transform.position = respawnPoint.transform.position;
        isDead = false;
        Health = maxHealth; 
    }
}
