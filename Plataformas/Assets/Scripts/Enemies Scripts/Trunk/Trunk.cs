using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : EnemyController
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;

    [SerializeField] float distance;
    [SerializeField] float waitTimeToAttack = 3;
    [SerializeField] float waitedTime = 3;
    [SerializeField] Animator animator;

    private void Update()
    {
        if(CanIAttack())
            Attack();  
    }

    public override void LoseLifeAndHit()
    {
        base.LoseLifeAndHit();
        animator.Play("Hit_Trunk");
    }

    private bool CanIAttack()
    {
        bool isInRange = Vector2.Distance(transform.position, target.position) < distance;
        bool timeToAttack = waitedTime <= 0;
        if(isInRange)
            waitedTime = timeToAttack ? waitTimeToAttack : waitedTime - Time.deltaTime;

        return isInRange && timeToAttack;

    }
    void Attack()
    {
        animator.Play("Attack_Trunk");
        Invoke("Shoot", 0.5f);
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
