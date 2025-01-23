using UnityEngine;

//Corrode = Toxin + Electric
//Disables Armor during the effect
public class Corrode : Status
{
    #region Variables
    protected Armor _armor;
    #endregion

    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Corrode";
        _statusColor = Color.gray;
        _statusMaterial = _statusVars._StatusMaterial[9];
        _armor = GetComponent<Armor>();
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