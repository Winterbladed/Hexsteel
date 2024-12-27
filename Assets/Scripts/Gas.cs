using UnityEngine;

//Gas = Toxin + Fire
//Deals Damage overtime in an Area Of Effect and disables Health Regen during the effect
public class Gas : Status
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
        _statusName = "Gas";
        _statusColor = Color.yellow;
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
                    _health.DisableRegen(true);
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
                    Collider[] _colliders = Physics.OverlapSphere(transform.position, 5.0f);
                    foreach (Collider _hit in _colliders)
                    {
                        if (_hit.gameObject.GetComponent<Health>())
                        {
                            if (_hit.gameObject.GetComponent<Shield>().GetCurrentSp() <= 0)
                            {
                                int _damage = (_statusDamage * _health.GetHpDamageMultiplier()) - _armor.GetCurrentAp();
                                if (_damage <= 0) _damage = 0;
                                _hit.gameObject.GetComponent<Health>().TakeHpDamage(_damage);
                                _textEvent.ShowDamage(_damage, _statusColor, _hit.gameObject.transform);
                            }
                            else
                            {
                                _hit.gameObject.GetComponent<Shield>().TakeSpDamage(_statusDamage);
                                _textEvent.ShowDamage(_statusDamage, _statusColor, _hit.gameObject.transform);
                            }
                        }
                    }
                    _statusTick = 0.0f;
                }
            }
            else if (_statusTime > _statusTimer)
            {
                _health.DisableRegen(false);
                DisableStatus();
            }
        }
    }
    #endregion
}