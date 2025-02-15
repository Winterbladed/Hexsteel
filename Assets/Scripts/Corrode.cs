using UnityEngine;

//Corrode = Toxin + Electric
//Disables Armor during the effect
public class Corrode : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Corrode";
        _statusColor = Color.gray;
        _statusMaterial = _statusVars._StatusMaterial[9];
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _armor.DisableArmor();
            if (_statusTime > _statusTimer)
            {
                _armor.RestoreArmor();
                DisableStatus();
            }
        }
    }
    #endregion
}