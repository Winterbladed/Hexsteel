using UnityEngine;

//Fire
//Deals Damage overtime and reduces Armor to 50% of Max Armor during the effect
public class Fire : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Fire";
        _statusColor = new Color(1.0f, 0.5f, 0.0f);
        _statusMaterial = _statusVars._StatusMaterial[5];
    }

    protected void Update()
    {
        if (_isActive && !_isStatusInfused)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTime <= _statusTimer)
            {
                _armor.DisfunctionArmor();
                if (_statusTick > _statusTicker)
                {
                    DamageEventHealthArmorShield();
                    _statusTick = 0.0f;
                }
            }
            else if (_statusTime > _statusTimer)
            {
                DamageEventHealthArmorShield();
                _armor.RestoreArmor1();
                DisableStatus();
            }
        }
    }
    #endregion
}