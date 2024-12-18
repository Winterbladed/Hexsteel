using UnityEngine;

public class WeaponRangedTwoAutomatic : Weapon
{
    #region Variables
    [Header("Ranged Extras")]
    [SerializeField] private GameObject[] _projectile;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _attackRate;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        _movement.SetShootingTwo(_isAttacked);
        if (Input.GetMouseButton(0) && !_movement.GetIsDodging() && Time.timeScale > 0.0f)
        {
            _isAttacked = true;
            _attackTime += Time.deltaTime;
            if (_attackTime > _attackRate)
            {
                GameObject _newProjectile = _projectile[Random.Range(0, _projectile.Length)];
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
                _attackTime = 0.0f;
            }
        }
        else
        {
            _isAttacked = false;
            _attackTime = 0.0f;
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
    #endregion
}