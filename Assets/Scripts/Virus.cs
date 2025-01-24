using UnityEngine;

//Virus = Toxin + Ice
//Modifies Health to take more damage from all sources during the effect
public class Virus : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Virus";
        _statusColor = Color.magenta;
        _statusMaterial = _statusVars._StatusMaterial[7];
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _health.ModifyHpDamageTaken(2);
            if (_statusTime > _statusTimer)
            {
                _health.ModifyHpDamageTaken(1);
                DisableStatus();
            }
        }
    }
    #endregion
}