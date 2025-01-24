using UnityEngine;

//Pierce
//Reduces Armor by 10% of Max Armor and increase Critical Damage taken by Health during the effect
public class Pierce : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Pierce";
        _statusColor = Color.white;
        _statusMaterial = _statusVars._StatusMaterial[1];
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _health.ModifyHpCritDamageTaken(2);
            _armor.DebilitateArmor();
            if (_statusTime > _statusTimer)
            {
                _health.ModifyHpCritDamageTaken(1);
                _armor.RestoreArmor2();
                DisableStatus();
            }
        }
    }
    #endregion
}