using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMovement : Movement
{
    #region Variables
    [Header("Enemy Movement Stats")]
    [SerializeField] protected float _wanderRange = 15.0f;
    [SerializeField] protected float _wanderCooldown = 15.0f;
    protected float _currentWanderCooldown;
    protected Animator _animator;
    protected NavMeshAgent _navMeshAgent;
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