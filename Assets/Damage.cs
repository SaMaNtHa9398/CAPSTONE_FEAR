using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int DMG;
    float cooldownTime = 0f;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask Player;
    void Update()
    {
       //ebug.Log(cooldownTime); 
    }
    private void OnCollisionStay(Collision collision)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, Player);
        PlayerHealthScript health = collision.gameObject.GetComponent<PlayerHealthScript>(); 

        if(cooldownTime <= 0)
        {
            if(health != null)
            {
                health.takeDamage(DMG); 
            }
            cooldownTime = 1f; 
        }    
    }
}
