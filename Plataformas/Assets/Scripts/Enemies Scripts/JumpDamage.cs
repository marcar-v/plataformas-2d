using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject destroyParticle;

    [SerializeField] Collider2D collider2D;

    [Header("Jump Info")]
    [SerializeField] float jumpForce;
    [SerializeField] int lifes;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LoseLifeAndHit();
            CheckLife();
        }
    }
    public void LoseLifeAndHit()
    {
        lifes--;
        animator.Play("Hit_Mushroom");
    }
    
    public void CheckLife()
    {
        if(lifes == 0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
