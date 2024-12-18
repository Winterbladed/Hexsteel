using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(Health))]

public class PlayerMovement : Movement
{
    #region Variables
    [Header("Move")]
    [SerializeField] private float _rotationSpeed = 1000.0f;

    private Vector3 _direction;

    private bool _isWalking;
    private bool _isRunning;
    private bool _isStrafing;
    private bool _isShooting;
    private bool _isShootingTwo;
    private bool _isAttacking;
    private bool _isThrowing;
    private bool _isEating;

    private int _comboIndex = 0;

    [Header("Jump")]
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _gravity = -20.0f;
    private float _verticalVelocity;

    private bool _isGrounded;

    [Header("Dodge Roll")]
    [SerializeField] private float _dodgeRollSpeed = 5.0f;
    [SerializeField] private float _dodgeRollDuration = 1.0f;
    [SerializeField] private float _dodgeRollCooldown = 0.5f;

    [SerializeField] private UnityEvent _onDodgeEvt;

    private bool _isDodging;

    private float _dodgeRollTime;
    private float _dodgeCooldownTime;

    [Header("References")]
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Animator _animator;
    private CharacterController _controller;
    private Health _health;
    private Inventory _inventory;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _controller = GetComponent<CharacterController>();
        _health = GetComponent<Health>();
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        _isGrounded = _controller.isGrounded;

        if (_isDodging)
        {
            if (Time.time >= _dodgeRollTime)
            {
                _isDodging = false;
                _health.Invulnerable(false);
            }
            else
            {
                Vector3 _dodgeDirection = _direction.normalized;
                _dodgeDirection.y = 0;
                _controller.Move(_dodgeDirection * _dodgeRollSpeed * Time.deltaTime);
            }
            return;
        }

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        Vector3 cameraForward = _cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        Vector3 cameraRight = _cameraTransform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();
        _direction = cameraRight * _horizontal + cameraForward * _vertical;
        Vector3 _move = _direction * _currentSpeed * Time.deltaTime;
        _move.y = _verticalVelocity * Time.deltaTime;
        _controller.Move(_move);

        if (Input.GetMouseButton(1) && !_isDodging)
        {
            Quaternion _targetRotation = Quaternion.LookRotation(cameraForward, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
            _isStrafing = true;
        }
        else if (_direction != Vector3.zero && !_isAttacking && !_isShooting && !_isShootingTwo && !_isThrowing)
        {
            _direction.Normalize();
            Quaternion _targetRotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
            _isStrafing = false;
        }

        if (!_isSlowed) _currentSpeed = _isRunning ? _runSpeed : _Speed;
        else _currentSpeed = _slowSpeed;
        if (_isAttacking && _isGrounded || _isShooting && _isGrounded || _isShootingTwo && _isGrounded || _isThrowing && _isGrounded || _inventory.GetIsSwitching() && _isGrounded || _inventory.GetIsGetting() && _isGrounded) _currentSpeed = 0.0f;

        _isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        _isRunning = Input.GetKey(KeyCode.LeftShift) && _isWalking && !Input.GetMouseButton(1)
            && !_isAttacking && !_isShooting && !_isShootingTwo && !_isEating && !_isThrowing && !_inventory.GetIsSwitching() && !_inventory.GetIsGetting();
        _isGrounded = _controller.isGrounded;

        if (_isGrounded && !_isDodging)
        {
            if (Input.GetButton("Jump") && !_isAttacking && !_isShooting && !_isShootingTwo) _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            else _verticalVelocity = -0.5f;
        }
        else _verticalVelocity += _gravity * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.C) && Time.time >= _dodgeCooldownTime && _isGrounded && !_isAttacking && _isWalking && !_isShooting && !_isShootingTwo && !_isStrafing && !_isEating && !_isThrowing && !_inventory.GetIsSwitching() && !_inventory.GetIsGetting())
        {
            _isDodging = true;
            _dodgeRollTime = Time.time + _dodgeRollDuration;
            _dodgeCooldownTime = Time.time + _dodgeRollCooldown;
            _onDodgeEvt.Invoke();
            _health.Invulnerable(true);
        }

        _animator.SetBool("_isGrounded", _isGrounded);
        _animator.SetBool("_isWalking", _isWalking);
        _animator.SetBool("_isRunning", _isRunning);
        _animator.SetBool("_isDodging", _isDodging);
        _animator.SetBool("_isStrafing", _isStrafing);
        _animator.SetBool("_isShooting", _isShooting);
        _animator.SetBool("_isShootingTwo", _isShootingTwo);
        _animator.SetBool("_isAttacking", _isAttacking);
        _animator.SetBool("_isThrowing", _isThrowing);
        _animator.SetBool("_isEating", _isEating);
        _animator.SetInteger("_comboIndex", _comboIndex);
        _animator.SetBool("_isSwitching", _inventory.GetIsSwitching());
        _animator.SetBool("_isGetting", _inventory.GetIsGetting());
    }
    #endregion

    #region Public Functions
    public bool GetIsGrounded() { return _isGrounded; } public bool GetIsWalking() { return _isWalking; } public bool GetIsRunning() { return _isRunning; } public bool GetIsSlowed() { return _isSlowed; }
    public bool GetIsDodging() { return _isDodging; } public bool GetIsStrafing() { return _isStrafing; } public void SetDodgeRollSpeed(float _newDodgeRollSpeed) { _dodgeRollSpeed = _newDodgeRollSpeed; }
    public bool GetIsAttacking() { return _isAttacking; } public bool GetIsShooting() { return _isShooting; } public bool GetIsShootingTwo() { return _isShootingTwo; }
    public bool GetIsEating() { return _isEating; } public bool GetIsThrowing() { return _isThrowing; } public void SetEating(bool _boolean) { _isEating = _boolean; } public void SetThrowing(bool _boolean) { _isThrowing = _boolean; }
    public void SetAttacking(bool _boolean) {  _isAttacking = _boolean; } public void SetShooting(bool _boolean) { _isShooting = _boolean; } public void SetShootingTwo(bool _boolean) { _isShootingTwo = _boolean; } 
    public void SetSpeed(float _newSpeed) { _Speed = _newSpeed; _currentSpeed = _newSpeed; _slowSpeed = _newSpeed / 2; _runSpeed = _newSpeed * 4.0f; }
    public void SetJumpHeight(float _newJumpHeight) { _jumpHeight = _newJumpHeight;} public void SetGravity(float _newGravity) { _gravity = _newGravity; }
    public void SetComboIndex(int _index) { _comboIndex = _index; }
    #endregion
}