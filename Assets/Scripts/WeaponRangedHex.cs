using UnityEngine;

public class WeaponRangedHex : Weapon
{
    #region Variables
    [Header("Ranged Extras")]
    [SerializeField] private GameObject[] _projectile;
    private Transform _transform;
    [SerializeField] private float _attackRate;
    [SerializeField] private float _projectileSpread;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _transform = GetComponentInChildren<NozzleRaycast>().transform;
    }

    protected override void Update()
    {
        _movement.SetIsTwoHandedRanged(true);
        _movement.SetShootingTwo(_isAttacked);
        if (Input.GetMouseButton(0) && !_movement.GetIsDodging() && Time.timeScale > 0.0f)
        {
            _isAttacked = true;
            _attackTime += Time.deltaTime;
            if (_attackTime > _attackRate)
            {
                //Welcome to Randomize Hell
                int _random = Random.Range(0, 12);
                int _random2 = Random.Range(0, 8);

                GameObject _newProjectile = _projectile[_random];
                Projectile _Projectile = _newProjectile.GetComponent<Projectile>();

                if (_random == 0) _Projectile._DamageType = DamageType._Blunt;
                else if (_random == 1) _Projectile._DamageType = DamageType._Pierce;
                else if (_random == 2) _Projectile._DamageType = DamageType._Slash;
                else if (_random == 3) _Projectile._DamageType = DamageType._Toxin;
                else if (_random == 4) _Projectile._DamageType = DamageType._Ice;
                else if (_random == 5) _Projectile._DamageType = DamageType._Fire;
                else if (_random == 6) _Projectile._DamageType = DamageType._Electric;
                else if (_random == 7) _Projectile._DamageType = DamageType._Virus;
                else if (_random == 8) _Projectile._DamageType = DamageType._Gas;
                else if (_random == 9) _Projectile._DamageType = DamageType._Corrode;
                else if (_random == 10) _Projectile._DamageType = DamageType._Melt;
                else if (_random == 11) _Projectile._DamageType = DamageType._Magnetic;
                else if (_random == 12) _Projectile._DamageType = DamageType._Blast;
                if (_random2 == 0) _Projectile.SetProjectileVector(ProjectileVector.Straight);
                else if (_random2 == 1) _Projectile.SetProjectileVector(ProjectileVector.Upper);
                else if (_random2 == 2) _Projectile.SetProjectileVector(ProjectileVector.Lower);
                else if (_random2 == 3) _Projectile.SetProjectileVector(ProjectileVector.Left);
                else if (_random2 == 4) _Projectile.SetProjectileVector(ProjectileVector.Right);
                else if (_random2 == 5) _Projectile.SetProjectileVector(ProjectileVector.UpperLeft);
                else if (_random2 == 6) _Projectile.SetProjectileVector(ProjectileVector.UpperRight);
                else if (_random2 == 7) _Projectile.SetProjectileVector(ProjectileVector.LowerLeft);
                else if (_random2 == 8) _Projectile.SetProjectileVector(ProjectileVector.LowerRight);

                //Inherit Weapon Stats to Projectile Stats
                _Projectile._Damage = _Damage;
                _Projectile._CriticalChance = _CriticalChance;
                _Projectile._CriticalDamage = _CriticalDamage;
                _Projectile._StatusChance = _StatusChance;
                _Projectile._StatusDamage = _StatusDamage;
                _Projectile._StatusTimer = _StatusTimer;
                _Projectile._StatusTicker = _StatusTicker;
                _Projectile.SetProjectileSpread(Random.Range(0.0f, _projectileSpread));
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