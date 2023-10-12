using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float runSpeed;
    private Rigidbody2D rb;
    [SerializeField] float speed = 1.5f;

    [Header("Jump")]
    [SerializeField] float jumpForce = 3f;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask groundLayer;

    [Header("Double Jump")]
    [SerializeField] int totalJumps = 1;
    private int remainingJumps;

    [SerializeField] float doubleJumpForce = 2.5f;
    private bool canDoubleJump;

    [Header("Large Jump")]
    [SerializeField] bool largeJump = false;
    [SerializeField] float fallMultiplier = 0.5f;
    [SerializeField] float lowJumpMultiplier = 1f;

    [Header("Animations & Sounds")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource jumpSound;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        remainingJumps = totalJumps;
    }

    void Update()
    {
        Movement();
        Jump();
    }

    bool isGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, groundLayer);
        return rayCastHit.collider != null;
    }

    void Jump()
    {
        //Controlador salto y doble salto
        if(isGrounded())
        {
            remainingJumps = totalJumps;
        }
        if(Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0)
        {

            animator.SetBool("DoubleJump", true);
            remainingJumps--;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpSound.Play();
        }


        //Condicionales para controlar las animaciones
        if (isGrounded() == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);

        }
        if (isGrounded())
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }

        //Animación y controlador de caída
        if (rb.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }

        //Salto mejorado. Cuanto más se pulse la tecla "Espacio" más alto hace el salto
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

