using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(AudioSource))]

public class Projectile : Damage
{
    #region Variables
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;
    private TrailRenderer _trailRenderer;
    private AudioSource _audioSource;

    [Header("Projectile Stats")]
    public ProjectileVector _projectileVector;
    public ProjectileType _projectileType;
    [Range(0.0f, 10000.0f)]
    [SerializeField] private float _projectileSpeed = 1000.0f;
    [SerializeField] private float _projectileSpread;
    private bool _isHit = false;
    #endregion

    #region Private Function
    protected override void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _trailRenderer = GetComponent<TrailRenderer>();
        _audioSource = GetComponent<AudioSource>();
        base.Start();
        CriticalDamageChance();
        StatusChance();
        DetermineVectorVelocity();
        Destroy(gameObject, 4.0f);
    }

    private void DetermineVectorVelocity()
    {
        if (_projectileVector == ProjectileVector.Straight) _rigidbody.velocity = transform.forward * _projectileSpeed;
        else
        {
            _rigidbody.velocity += new Vector3
            (
                (_projectileVector == ProjectileVector.Left || _projectileVector == ProjectileVector.UpperLeft || _projectileVector == ProjectileVector.LowerLeft) ? -_projectileSpread
                    : ((_projectileVector == ProjectileVector.Right || _projectileVector == ProjectileVector.UpperRight || _projectileVector == ProjectileVector.LowerRight) ? _projectileSpread : 0),
                (_projectileVector == ProjectileVector.Lower || _projectileVector == ProjectileVector.LowerLeft || _projectileVector == ProjectileVector.LowerRight) ? -_projectileSpread
                    : ((_projectileVector == ProjectileVector.Upper || _projectileVector == ProjectileVector.UpperLeft || _projectileVector == ProjectileVector.UpperRight) ? _projectileSpread : 0),
                0
            ) * _projectileSpeed; _rigidbody.velocity += transform.forward * _projectileSpeed;
        }
    }
    #endregion

    #region Unity Messages
    private void OnCollisionEnter(Collision _hit)
    {
        if (!_isHit)
        {
            _rigidbody.useGravity = true;
            _trailRenderer.emitting = false;
            _audioSource.volume = 0.1f;
            if (_projectileType == ProjectileType.Normal) Destroy(gameObject);
            DealDamage(_hit.gameObject);
            _isHit = true;
        }
    }
    #endregion

    #region Public Functions
    public void SetProjectileVector(ProjectileVector _newProjectileVector) { _projectileVector = _newProjectileVector; }
    public void SetProjectileSpread(float _newSpread) { _projectileSpread = _newSpread; }
    #endregion
}