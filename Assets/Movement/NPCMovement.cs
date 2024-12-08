using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class NPCMovement : Movement
{
    #region Variables
    [Header("Npc Stats")]
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

    protected Vector3 RandomNavmeshPoint(Vector3 _center, float _range)
    {
        Vector3 _randomPoint = _center + Random.insideUnitSphere * _range;
        NavMeshHit _hit;
        if (NavMesh.SamplePosition(_randomPoint, out _hit, _range, NavMesh.AllAreas)) return _hit.position;
        return Vector3.zero;
    }

    protected void OnTriggerEnter(Collider _hit)
    {
        if (_hit.gameObject.GetComponent<Door>()) _hit.gameObject.GetComponent<Door>().Interact();
    }
    #endregion
}