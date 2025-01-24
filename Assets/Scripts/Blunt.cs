using UnityEngine;

//Blunt
//Deals Damage to 10% of Max Shields per instance
public class Blunt : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Blunt";
        _statusColor = Color.white;
        _statusMaterial = _statusVars._StatusMaterial[0];
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
            {
                _shield.Take10PercentSpDamage();
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