using UnityEngine;
using UnityEngine.Events;

public class Projectile : Damage
{
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
    [SerializeField] private ProjectileVector _projectileVector;
    [Range(0.0f, 10000.0f)]
    [SerializeField] private float _projectileSpeed = 1000.0f;
    [Range(0.1f, 5.0f)]
    [SerializeField] protected float _projectileTimer = 2.0f;
    [SerializeField] private UnityEvent _onHitEvt;

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
                (_projectileVector == ProjectileVector.Left || _projectileVector == ProjectileVector.UpperLeft || _projectileVector == ProjectileVector.LowerLeft) ? -0.1f
                    : ((_projectileVector == ProjectileVector.Right || _projectileVector == ProjectileVector.UpperRight || _projectileVector == ProjectileVector.LowerRight) ? 0.1f : 0),
                (_projectileVector == ProjectileVector.Lower || _projectileVector == ProjectileVector.LowerLeft || _projectileVector == ProjectileVector.LowerRight) ? -0.1f
                    : ((_projectileVector == ProjectileVector.Upper || _projectileVector == ProjectileVector.UpperLeft || _projectileVector == ProjectileVector.UpperRight) ? 0.1f : 0),
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
        Destroy(gameObject);
    }
    #endregion
}