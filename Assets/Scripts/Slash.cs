using UnityEngine;

//Slash
//Deals Damage overtime that bypasses Armor during the effect
public class Slash : Status
{
    #region Variables
    protected Health _health;
    protected Shield _shield;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Slash";
        _statusColor = Color.white;
        _statusMaterial = _statusVars._StatusMaterial[2];
        _health = GetComponent<Health>();
        _shield = GetComponent<Shield>();
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
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
                
                _statusTick = 0.0f;
            }
            if (_statusTime > _statusTimer)
            {
                DisableStatus();
            }
        }
    }
    #endregion
}