using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatesController;

public class IdleState : MonoBehaviour
{
    StatesController _stateController;

    void Awake()
    {
        _stateController = GetComponent<StatesController>();
    }

    void Update()
    {
        float _distanceToPlayer = Vector2.Distance(transform.position, _stateController.target.position);

        if (_distanceToPlayer <= _stateController._aggroDistance)
        {
            _stateController.currentStates = EnemyStates.Aggro;
        }
    }
}
