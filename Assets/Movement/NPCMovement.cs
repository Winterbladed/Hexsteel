using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class NPCMovement : Movement
{
    #region Variables
    [Header("Npc Movement Stats")]
    protected Animator _animator;
    protected NavMeshAgent _navMeshAgent;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _animator = GetComponentInChildren<Animator>();
        _navMeshAgent.GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _currentSpeed;
        _navMeshAgent.acceleration = _currentSpeed;
        Vector3 _randomPoint = RandomNavmeshPoint(transform.position, _wanderRange);
        if (_randomPoint != Vector3.zero) _navMeshAgent.SetDestination(_randomPoint);
    }

    private void Update()
    {
        Animatorr();
        Wander();
    }

    protected void Animatorr()
    {
        _navMeshAgent.speed = _currentSpeed;
        _navMeshAgent.acceleration = _currentSpeed;
        if (_navMeshAgent.velocity.magnitude > 0.0f) _animator.SetBool("_isWalking", true);
        else if (_navMeshAgent.velocity.magnitude <= 0.0f) _animator.SetBool("_isWalking", false);
    }

    protected void Wander()
    {
        if (_currentWanderCooldown < _wanderCooldown) _currentWanderCooldown += Time.deltaTime;
        if (_currentWanderCooldown > _wanderCooldown) _currentWanderCooldown = 0.0f;
        if (_navMeshAgent.stoppingDistance >= _navMeshAgent.remainingDistance && _currentWanderCooldown <= 0.0f)
        {
            Vector3 _randomPoint = RandomNavmeshPoint(transform.position, _wanderRange);
            if (_randomPoint != Vector3.zero) _navMeshAgent.SetDestination(_randomPoint);
        }
    }

    protected void OnTriggerEnter(Collider _hit)
    {
        if (_hit.gameObject.GetComponent<Door>()) _hit.gameObject.GetComponent<Door>().Interact();
    }
    #endregion
}