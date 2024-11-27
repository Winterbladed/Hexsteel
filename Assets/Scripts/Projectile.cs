using UnityEngine;
using UnityEngine.Events;

public class Projectile : Damage
{
    #region Variables
    [Header("Projectile Stats")]
    public Rigidbody _Rigidbody;
    private enum ProjectileVector
    {
        Straight,
        Left, Right,
        Upper, Lower,
        UpperLeft, UpperRight,
        LowerRight, LowerLeft
    }
    private enum ProjectileType
    {
        Normal,
        Physics
    }
    [SerializeField] private ProjectileVector _projectileVector;
    [SerializeField] private ProjectileType _projectileType;
    [Range(0.0f, 10000.0f)]
    [SerializeField] private float _projectileSpeed = 1000.0f;
    [SerializeField] private float _projectileSpread;
    [Range(0.1f, 5.0f)]
    [SerializeField] protected float _projectileTimer = 2.0f;
    [SerializeField] private UnityEvent _onHitEvt;
    #endregion

    #region Private Function
    private void Start()
    {
        _normalDamage = _Damage;
        _reducedDamage = _Damage / 2;
        CriticalDamageChance();
        StatusChance();
        DetermineVectorVelocity();
        Destroy(gameObject, _projectileTimer);
    }

    private void DetermineVectorVelocity()
    {
        if (_projectileVector == ProjectileVector.Straight) _Rigidbody.velocity = transform.forward * _projectileSpeed;
        else
        {
            _Rigidbody.velocity += new Vector3
            (
                (_projectileVector == ProjectileVector.Left || _projectileVector == ProjectileVector.UpperLeft || _projectileVector == ProjectileVector.LowerLeft) ? -_projectileSpread
                    : ((_projectileVector == ProjectileVector.Right || _projectileVector == ProjectileVector.UpperRight || _projectileVector == ProjectileVector.LowerRight) ? _projectileSpread : 0),
                (_projectileVector == ProjectileVector.Lower || _projectileVector == ProjectileVector.LowerLeft || _projectileVector == ProjectileVector.LowerRight) ? -_projectileSpread
                    : ((_projectileVector == ProjectileVector.Upper || _projectileVector == ProjectileVector.UpperLeft || _projectileVector == ProjectileVector.UpperRight) ? _projectileSpread : 0),
                0
            ) * _projectileSpeed;
            _Rigidbody.velocity += transform.forward * _projectileSpeed;
        }
    }
    #endregion

    #region Unity Messages
    private void OnCollisionEnter(Collision _hit)
    {
        _onHitEvt.Invoke();
        DealDamage(_hit.gameObject);
        if (_projectileType == ProjectileType.Normal) Destroy(gameObject);
    }
    #endregion
}