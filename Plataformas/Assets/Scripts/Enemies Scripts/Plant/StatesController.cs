using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates
{
    Idle,
    Aggro
}

public class StatesController : MonoBehaviour
{
        #region CurrentState Property
        private EnemyStates _currentState;

        public EnemyStates currentStates { set { _currentState = value; } get { return _currentState; } }

        #endregion

    public float _aggroDistance = 1;
    public Transform target;

    AggroState _aggroState;
    IdleState _idleState;

        void Awake()
        {
            _currentState = EnemyStates.Idle;
            target = GameObject.FindGameObjectWithTag("Player").transform;
            _aggroState = GetComponent<AggroState>();
            _idleState = GetComponent<IdleState>();

        }

        void Update()
        {
            switch (_currentState)
            {
                case EnemyStates.Idle:

                    _idleState.enabled = true;
                    _aggroState.enabled = false;
                    break;

                case EnemyStates.Aggro:

                    _aggroState.enabled = true;
                    _idleState.enabled = false;
                    break;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0, 0.25f);
            Gizmos.DrawSphere(transform.position, _aggroDistance);
        }
    }
