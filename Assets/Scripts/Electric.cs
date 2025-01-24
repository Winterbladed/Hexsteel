using UnityEngine;

//Electric
//Deals Quick Weak Damage overtime during the effect
public class Electric : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Electric";
        _statusColor = new Color(0.5f, 0.0f, 1.0f);
        _statusMaterial = _statusVars._StatusMaterial[6];
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
                    DamageEventHealthArmorShield();
                    _statusTick = 0.0f;
                }
            }
            else if (_statusTime > _statusTimer)
            {
                DamageEventHealthArmorShield();
                DisableStatus();
            }
        }
    }
    #endregion
}