using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMovement : Movement
{
    #region Variables
    protected Animator _animator;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _animator = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _currentSpeed;
        _navMeshAgent.acceleration = _currentSpeed;
        _navMeshAgent.stoppingDistance = _stopRange;
        Vector3 _randomPoint = RandomNavmeshPoint(transform.position, _wanderRange);
        if (_randomPoint != Vector3.zero) _navMeshAgent.SetDestination(_randomPoint);
    }
    #endregion

    #region Public Functions
    public NavMeshAgent GetNavMeshAgent() { return _navMeshAgent; }
    #endregion
}