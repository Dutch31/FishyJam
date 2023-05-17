using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode attack;

    public Animator animator;
    

    public float movespeed = 4;
    public float jumpForce = 8;
    private bool isJumping;
    public bool facingRight;

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
            flip();
        }
        else if (Input.GetKey(right))
        {
            rb2D.velocity = new Vector2(movespeed, rb2D.velocity.y);
            animator.SetBool("IsWalking", true);
            flip2();
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("IsWalking", false);
            
        }

        // Jump
        if (Input.GetKeyDown(jump) && !isJumping)
        {         
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            isJumping= true;

            animator.SetBool("IsWalking", false);
            animator.SetTrigger("Jump");
        }
        
        //Attack
        if (Input.GetKeyDown(attack))
        {
            animator.SetTrigger("Attack1");
            animator.SetTrigger("Attack2");
        }
       

    }

    //Single Jump & Character Reset
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isJumping = false;
        }

        /*if (other.gameObject.CompareTag("bottomBorder"))
        {
            if (gameObject.CompareTag("Player1"))
            {
                GetComponent<PlayerHealth>().TakeDamage(100);
            }
            else if (gameObject.CompareTag("Player2"))
            {
                GetComponent<PlayerHealth>().TakeDamage(100);
            }

        }*/
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
    
}
