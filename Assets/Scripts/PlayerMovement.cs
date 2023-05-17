using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode attack;

    public Animator animator;

    private bool IsJumping;
    public float movespeed = 4;
    public float jumpForce = 8;    
    private bool Walking;
    public bool facingRight;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private Rigidbody2D rb2D;
    

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
       //Movement player
        if (Input.GetKey(left))
        {
            rb2D.velocity = new Vector2(-movespeed, rb2D.velocity.y);
            animator.SetBool("IsWalking", true);
            Walking = true;
            flip();
        }
        else if (Input.GetKey(right))
        {
            rb2D.velocity = new Vector2(movespeed, rb2D.velocity.y);
            animator.SetBool("IsWalking", true);
            Walking = true;
            flip2();
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("IsWalking", false);
            Walking = false;            
        }

        // Jump
        if (Input.GetKeyDown(jump) && !IsJumping)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);            
            IsJumping = true;

            animator.SetBool("IsWalking", false);
            animator.SetTrigger("Jump");
        }
        
        //Attack
        if (Input.GetKeyDown(attack) && !Walking)
        {
            animator.SetTrigger("Attack1");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            // damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("hit");
                enemy.GetComponent<EnemyHealth>().TakeDamage(25);
            }
        }
        else if (Input.GetKeyDown(attack) && Walking)
        {
            animator.SetTrigger("Attack2");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            // damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("hit 2");
                enemy.GetComponent<EnemyHealth>().TakeDamage(24);
            }
        }

        

    }

    //Single Jump & Character Reset
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            IsJumping = false;
        }

        if (other.gameObject.CompareTag("bottomBorder"))
        {
            if (gameObject.CompareTag("Player"))
            {
                Destroy(GameObject.FindWithTag("Player"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }          

        }
    }
    
    //Character flip
    void flip()
    {   
        
        if (facingRight == true)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = false;
        }        
        
    }

    void flip2()
    {
        
        if (facingRight == false)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = true;
        }
        
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
