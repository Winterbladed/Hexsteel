using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    #region Variables
    [Header("Health Stats")]
    private int _currentHp;
    [SerializeField] private int _hp;
    [SerializeField] private int _hpRegen;
    private float _hpRegenTime = 0.0f;
    private int _hpDamageMultiplier = 1;
    private bool _isRegen;
    private bool _isBlocking;
    [SerializeField] private bool _isInvulnerable;

    [Header("Death Manager")]
    [SerializeField] private float _deathTime = 5.0f;
    private float _currentDeathTime = 0.0f;
    private bool _isDead = false;

    [Header("Events")]
    public UnityEvent _OnHit;
    public UnityEvent _OnDeath;
    public UnityEvent _DuringDeath;
    #endregion

    #region Private Functions
    private void Start()
    {
        if (_hp <= 0) _hp = 1;
        _currentHp = _hp;
        _isDead = false;
    }

    private void Update()
    {
        RegenHp();
        Death();
    }

    private void CapHp()
    {
        if (_currentHp < 0) _currentHp = 0;
        else if (_currentHp > _hp) _currentHp = _hp;
    }

    private void RegenHp()
    {
        if (_hpRegen > 0 && !_isDead && _isRegen)
        {
            _hpRegenTime += Time.deltaTime;
            if (_hpRegenTime > 1.0f)
            {
                GiveHpHeal(_hpRegen);
                CapHp();
                _hpRegenTime = 0.0f;
            }
        }
    }
    #endregion

    #region Public Functions
    public void OnDeath()
    {
        _OnDeath?.Invoke();
    }

    public void Death()
    {
        if (_isDead)
        {
            _DuringDeath?.Invoke();
            _currentDeathTime += Time.deltaTime;
            if (_currentDeathTime > _deathTime)
            {
                OnDeath();
                _currentDeathTime = 0.0f;
            }
        }
    }

    public void TakeHpDamage(int _damage)
    {
        if (!_isInvulnerable)
        {
            if (!_isBlocking) _currentHp -= _damage * _hpDamageMultiplier;
            else if (_isBlocking) _currentHp -= (_damage * _hpDamageMultiplier) / 4;
            _OnHit?.Invoke();
            CapHp();
            if (_currentHp <= 0) _isDead = true;
        }
    }

    public void GiveHpHeal(int _heal)
    {
        _currentHp += _heal;
        CapHp();
    }

    public void Block(bool _boolean)
    {
        _isBlocking = _boolean;
    }

    public void ModifyHpDamageTaken(int _mult) { _hpDamageMultiplier = _mult; }
    public void DestroyGameObject() { Destroy(gameObject); }
    public int GetCurrentHp() { return _currentHp; }
    public int GetHp() { return _hp; }
    public int GetHpDamageMultiplier() { return _hpDamageMultiplier; }
    public void SetHpRegen(bool _bool) { _isRegen = _bool; }
    public void DebugHealth() { Debug.Log("Health: " + _currentHp + "/" + _hp); }
    public void Invulnerable(bool _boolean) { _isInvulnerable = _boolean; }
    public bool GetIsInvulnerable() { return _isInvulnerable; }
    public bool GetIsBlocking() { return _isBlocking; }
    public bool GetIsDead() { return _isDead; }
    #endregion
}