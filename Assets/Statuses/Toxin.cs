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
        _health = GetComponent<Health>();
        _armor = GetComponent<Armor>();
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
            {
                _health.TakeHpDamage(_statusDamage - _armor.GetCurrentAp());
                _textEvent.ShowDamage(_statusDamage - _armor.GetCurrentAp(), _statusColor, gameObject.transform);
                _statusTick = 0.0f;
            }
            if (_statusTime > _statusTimer)
            {
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}