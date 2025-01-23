using UnityEngine;

//Fire
//Deals Damage overtime during the effect
public class Fire : Status
{
    #region Variables
    protected Health _health;
    protected Armor _armor;
    protected Shield _shield;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Fire";
        _statusColor = new Color(1.0f, 0.5f, 0.0f);
        _statusMaterial = _statusVars._StatusMaterial[5];
        _health = GetComponent<Health>();
        _armor = GetComponent<Armor>();
        _shield = GetComponent<Shield>();
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