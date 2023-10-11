using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce = 3f;
    private Rigidbody2D rb;
    [SerializeField] float speed = 1.5f;

    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;

    [SerializeField] bool largeJump = false;
    [SerializeField] float fallMultiplier = 0.5f;
    [SerializeField] float lowJumpMultiplier = 1f;

    [SerializeField] float doubleJumpForce = 2.5f;
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
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.1f, 0.006f), 0, groundLayer);
    }


    bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, groundLayer);
        return raycastHit.collider != null;
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (isGrounded() == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);

        }
        if (isGrounded())
        {
            animator.SetBool("Jump", false);
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
            if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
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

