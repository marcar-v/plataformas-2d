using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float jumpSpeed = 3f;
    private Rigidbody2D rb;
    [SerializeField] float speed = 1.5f;

    [SerializeField] bool largeJump = false;
    [SerializeField] float fallMultiplier = 0.5f;
    [SerializeField] float lowJumpMultiplier = 1f;

    [SerializeField] float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Jump();

    }

    void Jump()
    {
        if (Input.GetKey("space"))
        {
            if (GroundCheck.isGrounded)
            {
                canDoubleJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb.velocity = new Vector2(rb.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }

            }
        }

        if (GroundCheck.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);

        }
        if (GroundCheck.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }


        if (largeJump)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            runSpeed = -1;
            sprite.flipX = true;
            animator.SetBool("Run", true);

        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        { 
            runSpeed = 1;
            sprite.flipX = false;
            animator.SetBool("Run", true);
        }
        else
        {
            runSpeed = 0;
            animator.SetBool("Run", false);
        }

        transform.position = new Vector2(transform.position.x + runSpeed * speed * Time.deltaTime, transform.position.y);
    }
}

