using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithLife : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject brokenParts;
    [SerializeField] float jumpForce = 4f;
    [SerializeField] int boxLifes = 1;
    [SerializeField] GameObject boxCollider;
    [SerializeField] Collider2D col2D;

    [SerializeField] GameObject heart;

    [SerializeField] AudioSource boxBreaksSound;


    private void Start()
    {
        heart.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            LoseLifeAndHit();
        }
    }


    public void LoseLifeAndHit()
    {
        boxLifes--;
        //animator.Play("Hit");
        CheckBoxLife();
    }

    public void CheckBoxLife()
    {
        if (boxLifes <= 0)
        {
            heart.SetActive(true);
            boxBreaksSound.Play();
            boxCollider.SetActive(false);
            col2D.enabled = false;
            brokenParts.SetActive(true);
            spriteRenderer.enabled = false;
            animator.Play("Hit");
            Invoke("DestroyBox", 0.5f);
        }
    }

    public void DestroyBox()
    {
        Destroy(/*transform.parent.*/this.gameObject);
    }

}
