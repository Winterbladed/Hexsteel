using UnityEngine;

//Gas = Toxin + Fire
//Deals Damage overtime in an Area Of Effect and disables Health Regen during the effect
public class Gas : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Gas";
        _statusColor = Color.yellow;
        _statusMaterial = _statusVars._StatusMaterial[8];
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
                    DamageEventHealthArmorShield();
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
                DamageEventHealthArmorShield();
                _health.DisableRegen(false);
                DisableStatus();
            }
        }
    }
    #endregion
}