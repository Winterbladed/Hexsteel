using UnityEngine;
using UnityEngine.AI;

public class Npc : Interactable
{
    #region Variables
    [Header("Npc Reference")]
    [SerializeField] protected Animator _animator;
    [SerializeField] protected NavMeshAgent _navMeshAgent;

    [Header("Npc Stats")]
    [SerializeField] protected float _wanderRange;
    [SerializeField] protected float _wanderCooldown;
    protected float _currentWanderCooldown;

    [Header("Npc Talk")]
    [SerializeField] protected GameObject _text;
    [SerializeField] protected float _talkDuration;
    protected float _talkTime;
    protected bool _isTalking;
    #endregion

    #region Private Functions
    protected virtual void Start()
    {
        Vector3 _randomPoint = RandomNavmeshPoint(transform.position, _wanderRange);
        if (_randomPoint != Vector3.zero) _navMeshAgent.SetDestination(_randomPoint);
    }

    protected virtual void Update()
    {
        Animatorr();
        Wander();
        Talking();
    }

    protected void Animatorr()
    {
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

    protected void Talking()
    {
        if (_isTalking)
        {
            _talkTime += Time.deltaTime;
            if (_talkTime > _talkDuration)
            {
                _text.SetActive(false);
                _talkTime = 0.0f;
                _isTalking = false;
            }
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
        if (_hit.gameObject.GetComponent<Door>()) _hit.gameObject.GetComponent<Door>().DoorHandle();
    }
    #endregion

    #region Public Functions
    public void Talk()
    {
        _text.SetActive(true);
        _isTalking = true;
        _talkTime = 0.0f;
    }
    #endregion
}