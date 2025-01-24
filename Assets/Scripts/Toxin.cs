using UnityEngine;

//Toxin
//Deals Damage overtime that bypasses Shields during the effect
public class Toxin : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Toxin";
        _statusColor = Color.green;
        _statusMaterial = _statusVars._StatusMaterial[3];
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
                    DamageEventHealthArmor();
                    _statusTick = 0.0f;
                }
            }
            else if (_statusTime > _statusTimer)
            {
                DamageEventHealthArmor();
                DisableStatus();
            }
        }
    }
    #endregion
}