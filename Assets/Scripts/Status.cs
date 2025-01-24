using UnityEngine;
[RequireComponent (typeof(TextEvent))]

public class Status : MonoBehaviour
{
    #region Variables
    protected bool _isActive = false;
    protected string _statusName;
    [SerializeField] protected Sprite _statusSprite;
    [SerializeField] protected GameObject _statusImage;
    [SerializeField] protected GameObject _statusVfx;
    [SerializeField] protected bool _isStatusInfused = false;
    [SerializeField] protected bool _isStatusImmune = false;
    protected TextEvent _textEvent;
    protected Color _statusColor;
    protected Material _statusMaterial;

    protected int _statusDamage = 0;
    protected float _statusTimer = 0.0f;
    protected float _statusTime = 0.0f;
    protected float _statusTicker = 0.0f;
    protected float _statusTick = 0.0f;

    protected StatusVars _statusVars;
    protected Health _health;
    protected Armor _armor;
    protected Shield _shield;
    protected Movement _movement;
    #endregion

    #region Private Functions
    protected virtual void Start() 
    { 
        if (!_isStatusInfused) DisableStatus(); else if (_isStatusInfused) EnableStatus(); 
        _textEvent = GetComponent<TextEvent>(); _statusVars = StatusVars._StatusVars;
        _health = GetComponent<Health>();
        _armor = GetComponent<Armor>();
        _shield = GetComponent<Shield>();
        _movement = GetComponent<Movement>();
    }
    #endregion

    #region Public Functions
    //Health, Armor, Shield
    public void DamageEventHealthArmorShield()
    {
        if (_shield.GetCurrentSp() <= 0)
        {
            int _damage = (_statusDamage * _health.GetHpDamageMultiplier()) - _armor.GetCurrentAp();
            if (_damage <= 0) _damage = 0;
            _health.TakeHpDamage(_damage);
            _textEvent.ShowDamage(_damage, _statusColor, gameObject.transform);
        }
        else
        {
            _shield.TakeSpDamage(_statusDamage);
            _textEvent.ShowDamage(_statusDamage, _statusColor, gameObject.transform);
        }
    }

    //Health, Armor
    public void DamageEventHealthArmor()
    {
        int _damage = (_statusDamage * _health.GetHpDamageMultiplier()) - _armor.GetCurrentAp();
        if (_damage <= 0) _damage = 0;
        _health.TakeHpDamage(_damage);
        _textEvent.ShowDamage(_damage, _statusColor, gameObject.transform);
    }

    //Health, Shield
    public void DamageEventHealthShield()
    {
        if (_shield.GetCurrentSp() <= 0)
        {
            int _damage = _statusDamage * _health.GetHpDamageMultiplier();
            _health.TakeHpDamage(_damage);
            _textEvent.ShowDamage(_damage, Color.white, gameObject.transform);
        }
        else
        {
            _shield.TakeSpDamage(_statusDamage);
            _textEvent.ShowDamage(_statusDamage, Color.white, gameObject.transform);
        }
    }

    public bool GetIsActive() { return _isActive; }
    public bool GetIsStatusInfused() { return _isStatusInfused; }
    public string GetStatusName() { return _statusName; }
    public Color GetStatusColor() { return _statusColor; }
    public Material GetStatusMaterial() { return _statusMaterial; }
    public Sprite GetStatusSprite() { return _statusSprite; }
    public void SetStatusDamage(int _damage) { _statusDamage = _damage; }
    public void SetStatusTimer(float _timer) { _statusTimer = _timer; }
    public void SetStatusTicker(float _ticker) { _statusTicker = _ticker; }

    public void EnableStatus()
    {
        if (!_isStatusImmune)
        {
            _isActive = true;
            if (_statusVfx) _statusVfx.SetActive(true);
            if (_statusImage) _statusImage.SetActive(true);
            if (!_isStatusInfused) _textEvent.ShowStatus(_statusName, _statusColor, _statusMaterial, _statusSprite, transform);
        }
    }

    public void DisableStatus()
    {
        _statusTime = 0.0f;
        _statusTick = 0.0f;
        if (!_isStatusInfused)
        {
            _statusTime = 0.0f;
            _statusTick = 0.0f;
            _isActive = false;
            if (_statusVfx) _statusVfx.SetActive(false);
            if (_statusImage) _statusImage.SetActive(false);
        }
    }
    #endregion
}