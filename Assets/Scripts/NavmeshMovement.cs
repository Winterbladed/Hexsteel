using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent (typeof(Damage))]

public class NavmeshMovement : Movement
{
    #region Variables
    protected Animator _animator;
    [Header("Npc Attack Stats")]
    [SerializeField] protected float _attackSpeed = 0.5f;
    protected float _attackTime = 0.0f;
    protected bool _isAttacking = false;
    protected int _comboIndexes = 2;
    protected int _comboIndex = 0;
    [SerializeField] protected UnityEvent _onAttackEvt;
    [SerializeField] protected GameObject _projectile;
    [SerializeField] protected Transform _transform;
    protected Damage _damage;

    [Header("Npc State")]
    [SerializeField] protected State _state;
    [SerializeField] protected _TargetData _targetData;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _animator = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _damage = GetComponent<Damage>();
        _navMeshAgent.speed = _currentSpeed;
        _navMeshAgent.acceleration = _currentSpeed;
        _navMeshAgent.stoppingDistance = 0;
        Vector3 _randomPoint = RandomNavmeshPoint(transform.position, _wanderRange);
        if (_randomPoint != Vector3.zero) _navMeshAgent.SetDestination(_randomPoint);
    }

    protected virtual void Update()
    {
        Animatorr();
    }

    protected void Animatorr()
    {
        _navMeshAgent.speed = _currentSpeed;
        _navMeshAgent.acceleration = _currentSpeed;
    }

    protected void PassiveSight()
    {
        RaycastHit _hit; Ray _ray = new Ray(transform.position + new Vector3(0.0f, 1.8f, 0.0f), transform.forward);
        if (Physics.Raycast(_ray, out _hit, _raycastDistance, _raycastLayerMask))
        {
            _state = State._Idle;
        }
    }

    protected void AggressiveSight()
    {
        RaycastHit _hit; Ray _ray = new Ray(transform.position + new Vector3(0.0f, 1.8f, 0.0f), transform.forward);
        if (Physics.Raycast(_ray, out _hit, _raycastDistance, _raycastLayerMask))
        {
            if (_targetData == _TargetData._Player && _hit.transform.GetComponent<Player>())
            {
                SetTarget(_hit.collider.gameObject);
                Collider[] _colliders = Physics.OverlapSphere(transform.position, 10.0f);
                foreach (Collider _called in _colliders)
                {
                    if (_called.gameObject.GetComponent<NavmeshMovement>())
                    {
                        _called.gameObject.GetComponent<NavmeshMovement>().SetTarget(_hit.collider.gameObject);
                        _called.gameObject.GetComponent<NavmeshMovement>().SetAggro();
                    }
                }
            }
            else if (_targetData == _TargetData._NavmeshMovement && _hit.transform.GetComponent<NavmeshMovement>())
            {
                SetTarget(_hit.collider.gameObject);
                Collider[] _colliders = Physics.OverlapSphere(transform.position, 10.0f);
                foreach (Collider _called in _colliders)
                {
                    if (_called.gameObject.GetComponent<NavmeshMovement>())
                    {
                        _called.gameObject.GetComponent<NavmeshMovement>().SetTarget(_hit.collider.gameObject);
                        _called.gameObject.GetComponent<NavmeshMovement>().SetAggro();
                    }
                }
            }
            else if (_targetData == _TargetData._AI_Passive && _hit.transform.GetComponent<AI_Passive>())
            {
                SetTarget(_hit.collider.gameObject);
                Collider[] _colliders = Physics.OverlapSphere(transform.position, 10.0f);
                foreach (Collider _called in _colliders)
                {
                    if (_called.gameObject.GetComponent<NavmeshMovement>())
                    {
                        _called.gameObject.GetComponent<NavmeshMovement>().SetTarget(_hit.collider.gameObject);
                        _called.gameObject.GetComponent<NavmeshMovement>().SetAggro();
                    }
                }
            }
            else if (_targetData == _TargetData._AI_Neutral && _hit.transform.GetComponent<AI_Neutral>())
            {
                SetTarget(_hit.collider.gameObject);
                Collider[] _colliders = Physics.OverlapSphere(transform.position, 10.0f);
                foreach (Collider _called in _colliders)
                {
                    if (_called.gameObject.GetComponent<NavmeshMovement>())
                    {
                        _called.gameObject.GetComponent<NavmeshMovement>().SetTarget(_hit.collider.gameObject);
                        _called.gameObject.GetComponent<NavmeshMovement>().SetAggro();
                    }
                }
            }
            else if (_targetData == _TargetData._AI_Aggressive && _hit.transform.GetComponent<AI_AggressiveMelee>())
            {
                SetTarget(_hit.collider.gameObject);
                Collider[] _colliders = Physics.OverlapSphere(transform.position, 10.0f);
                foreach (Collider _called in _colliders)
                {
                    if (_called.gameObject.GetComponent<NavmeshMovement>())
                    {
                        _called.gameObject.GetComponent<NavmeshMovement>().SetTarget(_hit.collider.gameObject);
                        _called.gameObject.GetComponent<NavmeshMovement>().SetAggro();
                    }
                }
            }
            _state = State._Aggro;
        }
    }

    protected void RetreatSight()
    {
        RaycastHit _hit; Ray _ray = new Ray(transform.position + new Vector3(0.0f, 1.8f, 0.0f), transform.forward);
        if (Physics.Raycast(_ray, out _hit, _raycastDistance, _raycastLayerMask))
        {
            _state = State._Retreat;
        }
    }

    protected void Wander()
    {
        if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance) _animator.SetBool("_isWalking", true);
        else _animator.SetBool("_isWalking", false);
        if (_currentWanderCooldown < _wanderCooldown) _currentWanderCooldown += Time.deltaTime;
        if (_currentWanderCooldown > _wanderCooldown) _currentWanderCooldown = 0.0f;
        if (_navMeshAgent.stoppingDistance >= _navMeshAgent.remainingDistance && _currentWanderCooldown <= 0.0f)
        {
            Vector3 _randomPoint = RandomNavmeshPoint(transform.position, _wanderRange);
            if (_randomPoint != Vector3.zero) _navMeshAgent.SetDestination(_randomPoint);
        }
    }

    protected void WanderFromOrigin()
    {
        float _distanceFromOrigin = Vector3.Distance(transform.position, _OriginalPosition);
        if (_distanceFromOrigin < _wanderRange)
        {
            if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance) _animator.SetBool("_isWalking", true);
            else _animator.SetBool("_isWalking", false);
            if (_currentWanderCooldown < _wanderCooldown) _currentWanderCooldown += Time.deltaTime;
            if (_currentWanderCooldown > _wanderCooldown) _currentWanderCooldown = 0.0f;
            if (_navMeshAgent.stoppingDistance >= _navMeshAgent.remainingDistance && _currentWanderCooldown <= 0.0f)
            {
                Vector3 _randomPoint = RandomNavmeshPoint(transform.position, _wanderRange);
                if (_randomPoint != Vector3.zero) _navMeshAgent.SetDestination(_randomPoint);
            }
        }
        else
        {
            _navMeshAgent.SetDestination(_OriginalPosition);
        }
    }

    protected void RetreatToIdle()
    {
        _navMeshAgent.SetDestination(_OriginalPosition);
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) SetState(State._Idle);
    }

    protected void RetreatToWander()
    {
        _navMeshAgent.SetDestination(_OriginalPosition);
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) SetState(State._Wander);
    }

    protected void WalkToTarget()
    {
        if (_navMeshAgent.velocity.magnitude > 0.0f) _animator.SetBool("_isWalking", true);
        else if (_navMeshAgent.velocity.magnitude <= 0.0f) _animator.SetBool("_isWalking", false);
        _animator.SetBool("_isRunning", false);
        if (_target) _navMeshAgent.SetDestination(_target.transform.position);
        else
        {
            _navMeshAgent.stoppingDistance = 0;
            _currentSpeed = _Speed;
            _animator.SetBool("_isAttacking", false);
            _animator.SetBool("_isShooting", false);
            _attackTime = 0.0f;
            _isAttacking = false;
            _navMeshAgent.speed = _currentSpeed;
            _target = null;
            SetState(State._Idle);
        }
        if (!_isSlowed && !_isAttacking) _currentSpeed = _Speed;
    }

    protected void RunToTarget()
    {
        if (_navMeshAgent.velocity.magnitude > 0.0f) _animator.SetBool("_isRunning", true);
        else if (_navMeshAgent.velocity.magnitude <= 0.0f) _animator.SetBool("_isRunning", false);
        _animator.SetBool("_isWalking", false);
        if (_target) _navMeshAgent.SetDestination(_target.transform.position);
        else
        {
            _animator.SetBool("_isRunning", false);
            _navMeshAgent.stoppingDistance = 0;
            _currentSpeed = _Speed;
            _animator.SetBool("_isAttacking", false);
            _animator.SetBool("_isShooting", false);
            _attackTime = 0.0f;
            _isAttacking = false;
            _navMeshAgent.speed = _currentSpeed;
            _target = null;
            SetState(State._Idle);
        }
        if (!_isSlowed && !_isAttacking) _currentSpeed = _runSpeed;
    }

    protected void AttackWhenNearTarget()
    {
        if (_target)
        {
            _navMeshAgent.stoppingDistance = _stopRange;
            _damage.SetOwner(gameObject);
            SetDistanceFromTarget(Vector3.Distance(transform.position, _target.transform.position));
            if (GetDistanceFromTarget() <= GetStopRange())
            {
                _animator.SetBool("_isAttacking", true);
                _InitialRotation = transform.eulerAngles;
                _isAttacking = true;
                _navMeshAgent.speed = 0.0f;
                _navMeshAgent.velocity = Vector3.zero;
            }
            if (_isAttacking)
            {
                transform.LookAt(_target.transform.position);
                _attackTime += Time.deltaTime;
                if (_attackTime > _attackSpeed)
                {
                    _onAttackEvt.Invoke();
                    ResetAttack();
                    if (GetDistanceFromTarget() <= GetStopRange() + 1)
                    {
                        _damage.DealDamage(_target.gameObject);
                    }
                }
            }
        }
        else
        {
            _animator.SetBool("_isRunning", false);
            _navMeshAgent.stoppingDistance = 0;
            _currentSpeed = _Speed;
            _animator.SetBool("_isAttacking", false);
            _animator.SetBool("_isShooting", false);
            _attackTime = 0.0f;
            _isAttacking = false;
            _navMeshAgent.speed = _currentSpeed;
            _target = null;
            SetState(State._Idle);
        }
    }

    protected void AttackRangeWhenNearTarget()
    {
        if (_target)
        {
            _navMeshAgent.stoppingDistance = _stopRange;
            SetDistanceFromTarget(Vector3.Distance(transform.position, _target.transform.position));
            if (GetDistanceFromTarget() <= GetStopRange())
            {
                _animator.SetBool("_isShooting", true);
                _InitialRotation = transform.eulerAngles;
                _isAttacking = true;
                _navMeshAgent.speed = 0.0f;
                _navMeshAgent.velocity = Vector3.zero;
                transform.LookAt(_target.transform.position);
                _attackTime += Time.deltaTime;
                if (_attackTime > _attackSpeed)
                {
                    _animator.SetBool("_isShooting", false);
                    _onAttackEvt.Invoke();
                    GameObject _newProjectile = _projectile;
                    Projectile _Projectile = _newProjectile.GetComponent<Projectile>();
                    _Projectile._Damage = _damage._Damage;
                    _Projectile._CriticalChance = _damage._CriticalChance;
                    _Projectile._CriticalDamage = _damage._CriticalDamage;
                    _Projectile._StatusChance = _damage._StatusChance;
                    _Projectile._DamageType = _damage._DamageType;
                    _Projectile.SetOwner(gameObject);
                    _Projectile.SetIsPlayer(false);
                    Instantiate(_projectile, _transform.position, _transform.rotation);
                    _attackTime = 0.0f;
                }
            }
            else if (GetDistanceFromTarget() > GetStopRange()) ResetAttack1();
        }
        else
        {
            _animator.SetBool("_isRunning", false);
            _navMeshAgent.stoppingDistance = 0;
            _currentSpeed = _Speed;
            _animator.SetBool("_isAttacking", false);
            _animator.SetBool("_isShooting", false);
            _attackTime = 0.0f;
            _isAttacking = false;
            _navMeshAgent.speed = _currentSpeed;
            _target = null;
            SetState(State._Idle);
        }
    }

    protected void ResetAttack()
    {
        if (_comboIndex < _comboIndexes) _comboIndex++;
        else _comboIndex = 0;
        _animator.SetInteger("_comboIndex", _comboIndex);
        _animator.SetBool("_isAttacking", false);
        _animator.SetBool("_isShooting", false);
        _attackTime = 0.0f;
        _isAttacking = false;
        _navMeshAgent.speed = _currentSpeed;
        transform.eulerAngles = _InitialRotation;
    }

    protected void ResetAttack1()
    {
        if (_comboIndex < _comboIndexes) _comboIndex++;
        else _comboIndex = 0;
        _animator.SetInteger("_comboIndex", _comboIndex);
        _animator.SetBool("_isAttacking", false);
        _animator.SetBool("_isShooting", false);
        _attackTime = 0.0f;
        _isAttacking = false;
        _navMeshAgent.speed = _currentSpeed;
    }

    protected void OnCollisionEnter(Collision _hit)
    {
        if (_hit.gameObject.GetComponent<Door>()) _hit.gameObject.GetComponent<Door>().Interact();
    } 
    #endregion

    #region Public Functions
    public void SetState(State _newState) { _state = _newState; }
    public void SetIdle() { _state = State._Idle; }
    public void SetWander() { _state = State._Wander; }
    public void SetAggro() { _state = State._Aggro; }
    public void SetRetreat() { _state = State._Retreat; }
    #endregion
}