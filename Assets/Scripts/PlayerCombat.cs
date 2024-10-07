using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint; 
    public float attackRange;
    public LayerMask Enemy;

    public int attackDamageMeleePunch; 


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack(); 
        }
    }

    void Attack()
    {
        // play an attack animation 
        animator.SetTrigger("PunchAttack");
        // detect enemies in range of attack 
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, Enemy);

        // Damage them 
        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamageMeleePunch); 

        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}

