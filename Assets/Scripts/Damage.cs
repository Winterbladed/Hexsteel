using UnityEngine;

public class Damage : MonoBehaviour
{
    #region Variables
    public enum DamageType
    {
        Default,
        Toxin,
        Ice,
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
        {
            if (!_health.GetIsBlocking()) _textEvent.ShowDamage(_computedDamage * _health.GetHpDamageMultiplier(), Color.white, _target.transform);
            else if (_health.GetIsBlocking())
            {
                _textEvent.ShowState("Blocked!", Color.white, _target.transform);
                _textEvent.ShowDamage((_computedDamage * _health.GetHpDamageMultiplier()) / 4, Color.white, _target.transform);
            }
        }
        if (_isCritical && _computedDamage * _health.GetHpDamageMultiplier() > 0)
        {
            if (!_health.GetIsBlocking()) _textEvent.ShowDamage(_computedDamage * _health.GetHpDamageMultiplier(), Color.yellow, _target.transform);
            else if (_health.GetIsBlocking())
            {
                _textEvent.ShowState("Blocked!", Color.white, _target.transform);
                _textEvent.ShowDamage((_computedDamage * _health.GetHpDamageMultiplier()) / 4, Color.yellow, _target.transform);
            }
        }
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
        //Physical Status Effects
        Blunt _blunt = _target.GetComponent<Blunt>();
        Pierce _pierce = _target.GetComponent<Pierce>();
        Slash _slash = _target.GetComponent<Slash>();

        //Base Elemental Status Effects
        Toxin _toxin = _target.GetComponent<Toxin>();
        Ice _ice = _target.GetComponent<Ice>();
        Fire _fire = _target.GetComponent<Fire>();
        Electric _electric = _target.GetComponent<Electric>();

        //Advanced Elemental Status Effects
        Virus _virus = _target.GetComponent<Virus>();

        Weaken _melt = _target.GetComponent<Weaken>();
        Aoe _blast = _target.GetComponent<Aoe>();

        if (_toxin && _DamageType == DamageType.Toxin && !_toxin.GetIsActive())
        {
            _toxin.EnableStatus();
            SetStatusStats(_toxin, _StatusDamage, _StatusTimer, _StatusTicker);
        }
        else if (_ice && _DamageType == DamageType.Ice && !_ice.GetIsActive())
        {
            _ice.EnableStatus();
            SetStatusStats(_ice, _StatusDamage, _StatusTimer, _StatusTicker);
        }
        else if (_blast && _DamageType == DamageType.Aoe && !_blast.GetIsActive())
        {
            _blast.EnableStatus();
            SetStatusStats(_blast, _StatusDamage, _StatusTimer, _StatusTicker);
        }
        else if (_DamageType == DamageType.Weaken && !_melt.GetIsActive())
        {
            _melt.EnableStatus();
            SetStatusStats(_melt, _StatusDamage, _StatusTimer, _StatusTicker);
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