using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : EnemyController
{
    public float _aggroDistance = 0.5f;

    public override void LoseLifeAndHit()
    {
        base.LoseLifeAndHit();
        animator.Play("Hit_Plant");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawSphere(transform.position, _aggroDistance);
    }
}
