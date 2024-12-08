using UnityEngine;

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
        _armor = GetComponent<Armor>();
    }

    protected void Update()
    {
        if (_isActive)
        {
            _statusTime += Time.deltaTime;
            _statusTick += Time.deltaTime;
            if (_statusTick > _statusTicker)
            {
                _armor.DisableArmor();
                _statusTick = 0.0f;
            }
            if (_statusTime > _statusTimer)
            {
                _armor.RestoreArmor();
                _statusTime = 0.0f;
                DisableStatus();
            }
        }
    }
    #endregion
}