using UnityEngine;

public class Damage : MonoBehaviour
{
    #region Variables
    public enum DamageType
    {
        Default,
        Slow,
        Poison,
        Aoe,
        Weaken
    }

    [Header("Damage Stats")]
    public DamageType _DamageType;
    public int _Damage;
    protected int _normalDamage;
    protected int _reducedDamage;
    protected int _computedDamage = 0;

    [Header("Critical Stats")]
    public int _CriticalDamage;
    public float _CriticalChance;
    protected float _currentCriticalChance = 0.0f;
    protected bool _isCritical = false;

    [Header("Status Stats")]
    public float _StatusChance;
    protected float _currentStatusChance = 0.0f;
    protected bool _isStatus = false;

    [Header("Status Effect Stats")]
    public int _StatusDamage = 0;
    public float _StatusTimer = 0.0f;
    public float _StatusTicker = 0.0f;

    [Header("References")]
    [SerializeField] protected TextEvent _textEvent;
    #endregion

    #region Private Functions
    private void Start()
    {
        _normalDamage = _Damage;
        _reducedDamage = _Damage / 2;
    }
    #endregion

    #region Protected Functions
    protected void CriticalDamageChance()
    {
        _Damage = _normalDamage;
        _currentCriticalChance = Random.Range(0.0f, 1.0f);
        if (_currentCriticalChance <= _CriticalChance)
        {
            _Damage *= _CriticalDamage;
            _isCritical = true;
        }
        else _isCritical = false;
    }

    protected void StatusChance()
    {
        _currentStatusChance = Random.Range(0.0f, 1.0f);
        if (_currentStatusChance <= _StatusChance)
        {
            _isStatus = true;
        }
        else _isStatus = false;
    }

    protected void DamageEvent(int _number, GameObject _target)
    {
        _computedDamage = _number;
        TextDamage(_target);
    }

    protected void TextDamage(GameObject _target)
    {
        Health _health = _target.GetComponent<Health>();
        if (_computedDamage < 0)
        {
            _computedDamage = 0;
            _textEvent.ShowDamage(0, Color.gray, _target.transform);
        }
        if (!_isCritical && _computedDamage * _health.GetHpDamageMultiplier() > 0)
            _textEvent.ShowDamage(_computedDamage * _health.GetHpDamageMultiplier(), Color.white, _target.transform);
        if (_isCritical && _computedDamage * _health.GetHpDamageMultiplier() > 0)
            _textEvent.ShowDamage(_computedDamage * _health.GetHpDamageMultiplier(), Color.yellow, _target.transform);
    }

    protected void DealDamage(GameObject _target)
    {
        if (_target.gameObject.GetComponent<Health>())
        {
            CriticalDamageChance();
            StatusChance();
            Health _health = _target.gameObject.GetComponent<Health>();
            if (_health.GetCurrentHp() > 0 && !_health.GetIsInvulnerable())
            {
                DamageEvent(_Damage, _target.gameObject);
                _health.TakeHpDamage(_computedDamage);
                if (_isStatus && _target.gameObject.GetComponent<Status>()) DealStatusEffect(_target.gameObject);
            }
        }
    }

    protected void DealStatusEffect(GameObject _target)
    {
        Slow _slow = _target.GetComponent<Slow>();
        Poison _poison = _target.GetComponent<Poison>();
        Aoe _aoe = _target.GetComponent<Aoe>();
        Weaken _weaken = _target.GetComponent<Weaken>();
        if (_DamageType == DamageType.Slow && !_slow.GetIsActive())
        {
            _slow.EnableStatus();
            SetStatusStats(_slow, _StatusDamage, _StatusTimer, _StatusTicker);
        }
        else if (_DamageType == DamageType.Poison && !_poison.GetIsActive())
        {
            _poison.EnableStatus();
            SetStatusStats(_poison, _StatusDamage, _StatusTimer, _StatusTicker);
        }
        else if (_DamageType == DamageType.Aoe && !_aoe.GetIsActive())
        {
            _aoe.EnableStatus();
            SetStatusStats(_aoe, _StatusDamage, _StatusTimer, _StatusTicker);
        }
        else if (_DamageType == DamageType.Weaken && !_weaken.GetIsActive())
        {
            _weaken.EnableStatus();
            SetStatusStats(_weaken, _StatusDamage, _StatusTimer, _StatusTicker);
        }
    }

    protected void SetStatusStats(Status _statusEffect, int _damage, float _time, float _tick)
    {
        _statusEffect.SetStatusDamage(_damage);
        _statusEffect.SetStatusTimer(_time);
        _statusEffect.SetStatusTicker(_tick);
    }
    #endregion

    #region Public Functions
    public void CrippleDamage()
    {
        _Damage = _reducedDamage;
    }

    public void UnCrippleDamage()
    {
        _Damage = _normalDamage;
    }
    #endregion
}