using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : Damage
{
    #region Variables
    [SerializeField] protected GameObject _target;
    [SerializeField] protected NavMeshAgent _agent;
    protected float _distanceFromTarget;
    protected Vector3 _initialRotation;
    protected Vector3 _originalPosition;

    [Header("Other Enemy Stats")]
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _aggroRange;
    [SerializeField] protected float _aggroBuffer;
    protected float _attackTime = 0.0f;
    protected bool _isAttacking = false;
    protected float _slowMoveSpeed;

    [SerializeField] protected UnityEvent _onAttackEvt;
    #endregion

    #region Protected Functions
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _aggroRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    protected void SetStats()
    {
        _agent.speed = _moveSpeed;
        _slowMoveSpeed = _moveSpeed / 2;
        _agent.acceleration = _moveSpeed;
        _normalDamage = _Damage;
        _reducedDamage = _Damage / 2;
        _agent.stoppingDistance = _attackRange;
        _originalPosition = transform.position;
    }

    protected void GoToTarget()
    {
        _agent.SetDestination(_target.transform.position);
    }

    protected void GoToTargetWhenNear()
    {
        _distanceFromTarget = Vector3.Distance(transform.position, _target.transform.position);
        if (_distanceFromTarget <= _aggroRange) _agent.SetDestination(_target.transform.position);
        else if(_distanceFromTarget > _aggroRange + _aggroBuffer) _agent.SetDestination(_originalPosition);
    }

    protected void AttackWhenNearTarget()
    {
        _distanceFromTarget = Vector3.Distance(transform.position, _target.transform.position);
        if (_distanceFromTarget <= _attackRange)
        {
            _initialRotation = transform.eulerAngles;
            _isAttacking = true;
            _agent.speed = 0.0f;
        }
        if (_isAttacking)
        {
            transform.LookAt(_target.transform.position);
            _attackTime += Time.deltaTime;
            if (_attackTime > _attackSpeed)
            {
                _onAttackEvt.Invoke();
                ResetAttack();
                if (_distanceFromTarget <= _attackRange + 2)
                {
                    DealDamage(_target);
                }
            }
        }
    }

    protected void AttackRangeWhenNearTarget(GameObject _gameobject, Transform _transform)
    {
        _distanceFromTarget = Vector3.Distance(transform.position, _target.transform.position);
        if (_distanceFromTarget <= _attackRange)
        {
            _initialRotation = transform.eulerAngles;
            _isAttacking = true;
            _agent.speed = 0.0f;
            transform.LookAt(_target.transform.position);
            _attackTime += Time.deltaTime;
            if (_attackTime > _attackSpeed)
            {
                _onAttackEvt.Invoke();
                GameObject _newProjectile = _gameobject;
                Projectile _Projectile = _newProjectile.GetComponent<Projectile>();
                _Projectile._Damage = _Damage;
                _Projectile._CriticalChance = _CriticalChance;
                _Projectile._CriticalDamage = _CriticalDamage;
                _Projectile._StatusChance = _StatusChance;
                Instantiate(_gameobject, _transform.position, _transform.rotation);
                _attackTime = 0.0f;
            }
        }
        else if (_distanceFromTarget > _attackRange + 1)
        {
            ResetAttack();
        }
    }

    protected void ResetAttack()
    {
        _attackTime = 0.0f;
        _isAttacking = false;
        _agent.speed = _moveSpeed;
        transform.eulerAngles = _initialRotation;
    }
    #endregion

    #region Public Functions
    public void Slow()
    {
        _agent.speed = _slowMoveSpeed;
    }

    public void UnSlow()
    {
        _agent.speed = _moveSpeed;
    }

    public void SetTarget(GameObject _newTarget) { _target = _newTarget; }
    #endregion
}