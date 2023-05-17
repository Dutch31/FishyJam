using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode Punch;       

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public bool isAttacking;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(Punch))
        {
            animator.SetBool("isAttacking", true);
            punchAttack();
        }       
        
    }

    void punchAttack()
    {
        // attack animation
        //animator.SetTrigger("Attack");

        // attack enemy in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // damage them
        /*foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerHealth>().TakeDamage(15);            
        }*/

        animator.SetBool("isAttacking", false);

    }    

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            Debug.Log("Hit");
            return;            
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
