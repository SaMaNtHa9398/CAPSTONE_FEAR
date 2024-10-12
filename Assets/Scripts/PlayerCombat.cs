using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //https://www.youtube.com/watch?v=sPiVz1k-fEs&list=WL&index=12&t=923s

    public Animator animator;
    public Transform attackPoint; 
    public float attackRange;
    public LayerMask Enemy;

    public int attackDamageMeleePunch;

    public float attackRate = 3f;
    float nextAttackTime = 0f; 

    private void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate; 
            }
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

