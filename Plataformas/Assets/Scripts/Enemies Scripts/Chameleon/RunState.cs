using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MonoBehaviour
{
    [SerializeField] Transform[] wayPoint;
    private Animator _anim;
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }
}
