using UnityEngine;

public class WeaponRanged : Weapon
{
    #region Variables
    [Header("Ranged Extras")]
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _transform;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        _movement.SetShooting(_isAttacked);
        if (_isAttacked)
        {
            _attackTime += Time.deltaTime;
            if (_attackTime > 0.5f)
            {
                GameObject _newProjectile = _projectile;
                Projectile _Projectile = _newProjectile.GetComponent<Projectile>();
                _Projectile._DamageType = _DamageType;
                _Projectile._Damage = _Damage;
                _Projectile._CriticalChance = _CriticalChance;
                _Projectile._CriticalDamage = _CriticalDamage;
                _Projectile._StatusChance = _StatusChance;
                _Projectile._StatusDamage = _StatusDamage;
                _Projectile._StatusTimer = _StatusTimer;
                _Projectile._StatusTicker = _StatusTicker;
                _Projectile.SetIsPlayer(true);
                Instantiate(_newProjectile, _transform.position, _transform.rotation);
                Attack();
                _cooldownTime = 0.0f; _attackTime = 0.0f;
                _isAttacked = false; _isOnCooldown = true;
            }
        }
        else if (!_isAttacked && !_movement.GetIsDodging())
        {
            if (Input.GetMouseButtonDown(0) && !_isOnCooldown && Time.timeScale > 0.0f)
            {
                _cooldownTime = 0.0f;
                _attackTime = 0.0f;
                _isAttacked = true;
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

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
    #endregion
}