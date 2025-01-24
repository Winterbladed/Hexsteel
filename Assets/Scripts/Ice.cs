using UnityEngine;

//Ice
//Slows down Movement Speed and Deals Weak Damage overtime during the effect
public class Ice : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Ice";
        _statusColor = Color.cyan;
        _statusMaterial = _statusVars._StatusMaterial[4];
    }

    protected void Update()
    {
        if (_isActive && !_isStatusInfused)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            _movement.Slow();
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
                _movement.UnSlow();
                DisableStatus();
            }
        }
    }
    #endregion
}