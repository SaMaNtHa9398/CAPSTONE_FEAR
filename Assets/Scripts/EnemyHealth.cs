using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator; 
    public float health;
    public float maxHealth;
    public GameObject enemygameObject; 

    [SerializeField] FloatingStats stats; 
    private void Start()
    {
        maxHealth = health; 
    }

    private void Awake()
    {
        stats = GetComponentInChildren<FloatingStats>(); 
    }
    public void TakeDamage(float EnemyDamage)
    {
        health -= EnemyDamage;
        stats.UpdateHealthBar(health, maxHealth);
        // hurt animation  
       

        if (health <= 0)
        {
            health = 0; 
            LootDrop(); 
            DestoryEnemy(); 
        } 
        else
        {
            animator.SetTrigger("Hurt");
        }

            

    }

    public void DestoryEnemy()
    {

        // died animation 
        animator.SetBool("IsDeath",true);
        // loot drop 
        
        
        Destroy(enemygameObject);
        Debug.Log("Enemy Element Destroyed");
    }

    private void LootDrop()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
    }
}
