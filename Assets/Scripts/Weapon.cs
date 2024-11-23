using UnityEngine;
using UnityEngine.Events;

public class Weapon : Damage
{
    #region Variables
    [SerializeField] protected GameObject _trail;

    [Header("Other Weapon Stats")]
    [SerializeField] protected float _radius = 1.0f;
    [SerializeField] protected float _distance = 2.0f;
    [SerializeField] protected int _comboIndexes;
    protected float _attackTime;
    protected bool _isAttacked = false;
    protected int _comboIndex = 0;
    protected Movement _movement;
    [SerializeField] protected UnityEvent _onAttack;
    #endregion

    #region Private Functions
    protected virtual void Start()
    {
        _normalDamage = _Damage;
        _reducedDamage = _Damage / 2;
        _movement = GetComponentInParent<Movement>();
    }

    protected virtual void Update()
    {
        _movement.SetAttacking(_isAttacked);
        _movement.SetComboIndex(_comboIndex);
        if (_isAttacked)
        {
            _attackTime += Time.deltaTime;
            if (_attackTime > 0.75f)
            {
                Attack();
                if (_comboIndex < _comboIndexes) _comboIndex++;
                else _comboIndex = 0;
                _attackTime = 0.0f;
                _isAttacked = false;
                _trail.SetActive(false);
            }
        }
        else if (!_isAttacked && !_movement.GetIsDodging())
        {
            if (Input.GetMouseButtonDown(0))
            {
                _attackTime = 0.0f;
                _isAttacked = true;
                _trail.SetActive(true);
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