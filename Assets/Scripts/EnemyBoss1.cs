using UnityEngine;
using UnityEngine.Events;

public class EnemyBoss1 : Enemy
{
    #region Variables
    [Header("Enemy Boss Reference")]
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _rangedObject;
    [SerializeField] private Transform _rangedObjectSpawn;

    [Header("Enemy Boss Extra Stats")]
    [SerializeField] protected float _attackSpeed1;
    protected float _attackTime1 = 0.0f;
    [SerializeField] protected UnityEvent _onAttackEvt1;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        GoToTarget();
    }

    private void Update()
    {
        transform.LookAt(_player.transform.position);
        Aniimator();
        GoToTarget();
        AttackWhenNearTarget();
        AttackRangeWhenNearTarget1(_rangedObject, _rangedObjectSpawn);
    }

    private void Aniimator()
    {
        if (_agent.velocity.magnitude > 0.0f) _animator.SetBool("_isMoving", true);
        else if (_agent.velocity.magnitude <= 0.0f) _animator.SetBool("_isMoving", false);
        _animator.SetBool("_isAttacking", _isAttacking);
    }

    protected void AttackRangeWhenNearTarget1(GameObject _gameobject, Transform _transform)
    {
        _attackTime1 += Time.deltaTime;
        if (_attackTime1 > _attackSpeed1)
        {
            _onAttackEvt1.Invoke();
            GameObject _newProjectile = _gameobject;
            Projectile _Projectile = _newProjectile.GetComponent<Projectile>();
            _Projectile._Damage = _Damage;
            _Projectile._CriticalChance = _CriticalChance;
            _Projectile._CriticalDamage = _CriticalDamage;
            _Projectile._StatusChance = _StatusChance;
            Instantiate(_gameobject, _transform.position, _transform.rotation);
            _attackTime1 = 0.0f;
        }
    }
    #endregion
}