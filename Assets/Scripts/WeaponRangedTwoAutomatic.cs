using UnityEngine;

public class WeaponRangedTwoAutomatic : Weapon
{
    #region Variables
    [Header("Ranged Extras")]
    [SerializeField] private GameObject _projectile;
    private Transform _transform;
    [SerializeField] private float _attackRate;
    [SerializeField] private float _projectileSpread = 0.1f;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _transform = GetComponentInChildren<NozzleRaycast>().transform;
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
                //Inherit Weapon Stats to Projectile Stats
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

                //Randomize Projectile Vector and Apply Projectile Spread
                int _random = Random.Range(0, 8);
                if (_random == 0) _Projectile.SetProjectileVector(ProjectileVector.Straight);
                else if (_random == 1) _Projectile.SetProjectileVector(ProjectileVector.Upper);
                else if (_random == 2) _Projectile.SetProjectileVector(ProjectileVector.Lower);
                else if (_random == 3) _Projectile.SetProjectileVector(ProjectileVector.Left);
                else if (_random == 4) _Projectile.SetProjectileVector(ProjectileVector.Right);
                else if (_random == 5) _Projectile.SetProjectileVector(ProjectileVector.UpperLeft);
                else if (_random == 6) _Projectile.SetProjectileVector(ProjectileVector.UpperRight);
                else if (_random == 7) _Projectile.SetProjectileVector(ProjectileVector.LowerLeft);
                else if (_random == 8) _Projectile.SetProjectileVector(ProjectileVector.LowerRight);
                _Projectile.SetProjectileSpread(Random.Range(0.0f, _projectileSpread));

                //Set Player as owner of Projectile
                _Projectile.SetIsPlayer(true);

                //Create New Projectile
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