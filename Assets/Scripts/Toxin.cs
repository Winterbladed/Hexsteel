using UnityEngine;

//Toxin
//Deals Damage overtime that bypasses Shields during the effect
public class Toxin : Status
{
    #region Variables
    protected Health _health;
    protected Armor _armor;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Toxin";
        _statusColor = Color.green;
        _statusMaterial = _statusVars._StatusMaterial[3];
        _health = GetComponent<Health>();
        _armor = GetComponent<Armor>();
    }

    protected void Update()
    {
        if (_isActive && !_isStatusInfused)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTime <= _statusTimer)
            {
                if (_statusTick > _statusTicker)
                {
                    int _damage = (_statusDamage * _health.GetHpDamageMultiplier()) - _armor.GetCurrentAp();
                    if (_damage <= 0) _damage = 0;
                    _health.TakeHpDamage(_damage);
                    _textEvent.ShowDamage(_damage, _statusColor, gameObject.transform);
                    _statusTick = 0.0f;
                }
            }
            else if (_statusTime > _statusTimer)
            {
                DisableStatus();
            }
        }
    }
    #endregion
}