using UnityEngine;

//Magnetic = Ice + Electric
//Disables Shield during the effect
public class Magnetic : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Magnetic";
        _statusColor = Color.blue;
        _statusMaterial = _statusVars._StatusMaterial[11];
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _shield.ShieldDisable(true);
            if (_statusTime > _statusTimer)
            {
                _shield.ShieldDisable(false);
                DisableStatus();
            }
        }
    }
    #endregion
}