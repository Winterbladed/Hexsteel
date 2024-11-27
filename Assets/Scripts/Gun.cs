using UnityEngine;
using UnityEngine.Events;

public class Gun : Damage
{
    #region Variables
    [Header("Gun Stats")]
    [SerializeField] protected float _gunFireRate;
    protected float _gunCurrentFireRate;
    [SerializeField] protected float _gunReloadSpeed;
    protected float _gunCurrentReloadSpeed;
    [SerializeField] protected int _gunMagazineCapacity;
    [SerializeField] protected int _gunCurrentMagazineLoad;
    protected bool _isShooting;
    protected bool _isReloading;

    [Header("Gun Reference")]
    [SerializeField] protected GameObject _projectile;
    [SerializeField] protected Transform _transform;

    [Header("Gun Events")]
    [SerializeField] protected UnityEvent _onShootEvt;
    [SerializeField] protected UnityEvent _onReloadEvt;
    [SerializeField] protected UnityEvent _onEmptyEvt;
    #endregion

    #region Protected Functions
    protected virtual void Start()
    {
        _gunCurrentFireRate = _gunFireRate;
    }

    protected virtual void Update()
    {
        Shoot();
        Reload();
        FireRate();
    }
    #endregion

    #region Private Functions
    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _gunCurrentFireRate >= _gunFireRate && _gunCurrentMagazineLoad > 0 && Time.timeScale > 0)
        {
            GameObject _newProjectile = _projectile;
            Instantiate(_newProjectile, _transform.position, _transform.rotation);
            _gunCurrentFireRate = 0.0f;
            _gunCurrentMagazineLoad--;
            _isShooting = true;
            _onShootEvt.Invoke();
        }
        else if (Input.GetKey(KeyCode.Mouse0) && _gunCurrentFireRate >= _gunFireRate && _gunCurrentMagazineLoad <= 0 && !_isReloading)
        {
            _gunCurrentFireRate = 0.0f;
            _isShooting = false;
        }
        else _isShooting = false;
    }

    private void Reload()
    {
        if (Input.GetKey(KeyCode.R) && _gunCurrentMagazineLoad < _gunMagazineCapacity && !_isReloading)
        {
            _isReloading = true;
        }
        if (_isReloading)
        {
            _gunCurrentReloadSpeed += Time.deltaTime;
            if (_gunCurrentReloadSpeed > _gunReloadSpeed)
            {
                _gunCurrentMagazineLoad = _gunMagazineCapacity;
                _gunCurrentReloadSpeed = 0.0f;
                _isReloading = false;
                _onReloadEvt.Invoke();
            }
        }
    }

    private void FireRate()
    {
        _gunCurrentFireRate += Time.deltaTime;
        if (_gunCurrentFireRate > _gunFireRate)
            _gunCurrentFireRate = _gunFireRate;
    }
    #endregion
}