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
    #endregion
}