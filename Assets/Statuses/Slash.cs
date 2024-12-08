using UnityEngine;

public class Slash : Status
{
    #region Private Functions
    protected override void Start()
    {
        base.Start();
        _statusName = "Slash";
        _statusColor = Color.white;
    }
    #endregion
}