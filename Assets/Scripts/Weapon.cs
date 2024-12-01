using UnityEngine;
using UnityEngine.Events;

public class Weapon : Damage
{
    #region Variables
    [SerializeField] protected GameObject _trail;

    [Header("Other Weapon Stats")]
    [SerializeField] protected float _radius = 1.0f;
    [SerializeField] protected float _distance = 2.0f;
    protected float _attackTime;
    protected float _cooldownTime;
    protected bool _isAttacked = false;
    [SerializeField] protected int _comboIndexes;
    protected int _comboIndex = 0;
    protected bool _isOnCooldown;

    [Header("Weapon References")]
    [SerializeField] protected UnityEvent _onAttack;
    protected Movement _movement;
    protected Health _health;
    #endregion

    #region Private Functions
    protected virtual void Start()
    {
        _normalDamage = _Damage;
        _reducedDamage = _Damage / 2;
        _attackTime = 0.0f;
        _cooldownTime = 0.0f;
        _isAttacked = false;
        _isOnCooldown = false;
        _movement = GetComponentInParent<Movement>();
        _health = GetComponentInParent<Health>();
    }

    protected virtual void Update()
    {
        _movement.SetAttacking(_isAttacked);
        _movement.SetComboIndex(_comboIndex);
        if (_isAttacked)
        {
            _attackTime += Time.deltaTime;
            if (_attackTime > 1.0f)
            {
                Attack();
                if (_comboIndex < _comboIndexes) _comboIndex++;
                else _comboIndex = 0;
                _cooldownTime = 0.0f;
                _attackTime = 0.0f;
                _isAttacked = false;
                _trail.SetActive(false);
                _isOnCooldown = true;
            }
        }
        else if (!_isAttacked && !_movement.GetIsDodging())
        {
            if (Input.GetMouseButtonDown(0) && !_isAttacked && !_isOnCooldown)
            {
                _cooldownTime = 0.0f;
                _attackTime = 0.0f;
                _isAttacked = true;
                _trail.SetActive(true);
            }
        }
        if (_isOnCooldown)
        {
            _cooldownTime += Time.deltaTime;
            if (_cooldownTime > 0.2f)
            {
                _cooldownTime = 0.0f;
                _isOnCooldown = false;
            }
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 _positionInFront = transform.position + transform.forward * _distance;
        Gizmos.DrawWireSphere(_positionInFront, _radius);
    }
    #endregion

    #region Public Functions
    public void Attack()
    {
        _onAttack.Invoke();
        Vector3 _positionInFront = transform.position + transform.forward * _distance;
        Collider[] _colliders = Physics.OverlapSphere(_positionInFront, _radius);
        foreach (Collider _hit in _colliders) DealDamage(_hit.gameObject);
    }

    public bool GetIsAttacked() { return _isAttacked; }
    #endregion
}