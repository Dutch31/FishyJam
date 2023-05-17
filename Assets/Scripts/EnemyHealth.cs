using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage");        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && !isDead && gameObject.CompareTag("Enemy"))
        {
            isDead = true;
            Destroy(GameObject.FindWithTag("Enemy"));

            Debug.Log("Enemy Killed");
        }
    }
}
