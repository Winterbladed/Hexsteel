using UnityEngine;

public class Magnetic : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Magnetic";
        _statusColor = Color.blue;
    }
    #endregion
}