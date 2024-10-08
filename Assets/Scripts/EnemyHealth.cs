using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    [SerializeField] FloatingStats stats; 
    private void Start()
    {
        maxHealth = health; 
    }

    private void Awake()
    {
        stats = GetComponentInChildren<FloatingStats>(); 
    }
    public void TakeDamage(int Damage)
    {
        health -= Damage;
        stats.UpdateHealthBar(health, maxHealth); 
        // hurt animation  


        if (health <= 0)
        {
            health = 0; 
            DestoryEnemy(); 
        } 

            

    }

    public void DestoryEnemy()
    {

        // died animation 

        // loot drop 
        //GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
        Debug.Log("Enemy Element Destroyed");

    }
}
