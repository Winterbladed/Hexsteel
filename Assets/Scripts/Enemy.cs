using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(EnemyMovement))]

public class Enemy : Damage
{
    #region Variables
    [Header("Other Enemy Stats")]
    [SerializeField] protected float _attackSpeed;
    protected float _attackTime = 0.0f;
    protected bool _isAttacking = false;

    [SerializeField] protected UnityEvent _onAttackEvt;
    protected EnemyMovement _enemyMovement;
    protected Player _player;
    #endregion

    #region Protected Functions
    protected virtual void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _player = _enemyMovement.GetPlayer();
        _normalDamage = _Damage;
        _reducedDamage = _Damage / 2;
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _enemyMovement.GetStopRange());

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _enemyMovement.GetDetectRange());
    }

    protected void GoToTarget()
    {
        _enemyMovement.GetNavMeshAgent().SetDestination(_player.transform.position);
    }

    protected void GoToTargetWhenNear()
    {
        _enemyMovement.SetDistanceFromTarget(Vector3.Distance(transform.position, _player.transform.position));
        if (_enemyMovement.GetDistanceFromTarget() <= _enemyMovement.GetDetectRange()) _enemyMovement.GetNavMeshAgent().SetDestination(_player.transform.position);
        else if(_enemyMovement.GetDistanceFromTarget() > _enemyMovement.GetDetectRange() + _enemyMovement.GetFollowBuffer()) _enemyMovement.GetNavMeshAgent().SetDestination(_enemyMovement._OriginalPosition);
    }

    protected void AttackWhenNearTarget()
    {
        _enemyMovement.SetDistanceFromTarget(Vector3.Distance(transform.position, _player.transform.position));
        if (_enemyMovement.GetDistanceFromTarget() <= _enemyMovement.GetStopRange())
        {
            _enemyMovement._InitialRotation = transform.eulerAngles;
            _isAttacking = true;
            _enemyMovement.GetNavMeshAgent().speed = 0.0f;
        }
        if (_isAttacking)
        {
            transform.LookAt(_player.transform.position);
            _attackTime += Time.deltaTime;
            if (_attackTime > _attackSpeed)
            {
                _onAttackEvt.Invoke();
                ResetAttack();
                if (_enemyMovement.GetDistanceFromTarget() <= _enemyMovement.GetStopRange() + 1)
                {
                    DealDamage(_player.gameObject);
                }
            }
        }
    }

    protected void AttackRangeWhenNearTarget(GameObject _gameobject, Transform _transform)
    {
        _enemyMovement.SetDistanceFromTarget(Vector3.Distance(transform.position, _player.transform.position));
        if (_enemyMovement.GetDistanceFromTarget() <= _enemyMovement.GetStopRange())
        {
            _enemyMovement._InitialRotation = transform.eulerAngles;
            _isAttacking = true;
            _enemyMovement.GetNavMeshAgent().speed = 0.0f;
            transform.LookAt(_player.transform.position);
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
        else if (_enemyMovement.GetDistanceFromTarget() > _enemyMovement.GetStopRange() + 1)
        {
            ResetAttack();
        }
    }

    protected void ResetAttack()
    {
        _attackTime = 0.0f;
        _isAttacking = false;
        _enemyMovement.GetNavMeshAgent().speed = _enemyMovement.GetCurrentSpeed();
        transform.eulerAngles = _enemyMovement._InitialRotation;
    }
    #endregion
}