using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public void TakeDamage(int Damage)
    {
        health -= Damage;

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
