using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;    
    
    private bool isDead;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        
        if (currentHealth > 25 && !isDead)
        {
            animator.SetTrigger("Hit");
            currentHealth -= damage;
            Debug.Log("Damage");
        }
        if (currentHealth <= 25) 
        {
            currentHealth -= damage;
            Debug.Log("Fatal Damage");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && !isDead && gameObject.CompareTag("Enemy"))
        {            
            animator.SetBool("IsDead", true);
            isDead = true;
            Destroy(GameObject.FindWithTag("Enemy"), 2);

            Debug.Log("Enemy Killed");
        }
    }
}
