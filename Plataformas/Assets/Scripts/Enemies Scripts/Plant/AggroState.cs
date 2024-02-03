using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static StatesController;

public class AggroState : MonoBehaviour
{
    StatesController _stateController;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;

    [SerializeField] Animator anim;

    [SerializeField] float waitTimeToAttack = 1.5f;
    [SerializeField] float waitedTime = 1.5f;



    void Awake()
    {
        _stateController = GetComponent<StatesController>();
    }

    private bool CanIAttack()
    {
        bool isInRange = Vector2.Distance(transform.position, _stateController.target.position) < _stateController._aggroDistance;
        bool timeToAttack = waitedTime <= 0;
        if (isInRange)
        {
            waitedTime = timeToAttack ? waitTimeToAttack : waitedTime - Time.deltaTime;
        }

        return isInRange && timeToAttack;

    }

    void Attack()
    {
        anim.Play("Attack_Plant");
        Invoke("Shoot", 0.5f);
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void Update()
    {
        if (CanIAttack())
        {
            Attack();
        }

        float _distanceToPlayer = Vector2.Distance(transform.position, _stateController.target.position);

        if (_distanceToPlayer > _stateController._aggroDistance)
        {
            _stateController.currentStates = EnemyStates.Idle;
        }
    }
}
