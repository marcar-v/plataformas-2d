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
    [SerializeField] protected Animator animator;

    [Header("Movement")]
    [SerializeField] protected float speed = 0.5f;
    [SerializeField] protected Transform[] wayPoints;
    [SerializeField] float startWaitTime = 2f;
    private float _waitTime;
    private int _i = 0;
    private Vector2 _actualPosition;

    [SerializeField] Collider2D col;

    [Header("Jump Info")]
    [SerializeField] float jumpForce;
    [SerializeField] protected int lives;

    public void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void FixedUpdate()
    {
        EnemyMovement();
    }
    public virtual void EnemyMovement()
    {
        StartCoroutine(CheckEnemyMovement());

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[_i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoints[_i].transform.position) < 0.1f)
        {
            if (_waitTime <= 0)
            {
                if (wayPoints[_i] != wayPoints[wayPoints.Length - 1])
                {
                    _i++;
                }
                else
                {
                    _i = 0;
                }
                _waitTime = startWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }

    public virtual IEnumerator CheckEnemyMovement()
    {
        _actualPosition = transform.position;
        yield return new WaitForSeconds(0.5f);


        if (transform.position.x > _actualPosition.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x < _actualPosition.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x == _actualPosition.x)
        {
            animator.SetBool("Idle", true);
        }

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
