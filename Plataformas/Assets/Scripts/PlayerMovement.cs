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

        if (Input.GetButtonDown("Jump") && GroundCheck.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if(GroundCheck.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);

        }
        if (GroundCheck.isGrounded == true)
        {
            animator.SetBool("Jump", false);

        }

        if (largeJump)
        {
            if(rb.velocity.y < 0)
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
        if(Input.GetKey(KeyCode.A))
        {
            runSpeed = -1;
            sprite.flipX = true;
            animator.SetBool("Run", true);

        }
        else if(Input.GetKey(KeyCode.D)) 
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

