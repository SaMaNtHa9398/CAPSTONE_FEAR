using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class EnemyHealth : MonoBehaviour
{
    public Animator animator; 
    public float health;
    public float maxHealth;
    public GameObject enemygameObject;
    public GameObject Door; 
    public TextMeshProUGUI healthText; 
    [SerializeField] FloatingStats stats;
    public WaveSpawner waveSpawner; 
    private void Start()
    {
        Door.SetActive(true); 
        maxHealth = health;
        healthText.text = health.ToString(); 
    }

    private void Awake()
    {
        stats = GetComponentInChildren<FloatingStats>(); 
    }
    public void TakeDamage(float EnemyDamage)
    {
        health -= EnemyDamage;
        stats.UpdateHealthBar(health, maxHealth);
        healthText.text = health.ToString();
        // hurt animation  


        if (health <= 0)
        {
            health = 0; 
            LootDrop();
            OpenDoor(); 
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
    private void OpenDoor()
    {
        if(waveSpawner)
        {
            Door.SetActive(false); 
        }

    }
}

