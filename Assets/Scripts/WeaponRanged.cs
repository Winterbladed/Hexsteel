using UnityEngine;

public class WeaponRanged : Weapon
{
    #region Variables
    [Header("Ranged Extras")]
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _transform;
    #endregion

    #region Private Functions
    private void Start()
    {
        _normalDamage = _Damage;
        _reducedDamage = _Damage / 2;
        _movement = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        _movement.SetShooting(_isAttacked);
        if (_isAttacked)
        {
            _attackTime += Time.deltaTime;
            if (_attackTime > 0.75f)
            {
                GameObject _newProjectile = _projectile;
                Projectile _Projectile = _newProjectile.GetComponent<Projectile>();
                _Projectile._DamageType = _DamageType;
                _Projectile._Damage = _Damage;
                _Projectile._CriticalChance = _CriticalChance;
                _Projectile._CriticalDamage = _CriticalDamage;
                _Projectile._StatusChance = _StatusChance;
                Instantiate(_newProjectile, _transform.position, _transform.rotation);
                Attack();
                _attackTime = 0.0f;
                _isAttacked = false;
            }
        }
        else if (!_isAttacked && !_movement.GetIsDodging())
        {
            if (Input.GetMouseButtonDown(0))
            {
                _attackTime = 0.0f;
                _isAttacked = true;
            }
        }
    }
    #endregion
}