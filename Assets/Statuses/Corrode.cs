using UnityEngine;

public class Corrode : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Corrode";
        _statusColor = Color.gray;
    }
    #endregion
}