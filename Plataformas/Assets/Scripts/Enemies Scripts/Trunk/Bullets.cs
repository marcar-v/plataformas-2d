using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class Bullets : MonoBehaviour
{
    private bool stopBullet;
    [SerializeField] float speed = 2f;
    [SerializeField] float lifeTime;
    [SerializeField] GameObject brokenBullets;
    [SerializeField] Collider2D bulletCollider;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if(!stopBullet)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void Shooted()
    {
        stopBullet = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
        brokenBullets.SetActive(true);
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Color color = renderer.material.color;
            color.a = 0;
            renderer.material.color = color;
        }

        Destroy(gameObject, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Shooted();
            GameController.instance.PlayerDamaged();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            Shooted();
    }
}
