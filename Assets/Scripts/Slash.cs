using UnityEngine;

//Slash
//Deals Damage overtime that bypasses Armor during the effect
public class Slash : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Slash";
        _statusColor = Color.white;
        _statusMaterial = _statusVars._StatusMaterial[2];
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTime <= _statusTimer)
            {
                if (_statusTick > _statusTicker)
                {
                    DamageEventHealthShield();
                    _statusTick = 0.0f;
                }
            }
            else if (_statusTime > _statusTimer)
            {
                DamageEventHealthShield();
                DisableStatus();
            }
        }
    }
    #endregion
}