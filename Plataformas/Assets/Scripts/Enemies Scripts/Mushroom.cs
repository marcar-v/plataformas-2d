using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : EnemyController
{
    public override void LoseLifeAndHit()
    {
        base.LoseLifeAndHit();
        animator.Play("Hit_Mushroom");
    }

}
