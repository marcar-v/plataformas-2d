using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;

    [Header("Graphics")]
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] GameObject destroyParticle;

    [SerializeField] Collider2D col;

    [Header("Jump Info")]
    [SerializeField] float jumpForce;
    [SerializeField] protected int lives;

    public void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LoseLifeAndHit();
            CheckLife();
        }
    }

    public virtual void LoseLifeAndHit()
    {
        lives--;
    }

    public virtual void CheckLife()
    {
        if (lives == 0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }

    public virtual void EnemyDie()
    {
        Destroy(gameObject);
    }
}
