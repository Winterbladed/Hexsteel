using UnityEngine;

public class Gas : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Gas";
        _statusColor = Color.yellow;
    }
    #endregion
}